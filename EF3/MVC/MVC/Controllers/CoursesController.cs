using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class CoursesController : Controller
    {
        ITIContext context = new ITIContext();

        // LIST with Search
        public IActionResult List(string search)
        {
            var courses = context.Courses
                                 .Include(c => c.Department)
                                 .Include(c => c.Instructor)
                                 .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                courses = courses.Where(c => c.Name.Contains(search));
            }

            ViewBag.Search = search;
            return View(courses.ToList());
        }

        public IActionResult Details(int id)
        {
            var course = context.Courses
                                .Include(c => c.Department)
                                .Include(c => c.Instructor)
                                .FirstOrDefault(c => c.Id == id);

            if (course == null) return NotFound();
            return View(course);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Instructors = context.Instructors.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Instructors = context.Instructors.ToList();
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Instructors = context.Instructors.ToList();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id) return NotFound();

            if (ModelState.IsValid)
            {
                context.Courses.Update(course);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Instructors = context.Instructors.ToList();
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
