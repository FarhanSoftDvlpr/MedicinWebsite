using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MEDICINE.WEB.Filters
{
    public class AdminAuthorizationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Account",
                    new { area = "Admin" }
                );
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}