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

        public string Concat {get; set;}

        public ProfessorModel(ProfessorDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            // Get list of Professors
            Professors = _context.Professor.Include(p => p.Courses).ToList();

    
            ProfessorDropDown = new SelectList(Professors);
        }
        public void ButtonClick()
        {
            
        }
        
    }
}