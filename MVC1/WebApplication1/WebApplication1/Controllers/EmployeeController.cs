using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Models;
using MVC1.ViewModel;

namespace MVC1.Controllers
{
    public class EmployeeController : Controller
    {
        AinShamsContext context = new AinShamsContext();

        public EmployeeController()
        {

        }
        public IActionResult Details(int id)
        {
            string msg = "Hello from Action";
            int temp = 50;
            List<string> branches = new List<string>();
            branches.Add("cairo");
            branches.Add("Alex");
            branches.Add("Mansoura");
            // additional info to be sent to the view from the action 

            // now we send 4 things: model msg temp branch list 
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["branch"] = branches;
            ViewData["Color"] = "Blue";
            ViewBag.Color = "red";

            var EmpModel = context.Employee.FirstOrDefault(e => e.Id == id);

            return View("Details", EmpModel);
        }

        public IActionResult DetailsVM(int id)
        {
            Employee empMOdel = context.Employee
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);
            List<string> branches = new List<string>();
            branches.Add("cairo");
            branches.Add("Alex");
            branches.Add("Mansoura");
            // declare 
            EmpDeptColorTempMsgBranchViewModel EmpVM = new EmpDeptColorTempMsgBranchViewModel();


            // mapping 
            EmpVM.EmpName = empMOdel.Name;
            EmpVM.DeptName = empMOdel.Department.Name;
            EmpVM.Color = "Red";
            EmpVM.Temp = 12;
            EmpVM.Msg = "Hello from VM";
            EmpVM.Branches = branches;
            return View("DetailsVM",EmpVM);
            //EmpDeptColour...
        }
    }
}
