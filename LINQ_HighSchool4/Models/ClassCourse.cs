﻿using LINQ_HighSchool4.Models;

namespace LINQ_HighSchool4.Models
{
    public class ClassCourse
    {
        public int Id { get; set; }
        public int FK_ClassId { get; set; }
        public Class? Classes { get; set; }
        public int FK_CourseId { get; set; }
        public Course? Courses { get; set; }
        
    }
}
