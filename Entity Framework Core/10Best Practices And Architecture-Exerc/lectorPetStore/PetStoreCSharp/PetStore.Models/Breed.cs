namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Breed
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BreedValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
