using LINQ_HighSchool4.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LINQ_HighSchool4.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        [StringLength(30)]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [StringLength(30)]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [StringLength(15)]
        [DisplayName("Personal number")]
        public string PersonalNumber { get; set; }
        public ICollection<TeacherClassCourse>? TeacherClassCourses { get; set; }
    }
}
