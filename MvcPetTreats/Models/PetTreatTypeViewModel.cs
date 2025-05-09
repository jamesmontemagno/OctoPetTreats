using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcPetTreats.Models
{
    public class PetTreatTypeViewModel
    {
        public List<PetTreat>? PetTreats { get; set; }
        public SelectList? Types { get; set; }
        public string? PetTreatType { get; set; }
        public string? SearchString { get; set; }
    }
}
