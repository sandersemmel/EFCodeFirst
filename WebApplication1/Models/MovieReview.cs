using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class MovieReview
    {
        [Key]
        public int MovieReviewId { get; set; }

        public string ReviewText { get; set; }


        public virtual int MovieId { get; set; }
        [ForeignKey("Movie")]

        public virtual int PersonId { get; set; }
        [ForeignKey("Person")]

        public virtual Movie Movie { get; set; }
        public virtual Person Person { get; set; }


    }
}