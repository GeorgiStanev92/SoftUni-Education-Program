using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType(TypeName = "Cast")]
    public class CastDto
    {

        //[Required]
        //[StringLength(30), MinLength(4)]
        //public string FullName { get; set; }

        //[Required]
        //public bool IsMainCharacter { get; set; }

        //[Required]
        //[RegularExpression(@"^\+44\-\d{2}\-\d{3}\-\d{4}$")]
        //public string PhoneNumber { get; set; }

        //[Required]
        //[ForeignKey(nameof(Play))]
        //public int PlayId { get; set; }
        //public Play Play { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [Required]
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"([+]44)-(\d{2})-(\d{3})-(\d{4})\b")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
