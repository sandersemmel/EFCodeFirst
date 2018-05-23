namespace EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            MOVIEREVIEWs = new HashSet<MOVIEREVIEW>();
        }

        public int MovieID { get; set; }

        [StringLength(255)]
        public string MovieName { get; set; }

        public int? BroughtBy { get; set; }

        [StringLength(255)]
        public string Director { get; set; }

        public int? Rating { get; set; }

        public virtual PERSON PERSON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIEREVIEW> MOVIEREVIEWs { get; set; }
    }
}
