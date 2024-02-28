using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcGolfScorecardApp.Data;
using MvcGolfScorecardApp.Models;

namespace MvcGolfScorecardApp.Controllers
{
    public class AdvancedStatsController : Controller
    {
        private readonly MvcGolfScorecardAppContext _context;

        public AdvancedStatsController(MvcGolfScorecardAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var TotalNumberOfStrokes = _context.Scorecard.Sum(s => (int)(s.HoleOne + s.HoleTwo + s.HoleThree + s.HoleFour + s.HoleFive + s.HoleSix + s.HoleSeven + s.HoleEight + s.HoleNine + s.HoleTen + s.HoleEleven + s.HoleTwelve + s.HoleThirteen + s.HoleFourteen + s.HoleFifteen + s.HoleSixteen + s.HoleSeventeen + s.HoleEighteen));


            var AverageScorePar3 = getAverageScorePar3();



            var statsViewModel = new AdvancedStats
            {

                TotalNumberOfStrokes = TotalNumberOfStrokes,
                AverageScorePar3 = AverageScorePar3
            };

            return View(statsViewModel);
        }

        private double getAverageScorePar3()
        {
            return _context.Scorecard
                .Select(s => new
                {
                    s.Course,
                    s
                })
                .AsEnumerable() // Switching to client-side evaluation for the complex conditional logic
            .SelectMany(s => new List<int?>
            {
                s.Course.HoleOne == 4 ? s.s.HoleOne : (int?)null,
                s.Course.HoleTwo == 4 ? s.s.HoleTwo : (int?)null,
                s.Course.HoleThree == 4 ? s.s.HoleThree : (int?)null,
                s.Course.HoleEighteen == 4 ? s.s.HoleEighteen : (int?)null
            })
            .Where(score => score.HasValue) 
            .DefaultIfEmpty()
            .Average(score => score ?? 0);
        }


    }
}

