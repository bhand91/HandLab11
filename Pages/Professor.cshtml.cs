using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HandLab11.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace HandLab11.Pages
{
    public class ProfessorModel : PageModel
    {
        private readonly HandLab11.Models.ProfessorDbContext _context;
        
        private readonly ILogger _logger;
        public ProfessorModel(HandLab11.Models.ProfessorDbContext context, ILogger<ProfessorModel> logger)
        {
            _logger = logger;
            _context = context;
        }
        public PaginatedList<Professor> Professors {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string SearchString {get; set;}
        public SelectList ProfessorDropDown {get; set;}

        public SelectList SortList {get; set;}
        
        [BindProperty(SupportsGet = true)]
        public string Prof {get; set;}
        public string NameSort {get; set;}
        public string CurrentFilter {get; set;}
        public string CurrentSort {get; set;}
        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var professors = _context.Professor.Include(p => p.Courses).Select(p => p);

            var professorsQuery = _context.Professor.Include(p => p.Courses).Select( p => new {ID = p.ProfessorId, Display = string.Format($"{p.FirstName} {p.LastName}")}).Select(p => p);

            var courses = _context.Course.Include(c => c.Professor).Select(c => c);

            if(!string.IsNullOrEmpty(SearchString))
            {
                courses = courses.Where(c => c.Description.ToUpper().Contains(searchString));               
            }

        
           // IQueryable<Professor> professorQuery = from p in _context.Professor
                                                   // select p;

            if(!string.IsNullOrEmpty(Prof))
            {
                professors = professors.Where(x => x.ProfessorId.ToString() == Prof);
            }

            ProfessorDropDown = new SelectList (await professorsQuery.Distinct().ToListAsync(), "ID", "Display");
            
            switch (sortOrder)
            {
                case "name_desc":
                    professors = professors.OrderByDescending(p => p.LastName);
                    break;
                default:
                    professors = professors.OrderBy(p => p.LastName);
                    break;
            }
            
            //Professors = await professorQuery.AsNoTracking().ToListAsync();

            // Get list of Professors
            //Professors =  _context.Professor.Include(p => p.Courses).ToList();
            // Create drop down list from Blogs
            // "BlogId" is Blog Model property to use as the value= setting
            // "Title" is the property to display in the drop down list
            // 2 is OPTIONAL. It says the default selected blog should be 2.
            // Change that or delete it and see what happens.

            int pageSize = 10;

            Professors = await PaginatedList<Professor>.CreateAsync(
                professors.Include(p=> p.Courses).AsNoTracking(), pageIndex ?? 1, pageSize);
        
        }
    }
}