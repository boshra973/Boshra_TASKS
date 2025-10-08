using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Linq;

namespace MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IReadableRepository<Department> _readRepo;
        private readonly IWritableRepository<Department> _writeRepo;

        public DepartmentsController(
            IReadableRepository<Department> readRepo,
            IWritableRepository<Department> writeRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        // list //search
        public IActionResult List(string search)
        {
            var departments = _readRepo.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                departments = departments
                    .Where(d => d.Name.Contains(search) || d.ManagerName.Contains(search));
            }

            ViewBag.Search = search;
            return View(departments.ToList());
        }

        // details
        public IActionResult Details(int id)
        {
            var department = _readRepo.GetById(id);
            if (department == null) return NotFound();
            return View(department);
        }

        // create get
        public IActionResult Create()
        {
            return View();
        }

        //crete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _writeRepo.Add(department);
                return RedirectToAction(nameof(List));
            }
            return View(department);
        }

        // edit get
        public IActionResult Edit(int id)
        {
            var department = _readRepo.GetById(id);
            if (department == null) return NotFound();
            return View(department);
        }

        //edit post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _writeRepo.Update(department);
                return RedirectToAction(nameof(List));
            }
            return View(department);
        }

        // delete
        public IActionResult Delete(int id)
        {
            var department = _readRepo.GetById(id);
            if (department == null) return NotFound();

            _writeRepo.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
