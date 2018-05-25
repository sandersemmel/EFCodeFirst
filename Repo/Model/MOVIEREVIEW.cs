namespace EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOVIEREVIEW")]
    public partial class MOVIEREVIEW
    {
        public int MovieReviewID { get; set; }

        [StringLength(255)]
        public string MovieReviewText { get; set; }

        public int? MovieRating { get; set; }

        public int? MovieID { get; set; }

        public int? Reviewer { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
