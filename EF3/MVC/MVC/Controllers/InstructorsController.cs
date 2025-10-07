using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class InstructorsController : Controller
    {
        ITIContext context = new ITIContext();

        // LIST
        public IActionResult List()
        {
            var instructors = context.Instructors.ToList();
            return View(instructors);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.ToList();
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = context.Departments.ToList();
            return View(instructor);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null) return NotFound();

            ViewBag.Departments = context.Departments.ToList();
            return View(instructor);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Update(instructor);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = context.Departments.ToList();
            return View(instructor);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null) return NotFound();

            context.Instructors.Remove(instructor);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
