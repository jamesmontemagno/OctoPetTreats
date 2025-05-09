using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPetTreats.Models
{
    public class PetTreat
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Range(0.1, 500)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [StringLength(30)]
        [Required]
        public string? Type { get; set; } // e.g., Chew, Biscuit, Dental

        [StringLength(100)]
        public string? Flavor { get; set; }
    }
}
