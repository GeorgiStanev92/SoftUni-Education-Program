using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType(TypeName = "Play")]
    public class PlayDto
    {
        [Required]
        [XmlElement]
        [StringLength(50), MinLength(4)]
        public string Title { get; set; }

        [Required]
        [XmlElement]
        public string Duration { get; set; }

        [Required]
        [XmlElement]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [XmlElement]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [XmlElement]
        [StringLength(30), MinLength(4)]
        public string Screenwriter { get; set; }
    }
}
