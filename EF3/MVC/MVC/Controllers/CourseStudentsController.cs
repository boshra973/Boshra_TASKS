using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Linq;

namespace MVC.Controllers
{
    public class CourseStudentsController : Controller
    {
        private readonly IReadableRepository<CourseStudents> _readRepo;
        private readonly IWritableRepository<CourseStudents> _writeRepo;
        private readonly IReadableRepository<Student> _studentRepo;
        private readonly IReadableRepository<Course> _courseRepo;

        public CourseStudentsController(
            IReadableRepository<CourseStudents> readRepo,
            IWritableRepository<CourseStudents> writeRepo,
            IReadableRepository<Student> studentRepo,
            IReadableRepository<Course> courseRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }

        // list
        public IActionResult List()
        {
            var courseStudents = _readRepo.GetAll().ToList();
            return View(courseStudents);
        }

        // details
        public IActionResult Details(int id)
        {
            var cs = _readRepo.GetById(id);
            if (cs == null) return NotFound();
            return View(cs);
        }

        // cereate get
        public IActionResult Create()
        {
            var students = _studentRepo.GetAll()?.ToList() ?? new List<Student>();
            var courses = _courseRepo.GetAll()?.ToList() ?? new List<Course>();

            ViewBag.Students = new SelectList(students, "Id", "Name");
            ViewBag.Courses = new SelectList(courses, "Id", "Name");
            return View();
        }

        // create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseStudents courseStudent)
        {
            if (ModelState.IsValid)
            {
                _writeRepo.Add(courseStudent);
                return RedirectToAction(nameof(List));
            }

            var students = _studentRepo.GetAll()?.ToList() ?? new List<Student>();
            var courses = _courseRepo.GetAll()?.ToList() ?? new List<Course>();

            ViewBag.Students = new SelectList(students, "Id", "Name", courseStudent.StudentId);
            ViewBag.Courses = new SelectList(courses, "Id", "Name", courseStudent.CourseId);
            return View(courseStudent);
        }

        // edit get
        public IActionResult Edit(int id)
        {
            var cs = _readRepo.GetById(id);
            if (cs == null) return NotFound();

            var students = _studentRepo.GetAll()?.ToList() ?? new List<Student>();
            var courses = _courseRepo.GetAll()?.ToList() ?? new List<Course>();

            ViewBag.Students = new SelectList(students, "Id", "Name", cs.StudentId);
            ViewBag.Courses = new SelectList(courses, "Id", "Name", cs.CourseId);
            return View(cs);
        }

        // edit post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CourseStudents courseStudent)
        {
            if (id != courseStudent.CourseStudentsId) return NotFound();

            if (ModelState.IsValid)
            {
                _writeRepo.Update(courseStudent);
                return RedirectToAction(nameof(List));
            }

            var students = _studentRepo.GetAll()?.ToList() ?? new List<Student>();
            var courses = _courseRepo.GetAll()?.ToList() ?? new List<Course>();

            ViewBag.Students = new SelectList(students, "Id", "Name", courseStudent.StudentId);
            ViewBag.Courses = new SelectList(courses, "Id", "Name", courseStudent.CourseId);
            return View(courseStudent);
        }

        // delete
        public IActionResult Delete(int id)
        {
            var cs = _readRepo.GetById(id);
            if (cs == null) return NotFound();

            _writeRepo.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
