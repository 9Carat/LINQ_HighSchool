using LINQ_HighSchool4.Models;
using LINQ_HighSchool4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LINQ_HighSchool4.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SchoolController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<SchoolViewModel> list = new List<SchoolViewModel>();

            var items = await(from cl in _context.Classes
                              join s in _context.Students on cl.ClassId equals s.FK_ClassId
                              join cc in _context.ClassCourses on cl.ClassId equals cc.FK_ClassId
                              join co in _context.Courses on cc.FK_CourseId equals co.CourseId
                              join tc in _context.TeachersCourses on co.CourseId equals tc.FK_CourseId
                              join t in _context.Teachers on tc.FK_TeacherId equals t.TeacherID
                              join tcc in _context.TeachersClassCourses on t.TeacherID equals tcc.FK_TeacherId
                              where t.TeacherID == tcc.FK_TeacherId && cl.ClassId == tcc.FK_ClassId
                              select new
                              {
                                  StudentFName = s.FirstName,
                                  StudentLName = s.LastName,
                                  ClassName = cl.ClassName,
                                  CourseName = co.CourseName,
                                  TeacherFName = t.FirstName,
                                  TeacherLName = t.LastName,
                              }).ToListAsync();

            foreach (var item in items)
            {
                SchoolViewModel listItem = new SchoolViewModel();
                listItem.StudentFName = item.StudentFName;
                listItem.StudentLName = item.StudentLName;
                listItem.ClassName = item.ClassName;
                listItem.CourseName = item.CourseName;
                listItem.TeacherFName = item.TeacherFName;
                listItem.TeacherLName = item.TeacherLName;
                list.Add(listItem);
            }

            return View(list);
        }

        public async Task<IActionResult> Teacher()
        {
            return View();
        }


        public async Task<IActionResult> DisplayTeacher(string CourseName)
        {
            List<SchoolViewModel> list = new List<SchoolViewModel>();

            var items = await (from t in _context.Teachers
                               join tc in _context.TeachersCourses on t.TeacherID equals tc.FK_TeacherId
                               join co in _context.Courses on tc.FK_CourseId equals co.CourseId
                               where co.CourseName == CourseName
                               select new
                               {
                                   TeacherFName = t.FirstName,
                                   TeacherLName = t.LastName,
                                   CourseName = co.CourseName
                               }).ToListAsync();

            foreach (var item in items)
            {
                SchoolViewModel listItem = new SchoolViewModel();
                listItem.TeacherFName = item.TeacherFName;
                listItem.TeacherLName = item.TeacherLName;
                listItem.CourseName = item.CourseName;
                list.Add(listItem);
            }

            return View(list);
        }

        public async Task<IActionResult> Students()
        {
            return View();
        }

        public async Task<IActionResult> DisplayStudents(string ClassName)
        {
            List<SchoolViewModel> list = new List<SchoolViewModel>();

            var items = await (from cl in _context.Classes
                               join s in _context.Students on cl.ClassId equals s.FK_ClassId
                               join cc in _context.ClassCourses on cl.ClassId equals cc.FK_ClassId
                               join co in _context.Courses on cc.FK_CourseId equals co.CourseId
                               join tc in _context.TeachersCourses on co.CourseId equals tc.FK_CourseId
                               join t in _context.Teachers on tc.FK_TeacherId equals t.TeacherID
                               join tcc in _context.TeachersClassCourses on t.TeacherID equals tcc.FK_TeacherId
                               where t.TeacherID == tcc.FK_TeacherId && cl.ClassId == tcc.FK_ClassId && cl.ClassName == ClassName
                               select new
                               {
                                   StudentFName = s.FirstName,
                                   StudentLName = s.LastName,
                                   ClassName = cl.ClassName,
                                   CourseName = co.CourseName,
                                   TeacherFName = t.FirstName,
                                   TeacherLName = t.LastName,
                               }).ToListAsync();

            foreach (var item in items)
            {
                SchoolViewModel listItem = new SchoolViewModel();
                listItem.StudentFName = item.StudentFName;
                listItem.StudentLName = item.StudentLName;
                listItem.ClassName = item.ClassName;
                listItem.CourseName = item.CourseName;
                listItem.TeacherFName = item.TeacherFName;
                listItem.TeacherLName = item.TeacherLName;
                list.Add(listItem);
            }

            return View(list);
        }

        public IActionResult CourseName()
        {
            return View();
        }

        public async Task<IActionResult> SetCourseName(string CurrentCourseName, string NewCourseName)
        {
            var course = (from co in _context.Courses
                          where co.CourseName == CurrentCourseName
                          select co).FirstOrDefault();

            if (course == null)
            {
                return NotFound("Course name not found. Please try again.");
            }

            course.CourseName = NewCourseName;
            await _context.SaveChangesAsync();

            return View();
        }

        public IActionResult UpdateTeacher()
        {
            return View();
        }

        public async Task<IActionResult> SetTeacher(string ClassName, string CourseName, string TeacherLName)
        {
            var currentTeacher = (from cl in _context.Classes
                                  join s in _context.Students on cl.ClassId equals s.FK_ClassId
                                  join cc in _context.ClassCourses on cl.ClassId equals cc.FK_ClassId
                                  join co in _context.Courses on cc.FK_CourseId equals co.CourseId
                                  join tc in _context.TeachersCourses on co.CourseId equals tc.FK_CourseId
                                  join t in _context.Teachers on tc.FK_TeacherId equals t.TeacherID
                                  join tcc in _context.TeachersClassCourses on t.TeacherID equals tcc.FK_TeacherId
                                  where t.TeacherID == tcc.FK_TeacherId && cl.ClassId == tcc.FK_ClassId && co.CourseName == CourseName && cl.ClassName == ClassName
                                  select t).FirstOrDefault();

            var newTeacher = (from t in _context.Teachers
                              where t.LastName == TeacherLName
                              select t).FirstOrDefault();

            var updateTeacher = (from tcc in _context.TeachersClassCourses
                                 where tcc.FK_TeacherId == currentTeacher.TeacherID
                                 select tcc).FirstOrDefault();

            updateTeacher.FK_TeacherId = newTeacher.TeacherID;
            await _context.SaveChangesAsync();

            return View();
        }
    }
}
