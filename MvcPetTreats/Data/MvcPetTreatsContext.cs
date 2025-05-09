using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPetTreats.Models;

namespace MvcPetTreats.Data
{
    public class MvcPetTreatsContext : DbContext
    {
        public MvcPetTreatsContext (DbContextOptions<MvcPetTreatsContext> options)
            : base(options)
        {
        }

        public DbSet<PetTreat> PetTreat { get; set; } = null!;
    }
}
