using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MEDICINE.WEB.Filters
{
    public class AdminAuthorizationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string? area = context.RouteData.Values["area"]?.ToString();
            string? controller = context.RouteData.Values["controller"]?.ToString();
            string? action = context.RouteData.Values["action"]?.ToString();

            if (area == "Admin" &&
                controller == "Account" &&
                action == "Login")
            {
                return;
            }

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