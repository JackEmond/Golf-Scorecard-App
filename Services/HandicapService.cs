using Microsoft.EntityFrameworkCore;
using MvcGolfScorecardApp.Data;
using System.Diagnostics;

namespace MvcGolfScorecardApp.Services
{
    public class HandicapService
    {
        private readonly MvcGolfScorecardAppContext _context;

        public HandicapService(MvcGolfScorecardAppContext context)
        {
            _context = context; // Dependency injection for database context
        }

        public double CalculateHandicap() 
        {
            var scorecard = getScorecards();
           
          


            return 2.2;
            //return calculatedHandicap;
        }

        private string getScorecards()
        {
            var scorecard = _context.Scorecard
         .Include(s => s.Course)
         .AsNoTracking();

            ///Switch above to get the score (from Scorecard),
            ///and the rating and slope (from Course)
            //Then pass them back to the differentials

            Console.WriteLine("Debug " + scorecard);
            Debug.WriteLine("Debug " + scorecard);

            return "NOT DONE YET";
        }

        public Array[] calculateDifferentials()
        {




            return new Array[1];
        }
    }
}
