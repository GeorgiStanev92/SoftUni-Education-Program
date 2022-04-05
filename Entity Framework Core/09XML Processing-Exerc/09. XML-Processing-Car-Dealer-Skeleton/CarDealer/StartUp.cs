using CarDealer.Data;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();

            //ResetDb(dbContext);

            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");


            //Console.WriteLine(ImportSuppliers(dbContext, suppliersXml));
            //Console.WriteLine(ImportParts(dbContext, partsXml));
            //Console.WriteLine(ImportCars(dbContext, carsXml));
            //Console.WriteLine(ImportCustomers(dbContext, customersXml));
            Console.WriteLine(GetCarsFromMakeBmw(dbContext));
        }

        //Import
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportSupplierDto[] dtos = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (ImportSupplierDto supplier in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = supplier.Name,
                    IsImporter = bool.Parse(supplier.IsImporter)
                };
                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartsDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportPartsDto[] importPartsDtos = (ImportPartsDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (ImportPartsDto part in importPartsDtos)
            {

                Supplier supplier = context.Suppliers.Find(part.SupplierId);
                if (supplier == null)
                {
                    continue;
                }

                Part p = new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    Supplier = supplier
                };
                parts.Add(p);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDto[] carsInput = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (ImportCarDto car in carsInput)
            {
                Car c = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance
                };

                ICollection<PartCar> partCars = new HashSet<PartCar>();

                foreach (int partId in car.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context.Parts.Find(partId);
                    if (part == null) { continue; }

                    PartCar partCar = new PartCar()
                    {
                        Car = c,
                        Part = part
                    };
                    partCars.Add(partCar);
                }

                c.PartCars = partCars;
                cars.Add(c);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCustomerDto[] importCustomerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (ImportCustomerDto customer in importCustomerDtos)
            {
                Customer c = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = DateTime.Parse(customer.BirthDate),
                    IsYoungDriver = bool.Parse(customer.isYoungDriver)
                };
                customers.Add(c);
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

            //TODO
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportSaleDto[] importSaleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Sale> sales = new HashSet<Sale>();
            foreach (ImportSaleDto sale in importSaleDtos)
            {
                Sale s = new Sale()
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount,
                };
                sales.Add(s);
            }

            context.AddRange(sales);
            context.SaveChanges();

           return $"Successfully imported {sales.Count}";
        }

        //Export
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            ExportCarsWithDistanceDto[] carsDtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString(),
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, carsDtos, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarFromBMW[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportCarFromBMW[] bmws = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarFromBMW()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance

                })
                .ToArray();

            xmlSerializer.Serialize(writer, bmws,namespaces);
            return sb.ToString().TrimEnd();

            //xmlSerializer.Serialize (stringWriter, bMWs, namespaces);
            //return sb.ToString().TrimEnd();

            //string make = "BMW";
            //ExportCarFromBMW[] cars = context.Cars
            //    .Where(c => c.Make == make)
            //    .OrderBy(c => c.Model)
            //    .ThenByDescending(c => c.TravelledDistance)
            //    .Select(c => new ExportCarFromBMW()
            //    {
            //        Id = c.Id,
            //        Model = c.Model,
            //        TravelledDistance = c.TravelledDistance

            //    })
            //    .ToArray();

            //ICollection < ExportCarFromBMW> bmws = new HashSet<ExportCarFromBMW>();

            //foreach (ExportCarFromBMW c in cars)
            //{
            //    ExportCarFromBMW currentDto = new ExportCarFromBMW()
            //    {
            //        Id = c.Id,
            //        Model = c.Model,
            //        TravelledDistance = c.TravelledDistance
            //    };

            //    bmws.Add(currentDto);
            //}

            //XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            //XmlSerializer serializer = new XmlSerializer(typeof(ExportCarFromBMW[]), xmlRoot);
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(String.Empty, String.Empty);

            //StringBuilder sb = new StringBuilder();
            //using StringWriter writer = new StringWriter(sb);
            //xmlSerializer.Serialize(stringWriter, bmws, namespaces);

            //return $"{sb.ToString().TrimEnd()}";
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSupplierDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportSupplierDto[] suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();


            xmlSerializer.Serialize(writer, suppliers, namespaces);
            

            return sb.ToString().TrimEnd();
        }

        //public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    using StringWriter writer = new StringWriter(sb);

        //    XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSupplierDto[]), xmlRoot);
        //    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        //    namespaces.Add(String.Empty, String.Empty);

        //    ExportCarsWithDistanceDto[] cars = context.Cars
        //        .Select(c => new ExportCarsWithDistanceDto()
        //        {
        //            car = new
        //            {
        //                Make = c.Make,
        //                Model = c.Model,
        //                TravelledDistance = c.TravelledDistance.ToString()
        //            },
        //            parts = new
        //            {

        //            }
        //        })

        //}

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleWithAppliedDiscountDto[]), xmlRoot); 
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportSaleWithAppliedDiscountDto[] dtos = context.Sales
                .Select(s => new ExportSaleWithAppliedDiscountDto()
                {
                    Car = new ExportSalesWithDicountCarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveleedDistance = s.Car.TravelledDistance.ToString()
                    },
                    Discount = s.Discount.ToString(),
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString(),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -
                                        s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100).ToString()
                })
                .ToArray();
            xmlSerializer.Serialize(stringWriter, dtos,namespaces);

            return sb.ToString().Trim();
        }
        private static void ResetDb(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            System.Console.WriteLine("done");
        }
    }
}