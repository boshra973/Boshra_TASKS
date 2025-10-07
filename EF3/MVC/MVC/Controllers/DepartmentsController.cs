using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult List()
        {
            var departments = context.Departments.ToList();
            return View(departments);
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
        // this displays teh create view 
        public IActionResult Create(Department department)
        {
            // submit our addings 
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                // save this to the daatabase 
                context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(department);
        }

        // Edit GET
        public IActionResult Edit(int id)
        {
            // edit something : say what you want to edit 
            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        // Edit post
        // post the edits yo u got 
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
            // handeld in the list view

            var department = context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
