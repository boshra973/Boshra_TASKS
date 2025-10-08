using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class CoursesController : Controller
    {
        ITIContext context = new ITIContext();

        // ---------- LIST (with search) ----------

        public IActionResult List(string search)
        {
            var courses = context.Courses
                // we want the departments and instructors to apper
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
        // ---------- DETAILS ----------
        public IActionResult Details(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        // ---------- CREATE GET ----------
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name");
            ViewBag.Instructors = new SelectList(context.Instructors.ToList(), "Id", "Name");
            return View();
        }

        // ---------- CREATE POST ----------
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

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(context.Instructors.ToList(), "Id", "Name", course.InstructorId);
            return View(course);
        }

        // ---------- EDIT GET ----------
        public IActionResult Edit(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(context.Instructors.ToList(), "Id", "Name", course.InstructorId);
            return View(course);
        }

        // ---------- EDIT POST ----------
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

            ViewBag.Departments = new SelectList(context.Departments.ToList(), "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(context.Instructors.ToList(), "Id", "Name", course.InstructorId);
            return View(course);
        }

        // ---------- DELETE ----------
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
