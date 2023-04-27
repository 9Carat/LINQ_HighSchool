using System.ComponentModel;

namespace LINQ_HighSchool4.Models
{
    public class SchoolViewModel
    {
        [DisplayName("First name")]
        public string StudentFName { get; set; }
        [DisplayName("Last name")]
        public string StudentLName { get; set; }
        [DisplayName("Class name")]
        public string ClassName { get; set; }
        [DisplayName("Course name")]
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        [DisplayName("First name (teacher)")]
        public string TeacherFName { get; set; }
        [DisplayName("Last name (teacher)")]
        public string TeacherLName { get; set; }
    }
}
