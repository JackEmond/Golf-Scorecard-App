namespace MvcGolfScorecardApp.Models
{
    public class AdvancedStats
    {
        public int BestScore9Holes { get; set; }
        public int BestScore18Holes { get; set; }
        public double Handicap { get; set; }

        public string? FavouriteCourse { get; set; }
        public int TotalNumberOfStrokes { get; set; }
        public int TotalNumberOfRounds { get; set; }
        public int TotalNumberOfHoles { get; set; }
        public int TotalNumberOfBirdies { get; set; }
        public int TotalNumberOfPars { get; set; }
        public int TotalNumberOfEagles { get; set;}
        public int TotalNumberOfHoleInOnes { get; set; }
       
        public double AverageScorePar3 { get; set; }
        public double AverageScorePar4 { get; set; }
        public double AverageScorePar5 { get; set; }


    }
}
