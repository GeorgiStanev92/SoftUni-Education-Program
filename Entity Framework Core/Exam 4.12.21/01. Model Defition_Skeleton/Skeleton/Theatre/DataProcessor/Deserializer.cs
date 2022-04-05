namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);

            PlayDto[] playsInput = (PlayDto[])xmlSerializer.Deserialize(stringReader);

            //ICollection<Play> plays = new HashSet<Play>();
            //var play = context.Plays.ToList();

            var plays = new HashSet<Play>();

            foreach (var play in playsInput)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan isDurationValue);

                if (!isDurationValid || isDurationValue.TotalHours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidGenre = Enum.TryParse(typeof(Genre), play.Genre, out var genre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play p = new Play
                {
                    Title = play.Title,
                    Duration = isDurationValue,
                    Rating = play.Rating,
                    Genre = (Genre)genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };

                plays.Add(p);

                sb.AppendLine(String.Format(SuccessfulImportPlay, p.Title, p.Genre, p.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            //return sb.ToString();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CastDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);

            var castInput = (CastDto[])xmlSerializer.Deserialize(stringReader);

            var casts = new HashSet<Cast>();

            foreach (var cast in castInput)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast c = new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                };

                string characterType = "";

                if (c.IsMainCharacter == true)
                {
                    characterType = "main";
                }
                else
                {
                    characterType = "lesser";
                }

                casts.Add(c);

                sb.AppendLine(String.Format(SuccessfulImportActor, c.FullName, characterType));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            TheaterDto[] theaterInput = JsonConvert.DeserializeObject<TheaterDto[]>(jsonString);

            var theatres = new HashSet<Theatre>();

            foreach (var theater in theaterInput)
            {
                if (!IsValid(theater) || theater.Name == "")
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Theatre theatre = new Theatre
                {
                    Name = theater.Name,
                    NumberOfHalls = theater.NumberOfHalls,
                    Director = theater.Director
                };

                foreach (var ticket in theater.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket tickets = new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };

                    theatre.Tickets.Add(tickets);
                }

                theatres.Add(theatre);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
