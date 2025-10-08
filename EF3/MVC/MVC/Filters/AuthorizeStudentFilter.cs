using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
    public class AuthorizeStudentFilter : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // if the user is authenticated or not 
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // when not logged in : go to login page
                context.Result
                    = new RedirectToActionResult("Login", "Account", null);

            }
        }
     
    }
}
