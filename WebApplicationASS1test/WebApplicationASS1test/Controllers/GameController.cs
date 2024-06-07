using Microsoft.AspNetCore.Mvc;

namespace WebApplicationASS1test.Controllers
{
    public class GameController : Controller
    {
        private const string SessionRandomNumberKey = "RandomNumber";
        private const string SessionGuessCountKey = "GuessCount";
        private const string HighScoresKey = "HighScores";

        [HttpGet]
        public IActionResult Index()
        {
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionRandomNumberKey)))
            {
                var random = new Random();
                HttpContext.Session.SetString(SessionRandomNumberKey, random.Next(1, 101).ToString());
            }

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionGuessCountKey)))
            {
                HttpContext.Session.SetString(SessionGuessCountKey, "0");
            }
            ViewBag.HighScores = GetHighScores();
            return View();
        }

        [HttpPost]
        public IActionResult Index(int guess)
        {

            
            string sessionRandomNumber = HttpContext.Session.GetString(SessionRandomNumberKey);
            int randomNumber;
            
            if (string.IsNullOrEmpty(sessionRandomNumber))
            {
                randomNumber = new Random().Next(1, 101);
                HttpContext.Session.SetString(SessionRandomNumberKey, randomNumber.ToString());
            }
            else
            {
                randomNumber = int.Parse(sessionRandomNumber);
            }


            int guessCount = int.Parse(HttpContext.Session.GetString(SessionGuessCountKey));
            if (guessCount == int.MinValue)
            {
                guessCount = 0;
            }

            guessCount++;
            HttpContext.Session.SetString(SessionGuessCountKey, guessCount.ToString());

           
            if (guess == randomNumber)
            {
                ViewBag.Message = $"Congratulations! You guessed the number {randomNumber} in {guessCount} attempts.";
                HttpContext.Session.SetString(SessionRandomNumberKey, new Random().Next(1, 101).ToString());
                HttpContext.Session.SetString(SessionGuessCountKey, "0");
                UpdateHighScores(guessCount);
            }
            else if (guess < randomNumber)
            {
                ViewBag.Message = "Your guess is too low.";
            }
            else
            {
                ViewBag.Message = "Your guess is too high.";
            }

            ViewBag.GuessCount = guessCount;
            ViewBag.HighScores = GetHighScores();
            return View();
        }
        private List<int> GetHighScores()
        {
            var cookie = Request.Cookies[HighScoresKey];
            if (cookie != null && !string.IsNullOrEmpty(cookie))
            {
                var highScores = cookie.Split(',').Select(int.Parse).ToList();
                //Console.WriteLine($"Retrieved high scores: {string.Join(", ", highScores)}");
                return highScores;
            }
            return new List<int>();
        }


        private void UpdateHighScores(int guessCount)
        {
            var highScores = GetHighScores();
            highScores.Add(guessCount);
            highScores.Sort();
            highScores = highScores.Take(5).ToList(); 

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(1)
            };
            Response.Cookies.Append(HighScoresKey, string.Join(",", highScores), cookieOptions);
        }
    }
}
