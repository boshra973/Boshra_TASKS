using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        ITIContext context = new ITIContext();

        // LIST with Search
        public IActionResult List(string search)
        {
            var students = context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s =>
                    s.Name.Contains(search) ||
                    s.Address.Contains(search));
            }

            ViewBag.Search = search;
            return View(students.ToList());
        }

        public IActionResult Details(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

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
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();
            if (ModelState.IsValid)
            {
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(student);
        }

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
