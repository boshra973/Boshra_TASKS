using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // public, not static , can't be overload
        // in url: Home/fn_name
        public string ShowMsg()
        {
            return "Hello world";
        }
        public ViewResult showview()
        {
            // declare , initialize, return 
            ViewResult result = new ViewResult();
            result.ViewName = "view1"; // this name must match the view name you did  
            return result;
        }

        public IActionResult showMix(int id, string name )
        {
            if (id %2==0)
            {
                return View("view1");
            }
            else
            {

                return Content("Hllowold ");
            }

        }

        //public  ViewResult view(string viewName)
        //{
        //    ViewResult viewResult = new ViewResult();
        //    viewResult.ViewName = viewName;
        //    return viewResult;
        //}
        // methods inside controllers: action 
        // Action Return type
        // strings --> contentResult
        // views --> viewResult
        // Json--> JsonResult
        // file, notfound , unouthorized ..

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
