using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HandLab11.Models
{
    public class Professor
    {
        public int ProfessorId {get; set;}

    
        public string FirstName {get; set;}

        public string LastName {get; set;}

        public List<Course> Courses {get; set;} //Navigation
    }
}