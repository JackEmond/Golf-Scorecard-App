using System.ComponentModel.DataAnnotations;

namespace MvcGolfScorecardApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string? CourseName { get; set; }

        public byte HoleOne { get; set; }
        public byte HoleTwo { get; set; }
        public byte HoleThree { get; set; }
        public byte HoleFour { get; set; }
        public byte HoleFive { get; set; }
        public byte HoleSix { get; set; }
        public byte HoleSeven { get; set; }
        public byte HoleEight { get; set; }
        public byte HoleNine { get; set; }
        public byte HoleTen { get; set; }
        public byte HoleEleven { get; set; }
        public byte HoleTwelve { get; set; }
        public byte HoleThirteen { get; set; }
        public byte HoleFourteen { get; set; }
        public byte HoleFifteen { get; set; }
        public byte HoleSixteen { get; set; }
        public byte HoleSeventeen { get; set; }
        public byte HoleEighteen { get; set; }

        public ICollection<Scorecard>? Scorecards { get; set; }


        public short FrontNine
        {
            get
            {
                return (short)(HoleOne + HoleTwo + HoleThree + HoleFour + HoleFive + HoleSix + HoleSeven + HoleEight + HoleNine);
            }
        }

        public short BackNine
        {
            get
            {
                return (short)(HoleEleven + HoleTwelve + HoleThirteen + HoleFourteen + HoleFifteen + HoleSixteen + HoleSeventeen + HoleEighteen);
            }
        }


    }
}
