using MEDICINE.WEB.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MEDICINE.WEB.Controllers
{
    public class PasswordTestController : Controller
    {
        public IActionResult Index()
        {
            var passwordHelper = new PasswordHelper();

            var hash = passwordHelper.HashPassword("Admin@1234567891011121345151617181920");

            return Content(hash);
        }
    }
}