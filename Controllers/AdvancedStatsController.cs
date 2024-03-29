﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcGolfScorecardApp.Data;
using MvcGolfScorecardApp.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

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
            var bestScore18Holes = _context.Scorecard.Min(s => (int)(s.HoleOne + s.HoleTwo + s.HoleThree + s.HoleFour + s.HoleFive + s.HoleSix + s.HoleSeven + s.HoleEight + s.HoleNine + s.HoleTen + s.HoleEleven + s.HoleTwelve + s.HoleThirteen + s.HoleFourteen + s.HoleFifteen + s.HoleSixteen + s.HoleSeventeen + s.HoleEighteen));


            var statsViewModel = new AdvancedStats
            {
                TotalNumberOfStrokes = totalNumberOfStrokes,
                AverageScorePar3 = getAverageScorePar(3),
                AverageScorePar4 = getAverageScorePar(4),
                AverageScorePar5 = getAverageScorePar(5),
                BestScore18Holes = bestScore18Holes,
                TotalNumberOfBirdies = getTotalNumberOf(-1),
                TotalNumberOfPars = getTotalNumberOf(0),
                TotalNumberOfEagles = getTotalNumberOf(-2),
                TotalNumberOfHoleInOnes = getTotalNumberOfHoleInOnes(),
            };

            return View(statsViewModel);
        }

        private int getTotalNumberOfHoleInOnes()
        {
            return _context.Scorecard
                .AsEnumerable() 
                .Sum(s => new List<int>{
                    s.HoleOne, s.HoleTwo, s.HoleThree, s.HoleFour, s.HoleFive,
                    s.HoleSix, s.HoleSeven, s.HoleEight, s.HoleNine, s.HoleTen,
                    s.HoleEleven, s.HoleTwelve, s.HoleThirteen, s.HoleFourteen,
                    s.HoleFifteen, s.HoleSixteen, s.HoleSeventeen, s.HoleEighteen
                }.Count(shots => shots == 1));
        }

        private int getTotalNumberOf(int value)
        {
            //Get total number of pars/birdies/eagles for all scorecards
            // int value is relative relation to par ( par = 0, birdie = -1, eagle = -2)
            return _context.Scorecard
                .Select(s => new
                {
                    s.Course,
                    scorecard = s
                })
                .AsEnumerable()
                .Select(s => new{Birdies = new List<int>{
                    s.scorecard.HoleOne - s.Course.HoleOne == value? 1: 0,
                    s.scorecard.HoleTwo - s.Course.HoleTwo == value? 1: 0,
                    s.scorecard.HoleThree - s.Course.HoleThree == value? 1: 0,
                    s.scorecard.HoleFour - s.Course.HoleFour == value? 1: 0,
                    s.scorecard.HoleFive - s.Course.HoleFive == value? 1: 0,
                    s.scorecard.HoleSix - s.Course.HoleSix == value? 1: 0,
                    s.scorecard.HoleSeven - s.Course.HoleSeven == value? 1: 0,
                    s.scorecard.HoleEight - s.Course.HoleEight == value? 1: 0,
                    s.scorecard.HoleNine - s.Course.HoleNine == value? 1: 0,
                    s.scorecard.HoleTen - s.Course.HoleTen == value? 1: 0,
                    s.scorecard.HoleEleven - s.Course.HoleEleven == value? 1: 0,
                    s.scorecard.HoleTwelve - s.Course.HoleTwelve == value? 1: 0,
                    s.scorecard.HoleThirteen - s.Course.HoleThirteen == value? 1: 0,
                    s.scorecard.HoleFourteen - s.Course.HoleFourteen == value? 1: 0,
                    s.scorecard.HoleFifteen - s.Course.HoleFifteen == value? 1: 0,
                    s.scorecard.HoleSixteen - s.Course.HoleSixteen == value? 1: 0,
                    s.scorecard.HoleSeventeen - s.Course.HoleSeventeen == value? 1: 0,
                    s.scorecard.HoleEighteen - s.Course.HoleEighteen == value? 1: 0
                    }
                })
                .Sum(s => s.Birdies.Sum());

        }

        private double getAverageScorePar(int par)
        {
             var averageScore =  _context.Scorecard
                .Select(s => new
                {
                    s.Course,
                    scorecard = s
                })
                .AsEnumerable() 
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

