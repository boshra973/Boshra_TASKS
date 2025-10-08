using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        ITIContext context = new ITIContext();

        // ---------- LIST ----------
        public IActionResult List(string search)
        {
            var students = context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.Name.Contains(search));
            }

            ViewBag.Search = search;
            return View(students.ToList());
        }

        // ---------- DETAILS ----------
        public IActionResult Details(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // ---------- CREATE GET ----------
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");
            return View();
        }

        // ---------- CREATE POST ----------
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

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");
            return View(student);
        }

        // ---------- EDIT GET ----------
        public IActionResult Edit(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name", student.DeptId);
            return View(student);
        }

        // ---------- EDIT POST ----------
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

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name", student.DeptId);
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
