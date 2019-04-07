using System;
using Microsoft.AspNetCore.Mvc;

namespace HandLab11.Models
{
    public class Professor
    {
        public int ProfessorId {get; set;}

        [BindProperty]
        public string FirstName {get; set;}

        public string LastName {get; set;}
    }
}