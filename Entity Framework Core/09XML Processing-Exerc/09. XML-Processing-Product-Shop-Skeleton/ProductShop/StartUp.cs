using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();

            //ResetDb(dbContext);
            InitializeMapper();

            string usersXml = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(dbContext, usersXml));

        }

        //Import
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportUserDto[] importUsers = (ImportUserDto[])xmlSerializer.Deserialize(stringReader);

            //ICollection<User> users = new HashSet<User>();
            //foreach (ImportUserDto user in importUsers)
            //{
            //    User u = new User()
            //    {
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        Age = user.Age
            //    };
            //    users.Add(u);
            //}
            ImportUserDto[] dtos = (ImportUserDto[])xmlSerializer.Deserialize(stringReader);
            User[] users = mapper.Map<User[]>(dtos);

            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Length}";
        }

        private static void ResetDb(ProductShopContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            System.Console.WriteLine("done");
        }

        private static void InitializeMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            mapper = new Mapper(config);
        }
    }
}