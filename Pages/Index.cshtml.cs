using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HandLab11.Models;

namespace HandLab11.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProfessorDbContext _context;
        public List<Professor> Professors {get; set;}
        
        

        public IndexModel(ProfessorDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;

        public int PageSize {get; set;} = 10;

        public string namesort {get; set;}

        public string CurrentFilter {get; set;}

        public string CurrentSort {get; set;}

        
        public async Task OnGetAsync(string sortOrder)
        {
            var query = _context.Professor.Select(p =>p);

            namesort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            query = query.OrderByDesc(p => p.FirstName);
        }
        public async Task OnGetAsync(string sortOrder, string CurrentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            namesort = String
            skip((PageNum - 1)*PageSize).Take(PageSize).ToListAs
        }

        public void OnGet()
        {
            Professors = _context.Professor.ToList();
        }

    }
}
