namespace EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EF.Model;


    public partial class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MOVIEREVIEW> MOVIEREVIEWs { get; set; }
        public virtual DbSet<PERSON> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(e => e.MovieName)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Director)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIEREVIEW>()
                .Property(e => e.MovieReviewText)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIEREVIEW>()
                .Property(e => e.MovieRating);



            modelBuilder.Entity<PERSON>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.Movies)
                .WithOptional(e => e.PERSON)
                .HasForeignKey(e => e.BroughtBy);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.MOVIEREVIEWs)
                .WithOptional(e => e.PERSON)
                .HasForeignKey(e => e.Reviewer);
        }
    }
}
