using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var suppliersJsnonAsString = File.ReadAllText("../../../Datasets/suppliers.json");
            var partsJsnonAsString = File.ReadAllText("../../../Datasets/sales.json");
            var carsJsnonAsString = File.ReadAllText("../../../Datasets/cars.json");
            var customersJsnonAsString = File.ReadAllText("../../../Datasets/customers.json");
            var JsnonAsString = File.ReadAllText("../../../Datasets/sales.json");


            Console.WriteLine(ImportSuppliers(context, suppliersJsnonAsString));
            Console.WriteLine(ImportParts(context, partsJsnonAsString));
            Console.WriteLine(ImportCars(context, carsJsnonAsString));
            Console.WriteLine(ImportCustomers(context, customersJsnonAsString));
            Console.WriteLine(ImportSales(context, JsnonAsString));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

             IEnumerable<SuppliersInputDto> suppliers = JsonConvert.DeserializeObject<IEnumerable<SuppliersInputDto>>(inputJson);

            IEnumerable<Supplier> mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IEnumerable<Part> parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson);

           foreach (var part in parts)
            {
                if (context.Suppliers.Select(x => x.Id).Contains(part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IEnumerable<Car> cars = JsonConvert.DeserializeObject<IEnumerable<Car>>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<Sale> sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new CustomerOutputDto
                {
                    Name =c.Name,
                    BirthDate = c.BirthDate.ToString("dd//MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                });

            var jsonSetings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string resultJson = JsonConvert.SerializeObject(customers, jsonSetings);

            return resultJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotas = context.Cars
                .Where(t => t.Make == "Toyota")
                .Select(t => new
                {
                    t.Id,
                    t.Make,
                    t.Model,
                    t.TravelledDistance
                })
                .OrderBy(t => t.Model)
                .ThenByDescending(t => t.TravelledDistance);

            var jsonSetings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string resultJson = JsonConvert.SerializeObject(toyotas, jsonSetings);

            return resultJson;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                });

            var jsonSetings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string resultJson = JsonConvert.SerializeObject(suppliers, jsonSetings);

            return resultJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray();

            var jsonSetings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string resultJson = JsonConvert.SerializeObject(cars, jsonSetings);

            return resultJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .OrderByDescending(c => c.Sales.Count)
                .ThenByDescending(c => c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
                .Select( c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))

                });

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(customers, jsonSettings);

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100)):F2}"

                })
                .ToArray();

            var jsonSetting = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            var jsonFile = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return jsonFile;

        }

        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<CarDealerProfile>();
            });
            mapper = new Mapper(mapperConfiguration);
        }
    }
}