using System.Xml.Serialization;

namespace CarDealer.DTO.ImportDto
{
    [XmlType("partId")]
    public class ImportCarPartsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
