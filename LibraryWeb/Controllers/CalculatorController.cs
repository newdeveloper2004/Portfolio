using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
