using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	public abstract class DbContext
    {
        private readonly DatabaseConnection databaseConnection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes = 
            { 
                typeof(int), 
                typeof(string),
                typeof(uint),
                typeof(long),
                typeof(ulong),
                typeof(decimal),
                typeof(bool),
                typeof(DateTime)
            };

        protected DbContext(string connectionString)
        {
            this.databaseConnection = new DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(this.databaseConnection))
            {
                this.InitializeDbSets();
            }
            this.MapAllRelations();
        }

        public void SaveChanges()
        {
            object[] dbSets = this.dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(entity => !IsObjectValid(entity))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException
                        ($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(this.databaseConnection))
            {
                using SqlTransaction sqlTransaction = this.databaseConnection.StartTransaction();

                foreach (IEnumerable dbSet in dbSets)
                {
                    Type dbSetType = dbSet
                        .GetType()
                        .GetGenericArguments()
                        .First();

                    MethodInfo persistMethod = typeof(DbContext)
                        .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                        .MakeGenericMethod(dbSetType);

                    try
                    {
                        persistMethod
                            .Invoke(this, new object?[] { dbSet });
                    }
                    catch (TargetInvocationException tie)
                    {
                        throw tie.InnerException;
                    }
                    catch (InvalidOperationException)
                    {
                        sqlTransaction.Rollback();
                        throw;
                    }
                    catch (SqlException)
                    {
                        sqlTransaction.Rollback();
                        throw;
                    }
                }
                sqlTransaction.Commit();
            }
        }
       
        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = this.GetTableName(typeof(TEntity));

            string[] columns = this.databaseConnection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.databaseConnection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            TEntity[] modifiedEntities = dbSet
                .ChangeTracker
                .GetModifiedEntities(dbSet)
                .ToArray();

            if (modifiedEntities.Any())
            {
                this.databaseConnection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.databaseConnection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private static bool IsObjectValid(object entity)
        {
            throw new NotImplementedException();
        }

        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type,PropertyInfo> dbSet in this.dbSetProperties)
            {
                Type dbSetType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)?
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] {dbSetProperty});
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = this.LoadTableEntities<TEntity>();
            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;

                MethodInfo mapRelationsGenericMethod = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                object dbSet = dbSetProperty.Value.GetValue(this);

                mapRelationsGenericMethod.Invoke(this, new object[] {dbSet});
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            PropertyInfo[] collections = entityType
                .GetProperties()
                .Where(pi => pi.PropertyType.IsGenericType &&
                             pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection))
                .ToArray();

            foreach (PropertyInfo collection in collections)
            {
                Type collectionType = collection.PropertyType.GenericTypeArguments.First();

                MethodInfo mapCollectionGenericMethod = typeof(DbContext)
                    .GetMethod("MapCollecton", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollectionGenericMethod.Invoke(this, new object[] {dbSet, collection});
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new() 
            where TCollection : class, new()
        {
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            PropertyInfo[] primaryKeys = collectionType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();
            PropertyInfo foreignKey = entityType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            bool isManyToMany = primaryKeys.Length >= 2;
            if (isManyToMany)
            {
                primaryKey = collectionType
                    .GetProperties()
                    .First(pi => collectionType
                        .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name).PropertyType == entityType);
            }

            DbSet<TCollection> navigationDbSet = (DbSet<TCollection>)
                this.dbSetProperties[collectionType].GetValue(this);

            foreach (var entity in dbSet)
            {
                object primaryKeyValue = foreignKey.GetValue(entity);
                var navigationEntities = navigationDbSet
                    .Where(navigationEntities => primaryKey.GetValue(navigationEntities).Equals(primaryKeyValue))
                    .ToArray();

                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }
        
        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
        {

        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}