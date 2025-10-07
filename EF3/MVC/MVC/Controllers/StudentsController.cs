using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        ITIContext context = new ITIContext();

        // LIST
        public IActionResult List()
        {
            var students = context.Students.ToList();
            return View(students);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
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
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            ViewBag.Departments = context.Departments.ToList();
            return View(student);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            ViewBag.Departments = context.Departments.ToList();
            return View(student);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            ViewBag.Departments = context.Departments.ToList();

            return View(student);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            context.Students.Remove(student);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
