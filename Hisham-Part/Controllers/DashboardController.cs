using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        int score = 0;

        if (TempData["QuizScore"] != null)
        {
            score = Convert.ToInt32(TempData["QuizScore"]);
        }

        ViewBag.Score = score;

        return View();
    }
}
