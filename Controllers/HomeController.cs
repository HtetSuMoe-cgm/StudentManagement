using Microsoft.AspNetCore.Mvc;

namespace LoginAndCRUDCoreProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
