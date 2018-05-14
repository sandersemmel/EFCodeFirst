using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
   
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MovieReviewId { get; set; }
        [ForeignKey("MovieReviewId")]
        public virtual List<MovieReview> MovieReview { get; set; }
    }
}