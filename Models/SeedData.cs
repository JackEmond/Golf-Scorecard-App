
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcGolfScorecardApp.Data;
using System;
using System.Linq;

namespace  MvcGolfScorecardApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcGolfScorecardAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcGolfScorecardAppContext>>()))
            {
                // Look for any movies.
                if (context.Scorecard.Any())
                {
                    return;   // DB has been seeded
                }

                /*

                context.Scorecard.AddRange(
                    new Scorecard
                    {
                        DatePlayed = DateTime.Parse("1989-2-12"),
                        HoleOne = 3,
                        HoleTwo = 4,
                        HoleThree = 5,
                        HoleSix = 6,
                        HoleSeven = 7,
                        HoleEight = 8,
                        HoleNine = 9,
                        HoleTen = 10,
                        HoleEleven = 11,
                        HoleTwelve = 12,
                        HoleThirteen = 13,
                        HoleFourteen = 14,
                        HoleFifteen = 15,
                        HoleSixteen = 16,
                        HoleSeventeen = 17,
                        HoleEighteen = 18,
                        CourseId = 1
                    },

                    new Scorecard
                    {
                        DatePlayed = DateTime.Parse("1997-2-12"),
                        HoleOne = 3,
                        HoleTwo = 4,
                        HoleThree = 5,
                        HoleSix = 6,
                        HoleSeven = 7,
                        HoleEight = 8,
                        HoleNine = 9,
                        HoleTen = 10,
                        HoleEleven = 11,
                        HoleTwelve = 12,
                        HoleThirteen = 13,
                        HoleFourteen = 14,
                        HoleFifteen = 15,
                        HoleSixteen = 16,
                        HoleSeventeen = 17,
                        HoleEighteen = 18
                    },
                    
                    new Scorecard
                    {
                    DatePlayed = DateTime.Parse("2020-2-12"),
                    HoleOne = 3,
                    HoleTwo = 4,
                    HoleThree = 5,
                    HoleSix = 6,
                    HoleSeven = 7,
                    HoleEight = 8,
                    HoleNine = 9,
                    HoleTen = 10,
                    HoleEleven = 11,
                    HoleTwelve = 12,
                    HoleThirteen = 13,
                    HoleFourteen = 14,
                    HoleFifteen = 15,
                    HoleSixteen = 16,
                    HoleSeventeen = 17,
                    HoleEighteen = 18
                    }
                );
                context.SaveChanges();
                */
            }
        }
    }
}