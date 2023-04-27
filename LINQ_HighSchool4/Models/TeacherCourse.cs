using LINQ_HighSchool4.Models;

namespace LINQ_HighSchool4.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public int FK_TeacherId { get; set; }
        public int FK_CourseId { get; set; }
        public Teacher? Teachers { get; set; }
        public Course? Courses { get; set; }
    }
}
