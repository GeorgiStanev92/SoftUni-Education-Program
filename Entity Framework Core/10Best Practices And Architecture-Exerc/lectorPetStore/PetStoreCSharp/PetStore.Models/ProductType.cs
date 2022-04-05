namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ProductType
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductTypeValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
