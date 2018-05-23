using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class MovieDetails
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public int? BroughtBy { get; set; }
        public string Director { get; set; }
        public double? Rating { get; set; }
        public int AmountOfRatings { get; set; }
        public int RatingSum { get; set; }
    }
}