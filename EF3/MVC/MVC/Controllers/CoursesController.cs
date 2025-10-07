using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class CoursesController : Controller
    {
        ITIContext context = new ITIContext();

        // LIST
        public IActionResult List()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
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
            return View(course);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Update(course);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(course);
        }

        // DELETE (direct, handled in list)
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
