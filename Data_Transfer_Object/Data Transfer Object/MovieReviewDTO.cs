using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data_Transfer_Object
{
    public class MovieReviewDTO
    {
        public int MovieReviewID { get; set; }
        public string MovieReviewText { get; set; }
        public int? MovieID { get; set; }
        public int? Reviewer { get; set; }
        public int? MovieRating { get; set; }
        public string ReviewerFirstName { get; set; }
        public string ReviewerLastName { get; set; }

    }
}