using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LINQ_HighSchool4.Models;

namespace LINQ_HighSchool4.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [StringLength(30)]
        [DisplayName("Course")]
        public string CourseName { get; set; }
        public ICollection<ClassCourse>? ClassCourses { get; set; }
        public ICollection<TeacherClassCourse>? TeacherClassCourses { get; set; }
    }
}
