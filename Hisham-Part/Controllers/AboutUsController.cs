using Microsoft.AspNetCore.Mvc;

namespace Privacy_Coach.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
