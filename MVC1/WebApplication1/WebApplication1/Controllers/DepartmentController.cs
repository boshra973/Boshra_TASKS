using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class DepartmentController : Controller
    {
        AinShamsContext context = new AinShamsContext();
        public IActionResult Index()
        {
            List<Department> departmentList = context.Department.ToList();
            return View("Index",departmentList);
        }
    }
}
