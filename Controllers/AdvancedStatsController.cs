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

            var totalNumberOfStrokes = _context.Scorecard.Sum(s => (int)(s.HoleOne + s.HoleTwo + s.HoleThree + s.HoleFour + s.HoleFive + s.HoleSix + s.HoleSeven + s.HoleEight + s.HoleNine + s.HoleTen + s.HoleEleven + s.HoleTwelve + s.HoleThirteen + s.HoleFourteen + s.HoleFifteen + s.HoleSixteen + s.HoleSeventeen + s.HoleEighteen));

            var statsViewModel = new AdvancedStats
            {
                TotalNumberOfStrokes = totalNumberOfStrokes,
                AverageScorePar3 = getAverageScorePar(3),
                AverageScorePar4 = getAverageScorePar(4),
                AverageScorePar5 = getAverageScorePar(5),
            };

            return View(statsViewModel);
        }

        private double getAverageScorePar(int par)
        {
             var averageScore =  _context.Scorecard
                .Select(s => new
                {
                    s.Course,
                    scorecard = s
                })
                .AsEnumerable() // Switching to client-side evaluation for the complex conditional logic
            .SelectMany(s => new List<int?>
            {
                s.Course.HoleOne == par ? s.scorecard.HoleOne : (int?)null,
                s.Course.HoleTwo == par ? s.scorecard.HoleTwo : (int?)null,
                s.Course.HoleThree == par ? s.scorecard.HoleThree : (int?)null,
                s.Course.HoleFour == par ? s.scorecard.HoleFour : (int?)null,
                s.Course.HoleFive == par ? s.scorecard.HoleFive : (int?)null,
                s.Course.HoleSix == par ? s.scorecard.HoleSix : (int?)null,
                s.Course.HoleSeven == par ? s.scorecard.HoleSeven : (int?)null,
                s.Course.HoleEight == par ? s.scorecard.HoleEight : (int?)null,
                s.Course.HoleNine == par ? s.scorecard.HoleNine : (int?)null,
                s.Course.HoleTen == par ? s.scorecard.HoleTen : (int?)null,
                s.Course.HoleEleven == par ? s.scorecard.HoleEleven : (int?)null,
                s.Course.HoleTwelve == par ? s.scorecard.HoleTwelve : (int?)null,
                s.Course.HoleThirteen == par ? s.scorecard.HoleThirteen : (int?)null,
                s.Course.HoleFourteen == par ? s.scorecard.HoleFourteen : (int?)null,
                s.Course.HoleFifteen == par ? s.scorecard.HoleFifteen : (int?)null,
                s.Course.HoleSixteen == par ? s.scorecard.HoleSixteen : (int?)null,
                s.Course.HoleSeventeen == par ? s.scorecard.HoleSeventeen : (int?)null,
                s.Course.HoleEighteen == par ? s.scorecard.HoleEighteen : (int?)null
            })
            .Where(score => score.HasValue) 
            .DefaultIfEmpty()
            .Average(score => score ?? 0);
        
            return Math.Round(averageScore, 2);
        }



    }
}

