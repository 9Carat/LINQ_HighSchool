using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LINQ_HighSchool4.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [StringLength(30)]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [StringLength(30)]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [StringLength(15)]
        [DisplayName("Personal number")]
        public string PersonalNumber { get; set; }
        public int FK_ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
