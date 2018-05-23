using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF;
using EF.Model;

namespace Repository
{
    public class MovieRepository : IRepository<Movie>
    {

        public bool Add(Movie item)
        {
            throw new NotImplementedException();
        }

        public List<Movie> Find()
        {
            throw new NotImplementedException();
        }

        public Movie FindSingle(int? id)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                //var movie = dbContext.Movies.FirstOrDefault(x => x.MovieID == id);
                //var rating = dbContext.MOVIEREVIEWs.Where(x => x.MovieID == id);
                //var amountOfRatings = rating.Count();
                //var movieRatingSum = rating.Sum(z=>z.MovieRating);
                //double? MovieRating;

                //if (amountOfRatings == null || amountOfRatings == 0)
                //{
                //    MovieRating = null;
                //}
                //else
                //{
                //    MovieRating = (double)movieRatingSum / (double)amountOfRatings; 
                //}

                //if (movie == null)
                //{
                //    return null;
                //}
                //else
                //{
                //    var MappedDetails = new Movie
                //    {
                //        MovieID = movie.MovieID,
                //        MovieName = movie.MovieName,
                //        Rating = MovieRating,
                //        BroughtBy =movie.BroughtBy,
                //        Director= movie.Director


                //    };
                //    return MappedDetails;
                //}
                return null;


            }
        }

        public List<Movie> GetAll()
        {
            using (MovieContext dbContext = new MovieContext()) 
            {
                var movies = dbContext.Movies.ToList();

                return movies;




                //var movies = dbContext.Movies.ToList();
                //var movieReviews = dbContext.MOVIEREVIEWs.ToList();

                //var Movie = movies.Select(a => new Movie()
                //{
                //    MovieID = a.MovieID,
                //    MovieName = a.MovieName,
                //    BroughtBy = a.BroughtBy,
                //    Director = a.Director,
                //    AmountOfRatings = movieReviews.Where(c => c.MovieID == a.MovieID).Count(), // TODO 
                //    RatingSum = movieReviews.Where(y=>y.MovieID==a.MovieID).Count()
                //    //Rating =  (movieReviews.Where(x => x.MovieID == a.MovieID).Sum(z=>z.MovieRating) / movieReviews.Where(c=>c.MovieID==a.MovieID).Count())
                //}).ToList();
                //return Movie;
            }
        }

        public bool Remove(Movie item)
        {
            throw new NotImplementedException();
        }
    }
}