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
            using (var context = new ProfessorDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProfessorDbContext>>()))
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
                            new Course {Description = "Transfiguration"}
                        }

                    },
                    new Professor
                    {
                        FirstName = "George",
                        LastName = "Feeny",
                        Courses = new List<Course> {
                            new Course {Description = "Archaeology I"},
                            new Course {Description = "Physics I"}
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
                        LastName = "Frink Jr."
                    },
                    new Professor
                    {
                        FirstName = "Robert" ,
                        LastName = "Langdon",
                        Courses = new List<Course> {
                            new Course {Description = "Symbology"},
                        }

                    },
                    new Professor
                    {
                        FirstName = "Severus",
                        LastName = "Snape",
                        Courses = new List<Course> {
                            new Course {Description = "Potions"},
                            new Course {Description = "Defense Against the Dark Arts"},
                            new Course {Description = "Herbology"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Professor",
                        LastName = "Fletcher",
                        Courses = new List<Course> {
                            new Course {Description = "Reading"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "James",
                        LastName = "Moriarty",
                        Courses = new List<Course> {
                            new Course {Description = "Mathematics"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Abraham" ,
                        LastName = "Van Helsing",
                    },
                    new Professor
                    {
                        FirstName = "Professor",
                        LastName = "Plum",
                        Courses = new List<Course> {
                            new Course {Description = "Psychiatry"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Egon",
                        LastName = "Spengler",
                        Courses = new List<Course> {
                            new Course {Description = "Parapsychology"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Padraic",
                        LastName = "Ratigan"
                    },
                    new Professor
                    {
                        FirstName = "Professor" ,
                        LastName = "Waldman",
                        Courses = new List<Course> {
                            new Course {Description = "Medicine"},
                        }

                    },
                    new Professor
                    {
                        FirstName = "Sherman",
                        LastName = "Klump",
                        Courses = new List<Course> {
                            new Course {Description = "Biology"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Archimedes",
                        LastName = "Porter",
                        Courses = new List<Course> {
                            new Course {Description = "Naturalist"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Henry 'Indiana'",
                        LastName = "Jones, Jr.",
                        Courses = new List<Course> {
                            new Course {Description = "Archaeology II"},
                            new Course {Description = "Medieval Literature"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Mary Margaret",
                        LastName = "Albright",
                        Courses = new List<Course> {
                            new Course {Description = "Anthropology"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Richard",
                        LastName = "Solomon",
                        Courses = new List<Course>{
                            new Course {Description = "Physics"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Maggie" ,
                        LastName = "Walsh",
                        Courses = new List<Course> {
                            new Course {Description = "Psychology II"},
                        }

                    },
                    new Professor
                    {
                        FirstName = "Urban",
                        LastName = "Chronotis",
                        Courses = new List<Course> {
                            new Course {Description = "Chronology"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "River",
                        LastName = "Song",
                        Courses = new List<Course> {
                            new Course {Description = "Mechanics"},
                            new Course {Description = "Endtime Gravity"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Vivian",
                        LastName = "Banks",
                        Courses = new List<Course> {
                            new Course {Description = "African-American History"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Ross" ,
                        LastName = "Geller",
                        Courses = new List<Course>{
                            new Course {Description = "Paleontology"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Tom",
                        LastName = "Mosby",
                        Courses = new List<Course> {
                            new Course {Description = "Architecture"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Nora",
                        LastName = "Lewin",
                        Courses = new List<Course> {
                            new Course {Description = "Law"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Charles Edward",
                        LastName = "Eppes",
                        Courses = new List<Course> {
                            new Course {Description = "Mathematics II"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Zelda" ,
                        LastName = "Spellman",
                        Courses = new List<Course> {
                            new Course {Description = "Quantum Physics"},
                        }
                    },
                    new Professor
                    {
                        FirstName = "Josiah",
                        LastName = "Bartlet",
                        Courses = new List<Course> {
                            new Course {Description = "Economics"}
                        }
                    },
                    new Professor
                    {
                        FirstName = "Henry",
                        LastName = "McCoy",
                        Courses = new List<Course> {
                            new Course {Description = "Genetics"},
                            new Course {Description = "Bio Chemistry"}
                        }
                    }
                );
                
                context.SaveChanges();
            }    
        }
    }
}