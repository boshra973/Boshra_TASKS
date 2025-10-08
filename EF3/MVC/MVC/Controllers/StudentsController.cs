using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Filters;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Linq;
namespace MVC.Controllers
{
    [Authorize]   
    // this excutes automatically -- note; it can be placed on specific ations 
    public class StudentsController : Controller
    {
        private readonly IReadableRepository<Student> _readRepo;
        private readonly IWritableRepository<Student> _writeRepo;
        private readonly IReadableRepository<Department> _deptRepo;

        public StudentsController(
            IReadableRepository<Student> readRepo,
            IWritableRepository<Student> writeRepo,
            IReadableRepository<Department> deptRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _deptRepo = deptRepo;
        }

        //list
        public IActionResult List(string search)
        {
            var students = _readRepo.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.Name.Contains(search));
            }

            ViewBag.Search = search;
            return View(students.ToList());
        }

        //details
        public IActionResult Details(int id)
        {
            var student = _readRepo.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        //create get
        public IActionResult Create()
        {
            // Make sure Departments list is not null
            var departments = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        // create post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _writeRepo.Add(student);
                return RedirectToAction(nameof(List));
            }

            var departments = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", student.DeptId);
            return View(student);
        }

        // edit get
        public IActionResult Edit(int id)
        {
            var student = _readRepo.GetById(id);
            if (student == null) return NotFound();

            var departments = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", student.DeptId);
            return View(student);
        }

        // edit post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _writeRepo.Update(student);
                return RedirectToAction(nameof(List));
            }

            var departments = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", student.DeptId);
            return View(student);
        }

        // delete
        public IActionResult Delete(int id)
        {
            var student = _readRepo.GetById(id);
            if (student == null) return NotFound();

            _writeRepo.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
