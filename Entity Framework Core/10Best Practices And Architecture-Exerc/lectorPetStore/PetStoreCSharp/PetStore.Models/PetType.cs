namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class PetType
    {
        public PetType()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PetTypeValidationConstants.TYPE_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
