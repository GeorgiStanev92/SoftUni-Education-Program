using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ExportDto
{
    public class TheatersDto
    {
        public string Name { get; set; }

        public sbyte NumberOfHalls { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal Price { get; set; }

        public int RowNumber { get; set; }

        public Ticket Tickets { get; set; }
    }
}
