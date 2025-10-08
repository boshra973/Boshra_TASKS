using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Linq;

namespace MVC.Controllers
{
    //only admin and HR, insturctor
    [Authorize(Roles = "Admin,HR,Instructor")]
    public class InstructorsController : Controller
    {
        private readonly IReadableRepository<Instructor> _readRepo;
        private readonly IWritableRepository<Instructor> _writeRepo;
        private readonly IReadableRepository<Department> _deptRepo;

        public InstructorsController(
            IReadableRepository<Instructor> readRepo,
            IWritableRepository<Instructor> writeRepo,
            IReadableRepository<Department> deptRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _deptRepo = deptRepo;
        }

        // list
        public IActionResult List()
        {
            var instructors = _readRepo.GetAll().ToList();
            return View(instructors);
        }

        // details
        public IActionResult Details(int id)
        {
            var instructor = _readRepo.GetById(id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // create get
        public IActionResult Create()
        {
            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(depts, "Id", "Name");
            return View();
        }

        // create post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _writeRepo.Add(instructor);
                return RedirectToAction(nameof(List));
            }

            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(depts, "Id", "Name", instructor.DeptId);
            return View(instructor);
        }

        //edit get
        public IActionResult Edit(int id)
        {
            var instructor = _readRepo.GetById(id);
            if (instructor == null) return NotFound();

            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(depts, "Id", "Name", instructor.DeptId);
            return View(instructor);
        }

        // edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Instructor instructor)
        {
            if (id != instructor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _writeRepo.Update(instructor);
                return RedirectToAction(nameof(List));
            }

            var depts = _deptRepo.GetAll()?.ToList() ?? new List<Department>();
            ViewBag.Departments = new SelectList(depts, "Id", "Name", instructor.DeptId);
            return View(instructor);
        }

        // delete
        public IActionResult Delete(int id)
        {
            var instructor = _readRepo.GetById(id);
            if (instructor == null) return NotFound();

            _writeRepo.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
