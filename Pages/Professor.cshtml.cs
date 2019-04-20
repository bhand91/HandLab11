using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HandLab11.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HandLab11.Pages
{
    public class ProfessorModel : PageModel
    {
        private readonly ProfessorDbContext _context;
        public List<Professor> Professors {get; set;}
        public SelectList ProfessorDropDown {get; set;}

        public ProfessorModel(ProfessorDbContext context)
        {
            _context = context;
        }

        public string NameSort {get; set;}
        public string CurrentFilter {get; set;}

        public string CurrentSort {get; set;}
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Professor> professorQuery = from p in _context.Professor
                                                    select p;

            if(!String.IsNullOrEmpty(searchString))
            {
                professorQuery = professorQuery.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()) || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    professorQuery = professorQuery.OrderByDescending(p => p.LastName);
                    break;
                default:
                    professorQuery = professorQuery.OrderBy(p => p.LastName);
                    break;
            }

            Professors = await professorQuery.AsNoTracking().ToListAsync();

            // Get list of Professors
            Professors = _context.Professor.Include(p => p.Courses).ToList();
            // Create drop down list from Blogs
            // "BlogId" is Blog Model property to use as the value= setting
            // "Title" is the property to display in the drop down list
            // 2 is OPTIONAL. It says the default selected blog should be 2.
            // Change that or delete it and see what happens.
            ProfessorDropDown = new SelectList(Professors, "ProfessorId", "LastName");
        }
    }
}