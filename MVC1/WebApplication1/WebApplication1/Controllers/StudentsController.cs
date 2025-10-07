using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class StudentsController : Controller
    {
       // Students\ShowAll
        public IActionResult ShowAll()
        {
            StudentBL studentBl = new StudentBL();
            List<Students> StudentsListModel = studentBl.GetAll();
            return View("ShowAll",StudentsListModel);
        }
        public IActionResult Details (int id)
        {
            StudentBL studentBl = new StudentBL();
            Students studentModel = studentBl.GetById(id);
            return View("ShowDetails",studentModel);
            // view showdetails  == model student (only one )
        }
    }
}
