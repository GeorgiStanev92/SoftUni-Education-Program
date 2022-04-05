using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	internal class ChangeTracker<T>
		where T : class, new()
	{
		private readonly List<T> allEntities;

		private readonly List<T> added;

		private readonly List<T> removed;

		public ChangeTracker(IEnumerable<T> entities)
		{
			this.added = new List<T>();
			this.removed = new List<T>();

			this.allEntities = CloneEntities(entities);
		}

		public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
		public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
		public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

		public void Add(T item) => this.added.Add(item);

		public void Remove(T item) => this.removed.Remove(item);

		public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
			List<T> modifiedEntities = new List<T>();

			PropertyInfo[] primaryKey = typeof(T)
				.GetProperties()
				.Where(pi => pi.HasAttribute<KeyAttribute>())
				.ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
				object[] primaryKeyValues = GetPrimaryKeyValues(primaryKey, proxyEntity)
					.ToArray();

				T entity = dbSet.Entities
					.Single(e => GetPrimaryKeyValues(primaryKey, e).SequenceEqual(primaryKeyValues));

				bool isModified = IsModified(entity, proxyEntity);
                if (isModified)
                {
					modifiedEntities.Add(entity);
                }
				return modifiedEntities;
			}
        }

		private static List<T> CloneEntities(IEnumerable<T> entities)
		{
			var clonedEntities = new List<T>();

			PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
				.Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
				.ToArray();

			foreach (var entity in entities)
			{
				var clonedEntity = Activator.CreateInstance<T>();

				foreach (var property in propertiesToClone)
				{
					var value = property.GetValue(entity);
					property.SetValue(clonedEntity, value);
				}

				clonedEntities.Add(clonedEntity);
			}

			return clonedEntities;
		}

		private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
			=> primaryKeys.Select(pk => pk.GetValue(entity));

		private static bool IsModified(T entity, T proxyEntity)
        {
			PropertyInfo[] monitoredProperties = typeof(T).GetProperties()
				.Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
				.ToArray();

			PropertyInfo[] modifiedProperties = monitoredProperties
				.Where(pi => !Equals(pi.GetValue(proxyEntity), pi.GetValue(proxyEntity)))
				.ToArray();

			var isModified = modifiedProperties.Any();

			return isModified;
        }
	}
}