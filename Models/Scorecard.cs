using System.ComponentModel.DataAnnotations;

namespace MvcGolfScorecardApp.Models
{
    public class Scorecard
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Played")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePlayed { get; set; }


        public byte HoleOne { get; set; }
        public byte HoleTwo { get; set; } 
        public byte HoleThree { get; set; }
        public byte HoleFour { get; set; }
        public byte HoleFive { get; set; }
        public byte HoleSix { get; set; }
        public byte HoleSeven { get;  set; }
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

        
        public int CourseId { get; set; }
        public Course? Course { get; set; }

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
                return (short)(HoleTen + HoleEleven + HoleTwelve + HoleThirteen + HoleFourteen + HoleFifteen + HoleSixteen + HoleSeventeen + HoleEighteen);
            }
        }


        public short Score
        {
            get
            {
                return (short)(HoleOne + HoleTwo + HoleThree + HoleFour + HoleFive + HoleSix + HoleSeven + HoleEight + HoleNine +
                  HoleTen + HoleEleven + HoleTwelve + HoleThirteen + HoleFourteen + HoleFifteen + HoleSixteen + HoleSeventeen + HoleEighteen);
            }
        }



    }

}
