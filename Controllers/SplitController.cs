using Microsoft.AspNetCore.Mvc;
using ProgressTracker.Models;

namespace ProgressTracker.Controllers
{
    public class SplitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       // get value on other side of "="
        public IActionResult ByCategory(string name)
        {
            ViewData["Category"] = name;
            var movements = new List<Movement>();
            for(int i=1; i<=10; i++)
            {
             movements.Add(new Movement {  MovementId = i, Name = "Movement" + i.ToString(), Reps=8  });   
            }
            //send products to view
            return View(movements);
        }
    }
}
