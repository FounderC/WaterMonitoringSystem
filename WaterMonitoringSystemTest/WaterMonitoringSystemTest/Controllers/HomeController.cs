using Microsoft.AspNetCore.Mvc;

namespace WaterMonitoringSystemTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("LoginPrompt");
            else
                return View("MonitoringPrompt");
        }
    }
}