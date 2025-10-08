using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace MVC.Controllers
{
    // All roles can access courses
    [Authorize(Roles = Roles.Admin + "," + Roles.Instructor + "," + Roles.Student + "," + Roles.HR)]
    public class CoursesController : Controller
    {
        private readonly IReadableRepository<Course> _readRepo;
        private readonly IWritableRepository<Course> _writeRepo;
        private readonly IReadableRepository<Department> _deptRepo;
        private readonly IReadableRepository<Instructor> _instrRepo;

        public CoursesController(
            IReadableRepository<Course> readRepo,
            IWritableRepository<Course> writeRepo,
            IReadableRepository<Department> deptRepo,
            IReadableRepository<Instructor> instrRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _deptRepo = deptRepo;
            _instrRepo = instrRepo;
        }

        // General List view
        public IActionResult List(string search)
        {
            var courses = _readRepo.GetAll().AsQueryable();

            // Filter by search
            if (!string.IsNullOrEmpty(search))
                courses = courses.Where(c => c.Name.Contains(search));

            // Show only instructor courses if logged in as Instructor
            if (User.IsInRole("Instructor"))
            {
                int instructorId = GetCurrentInstructorId();
                if (instructorId > 0)
                {
                    courses = courses.Where(c => c.InstructorId == instructorId);
                }
            }

            ViewBag.Search = search;
            return View(courses.ToList());
        }

        // Helper to get current instructor ID from claims
        private int GetCurrentInstructorId()
        {
            var idClaim = User.Claims.FirstOrDefault(c => c.Type == "InstructorId")?.Value;
            return int.TryParse(idClaim, out var id) ? id : 0;
        }

        // Details
        public IActionResult Details(int id)
        {
            var course = _readRepo.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        // Create (get)
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_deptRepo.GetAll()?.ToList() ?? new List<Department>(), "Id", "Name");
            ViewBag.Instructors = new SelectList(_instrRepo.GetAll()?.ToList() ?? new List<Instructor>(), "Id", "Name");
            return View();
        }

        // Create (post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _writeRepo.Add(course);
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = new SelectList(_deptRepo.GetAll()?.ToList() ?? new List<Department>(), "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(_instrRepo.GetAll()?.ToList() ?? new List<Instructor>(), "Id", "Name", course.InstructorId);
            return View(course);
        }

        // Edit (get)
        public IActionResult Edit(int id)
        {
            var course = _readRepo.GetById(id);
            if (course == null) return NotFound();

            ViewBag.Departments = new SelectList(_deptRepo.GetAll()?.ToList() ?? new List<Department>(), "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(_instrRepo.GetAll()?.ToList() ?? new List<Instructor>(), "Id", "Name", course.InstructorId);
            return View(course);
        }

        // Edit (post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _writeRepo.Update(course);
                return RedirectToAction(nameof(List));
            }

            ViewBag.Departments = new SelectList(_deptRepo.GetAll()?.ToList() ?? new List<Department>(), "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(_instrRepo.GetAll()?.ToList() ?? new List<Instructor>(), "Id", "Name", course.InstructorId);
            return View(course);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var course = _readRepo.GetById(id);
            if (course == null) return NotFound();

            _writeRepo.Delete(id);
            return RedirectToAction(nameof(List));
        }

        // Join course (for session)
        public IActionResult Join(int courseId)
        {
            HttpContext.Session.SetInt32("SelectedCourseId", courseId);
            return RedirectToAction(nameof(List));
        }
    }
}
