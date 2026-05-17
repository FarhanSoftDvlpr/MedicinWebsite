using MEDICINE.WEB.Attributes;
using MEDICINE.WEB.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MEDICINE.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]

    [ServiceFilter(typeof(AdminAuthorizationFilter))]

    [Permission("DASHBOARD_VIEW")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}