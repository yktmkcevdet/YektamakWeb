using Microsoft.AspNetCore.Mvc;

namespace FinansalTakipWebApiCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
