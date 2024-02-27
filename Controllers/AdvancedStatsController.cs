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


            var AverageScorePar3 = _context.Scorecard.Sum(s => (int)(s.HoleOne + s.HoleTwo));

            var statsViewModel = new AdvancedStats
            {
              
                TotalNumberOfStrokes = TotalNumberOfStrokes,
                AverageScorePar3 = AverageScorePar3
            };

            return View(statsViewModel);
        }
    }
}
