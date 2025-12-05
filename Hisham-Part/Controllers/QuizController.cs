using Microsoft.AspNetCore.Mvc;

namespace Privacy_Coach.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitQuiz(
            int? q1, int? q2, int? q3, int? q4, int? q5,
            int? q6, int? q7, int? q8, int? q9, int? q10)
        {
            // Prevent null values (if user skips question)
            int score =
                (q1 ?? 0) + (q2 ?? 0) + (q3 ?? 0) + (q4 ?? 0) + (q5 ?? 0) +
                (q6 ?? 0) + (q7 ?? 0) + (q8 ?? 0) + (q9 ?? 0) + (q10 ?? 0);

            // Max score is 20 → convert to 10 points scale
            double normalizedScore = (score / 20.0) * 10.0;

            // Round to nearest 1 decimal
            normalizedScore = Math.Round(normalizedScore, 1);

            TempData["QuizScore"] = normalizedScore;

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
