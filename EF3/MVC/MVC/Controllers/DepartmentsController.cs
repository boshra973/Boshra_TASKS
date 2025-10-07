using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        ITIContext context = new ITIContext();

        // LIST with Search
        public IActionResult List(string search)
        {
            var departments = context.Departments.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                departments = departments
                    .Where(d => d.Name.Contains(search) || d.ManagerName.Contains(search));
            }

            ViewBag.Search = search; // keep the text in the search box
            return View(departments.ToList());
        }

        public IActionResult Details(int id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        // Create GET
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(department);
        }

        // Edit GET
        public IActionResult Edit(int id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id) return NotFound();
            if (ModelState.IsValid)
            {
                context.Departments.Update(department);
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}
