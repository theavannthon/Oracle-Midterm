using Microsoft.AspNetCore.Mvc;

namespace OracleProjectMiedterm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
