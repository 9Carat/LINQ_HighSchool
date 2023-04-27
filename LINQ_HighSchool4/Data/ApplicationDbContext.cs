using LINQ_HighSchool4.Models;
using LINQ_HighSchool4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LINQ_HighSchool4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassCourse> ClassCourses { get; set; }
        public DbSet<TeacherCourse> TeachersCourses { get; set; }
        public DbSet<TeacherClassCourse> TeachersClassCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.FK_ClassId);

            modelBuilder.Entity<ClassCourse>()
                .HasOne(cc => cc.Classes)
                .WithMany(c => c.ClassCourses)
                .HasForeignKey(cc => cc.FK_ClassId);

            modelBuilder.Entity<ClassCourse>()
                .HasOne(cc => cc.Courses)
                .WithMany(c => c.ClassCourses)
                .HasForeignKey(cc => cc.FK_CourseId);

            modelBuilder.Entity<TeacherClassCourse>()
                .HasOne(tcc => tcc.Teachers)
                .WithMany(t => t.TeacherClassCourses)
                .HasForeignKey(tcc => tcc.FK_TeacherId);

            modelBuilder.Entity<TeacherClassCourse>()
                .HasOne(tcc => tcc.Classes)
                .WithMany(c => c.TeacherClassCourses)
                .HasForeignKey(tcc => tcc.FK_ClassId);

            modelBuilder.Entity<TeacherClassCourse>()
                .HasOne(tcc => tcc.Courses)
                .WithMany(c => c.TeacherClassCourses)
                .HasForeignKey(tcc => tcc.FK_CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}