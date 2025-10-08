using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Linq;

namespace MVC.Controllers
{
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

        //list
        public IActionResult List(string search)
        {
            var courses = _readRepo.GetAll().AsQueryable(); 

            if (!string.IsNullOrEmpty(search))
                courses = courses.Where(c => c.Name.Contains(search));

            // get the selected course 
            //nullability
            int? selectedCourseId = HttpContext.Session.GetInt32("SelectedCourseId");
            ViewBag.SelectedCourseId = selectedCourseId;

            return View(courses.ToList());
        }

        // details
        public IActionResult Details(int id)
        {
            var course = _readRepo.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        // create (get)
        public IActionResult Create()
        {
            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            var instrs = _instrRepo.GetAll()?.ToList() ?? new List<Instructor>();

            ViewBag.Departments = new SelectList(depts, "Id", "Name");
            ViewBag.Instructors = new SelectList(instrs, "Id", "Name");
            return View();
        }

        // post: (after get) create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _writeRepo.Add(course);
                return RedirectToAction(nameof(List));
            }

            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            var instrs = _instrRepo.GetAll()?.ToList() ?? new List<Instructor>();

            ViewBag.Departments = new SelectList(depts, "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(instrs, "Id", "Name", course.InstructorId);
            return View(course);
        }

        // edit (get)
        public IActionResult Edit(int id)
        {
            var course = _readRepo.GetById(id);
            if (course == null) return NotFound();

            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            var instrs = _instrRepo.GetAll()?.ToList() ?? new List<Instructor>();

            ViewBag.Departments = new SelectList(depts, "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(instrs, "Id", "Name", course.InstructorId);
            return View(course);
        }

        //psot edit 
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

            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            var instrs = _instrRepo.GetAll()?.ToList() ?? new List<Instructor>();

            ViewBag.Departments = new SelectList(depts, "Id", "Name", course.DeptId);
            ViewBag.Instructors = new SelectList(instrs, "Id", "Name", course.InstructorId);
            return View(course);
        }

        // delete
        public IActionResult Delete(int id)
        {
            var course = _readRepo.GetById(id);
            if (course == null) return NotFound();

            _writeRepo.Delete(id);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Join(int courseId)
        {
            // Store selected course in session
            HttpContext.Session.SetInt32("SelectedCourseId", courseId);

            return RedirectToAction(nameof(List)); // return back to course list
        }
    }
}
