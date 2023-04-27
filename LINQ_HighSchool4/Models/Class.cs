using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LINQ_HighSchool4.Models;

namespace LINQ_HighSchool4.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        [DisplayName("Class")]
        [StringLength(5)]
        public string ClassName { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<ClassCourse>? ClassCourses { get; set; }
        public ICollection<TeacherClassCourse>? TeacherClassCourses { get; set; }
    }
}
