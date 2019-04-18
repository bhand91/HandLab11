using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

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
                        LastName = "McGonagall",
                        Courses = new List<Course> {
                            new Course {Description = "English"},
                            new Course {Description = "Gym"}
                        }

                    },
                    new Professor
                    {
                        FirstName = "George",
                        LastName = "Feeny",
                        Courses = new List<Course> {
                            new Course {Description = "Social Studies"},
                            new Course {Description = "Life"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Hubert",
                        LastName = "Farnsworth",
                        Courses = new List<Course> {
                            new Course {Description = "Astro Physics"},
                            new Course {Description = "How Not to Win a Nobel Prize"},
                            new Course {Description = "Science"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "John",
                        LastName = "Frink Jr.",
                        Courses = new List<Course> {
                            new Course {Description = "Chemistry"},
                            new Course {Description = "Science"},
                            new Course {Description = "Art"}
                        }
                    },

                    new Professor
                    {
                        FirstName = "No",
                        LastName = "Courses"
                    }
                );
                
                context.SaveChanges();
            }    
        }
    }
}