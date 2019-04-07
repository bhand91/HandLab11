using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HandLab11.Models
{
    public static class SeedData
    {
    public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProfessorDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProfessorDbContext>>()))
            {
                // Look for any professors.
                if (context.Professor.Any())
                {
                    return; // DB has been seeded
                }
                
                context.Professor.AddRange(
                    new Professor
                    {
                        FirstName = "Minerva" ,
                        LastName = "McGonagall"
                    },
                    new Professor
                    {
                        FirstName = "George",
                        LastName = "Feeny"
                    },
                    new Professor
                    {
                        FirstName = "Hubert",
                        LastName = "Farnsworth"
                    },
                    new Professor
                    {
                        FirstName = "John",
                        LastName = "Frink Jr."
                    }
                );
                
                context.SaveChanges();
            }    
        }
    }
}