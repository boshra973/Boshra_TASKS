using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class CourseStudentsController : Controller
    {
        ITIContext context = new ITIContext();

        // List
        public IActionResult List()
        {
            var courseStudents = context.CourseStudents
                .Select(cs => new CourseStudents
                {
                    StudentId = cs.StudentId,
                    CourseId = cs.CourseId,
                    Degree = cs.Degree,
                    Student = cs.Student,
                    Course = cs.Course
                })
                .ToList();

            return View(courseStudents);
        }

        // Details
        public IActionResult Details(int id)
        {
            var cs = context.CourseStudents
                .FirstOrDefault(c => c.CourseStudentsId == id);
            if (cs == null) return NotFound();

            return View(cs);
        }

        // Create GET
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseStudents courseStudent)
        {
            if (ModelState.IsValid)
            {
                context.CourseStudents.Add(courseStudent);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(courseStudent);
        }

        // Edit GET
        public IActionResult Edit(int id)
        {
            var cs = context.CourseStudents.FirstOrDefault(c => c.CourseStudentsId == id);
            if (cs == null) return NotFound();
            return View(cs);
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CourseStudents courseStudent)
        {
            if (id != courseStudent.CourseStudentsId) return NotFound();
            if (ModelState.IsValid)
            {
                context.CourseStudents.Update(courseStudent);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(courseStudent);
        }

        // Delete GET
        public IActionResult Delete(int id)
        {
            var cs = context.CourseStudents.FirstOrDefault(c => c.CourseStudentsId == id);
            if (cs == null) return NotFound();

            context.CourseStudents.Remove(cs);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
