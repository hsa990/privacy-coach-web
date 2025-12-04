using Microsoft.AspNetCore.Mvc;

namespace Privacy_Coach.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            // Retrieve username from TempData (fake login)
            ViewBag.Username = TempData["Username"] ?? "Guest User";

            // Retrieve last quiz score
            ViewBag.Score = TempData["LatestScore"] ?? "No quiz taken yet";

            return View();
        }
    }
}
