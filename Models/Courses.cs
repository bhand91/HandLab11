using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HandLab11.Models
{
    public class Course
    {
        public int CourseID {get; set;}
        public string Description {get; set;}

        public int 
        ProfessorId {get; set;} //FK

        public Professor Professor {get; set;} //Navigation

    }
}