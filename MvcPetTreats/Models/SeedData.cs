using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPetTreats.Models;
using MvcPetTreats.Data;
using System;
using System.Linq;

namespace MvcPetTreats.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPetTreatsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcPetTreatsContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any pet treats.
                if (context.PetTreat.Any())
                {
                    return;   // DB has been seeded
                }

                context.PetTreat.AddRange(
                    new PetTreat
                    {
                        Name = "Bacon Chew",
                        ExpirationDate = DateTime.Parse("2025-12-31"),
                        Type = "Chew",
                        Flavor = "Bacon",
                        Price = 5.99M
                    },
                    new PetTreat
                    {
                        Name = "Chicken Biscuit",
                        ExpirationDate = DateTime.Parse("2025-10-15"),
                        Type = "Biscuit",
                        Flavor = "Chicken",
                        Price = 4.49M
                    },
                    new PetTreat
                    {
                        Name = "Dental Stick",
                        ExpirationDate = DateTime.Parse("2026-01-20"),
                        Type = "Dental",
                        Flavor = "Mint",
                        Price = 6.25M
                    },
                    new PetTreat
                    {
                        Name = "Salmon Soft Chew",
                        ExpirationDate = DateTime.Parse("2025-09-10"),
                        Type = "Chew",
                        Flavor = "Salmon",
                        Price = 7.10M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}