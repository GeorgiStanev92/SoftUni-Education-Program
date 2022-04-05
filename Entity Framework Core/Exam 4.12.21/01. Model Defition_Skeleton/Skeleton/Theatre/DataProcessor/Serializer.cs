namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .ToArray()
                .Select(x => new TheatersDto
                {
                    Name = x.Name,
                    NumberOfHalls = x.NumberOfHalls,
                    TotalIncome = Math.Round(x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price), 2),
                    Tickets = x.Tickets
                              .Select(x => new TicketDto
                              {
                                  Price = decimal.Parse(x.Price),
                                  RowNumber = x.RowNumber
                              })
                              .OrderByDescending(x => x.Price)
                              .ToArray()
                })
                .OrderByDescending(x => x.NumberOfHalls)
                .ThenBy(x => x.Name)
                .ToArray();


            var jsonSetting = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            var jsonFile = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return jsonFile;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            throw new NotImplementedException();
        }
    }
}
