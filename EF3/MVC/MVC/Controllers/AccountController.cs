using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Security.Claims;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        // using the repository not eh database 
        private readonly IReadableRepository<Instructor> _instrRepo;

        public AccountController(IReadableRepository<Instructor> instrRepo)
        {
            _instrRepo = instrRepo;
        }

        // get: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            //login model
            return View(new MVC.Models.LoginModel());
        }

        // post: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    // put new claim 
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, model.Role)
                };

                //  role is Instructor so add their id as  claim
                if (model.Role == "Instructor")
                {
                    var instructor = _instrRepo.GetAll().FirstOrDefault(i => i.Name == model.Username);
                    if (instructor != null)
                    {
                        claims.Add(new Claim("InstructorId", instructor.Id.ToString()));
                    }
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Redirect based on role
                //only students goes to students 
                if (model.Role == "Student")
                    return RedirectToAction("List", "Students");
                 // hr, instructor, admin 
                else
                    return RedirectToAction("Dashboard", "Account"); // Admin/HR landing page
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        // post: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }

    //  user model 
    public class LoginModel
    {
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
