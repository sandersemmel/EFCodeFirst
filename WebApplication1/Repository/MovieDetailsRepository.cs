using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;

namespace WebApplication1.Repository
{
    public class MovieDetailsRepository : IRepository<MovieDetails>
    {

        public bool Add(MovieDetails item)
        {
            throw new NotImplementedException();
        }

        public List<MovieDetails> Find()
        {
            throw new NotImplementedException();
        }

        public MovieDetails FindSingle(int? id)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                var movie = dbContext.Movies.FirstOrDefault(x => x.MovieID == id);
                var rating = dbContext.MOVIEREVIEWs.Where(x => x.MovieID == id);
                var amountOfRatings = rating.Count();
                var movieRatingSum = rating.Sum(z=>z.MovieRating);
                double? movieDetailsRating;

                if (amountOfRatings == null || amountOfRatings == 0)
                {
                    movieDetailsRating = null;
                }
                else
                {
                    movieDetailsRating = (double)movieRatingSum / (double)amountOfRatings; 
                }

                if (movie == null)
                {
                    return null;
                }
                else
                {
                    var MappedDetails = new MovieDetails
                    {
                        MovieID = movie.MovieID,
                        MovieName = movie.MovieName,
                        Rating = movieDetailsRating,
                        BroughtBy =movie.BroughtBy,
                        Director= movie.Director
                        
       
                    };
                    return MappedDetails;
                }


            }
        }

        public List<MovieDetails> GetAll()
        {
            using (MovieContext dbContext = new MovieContext()) 
            {
                var movies = dbContext.Movies.ToList();
                var movieReviews = dbContext.MOVIEREVIEWs.ToList();

                var movieDetails = movies.Select(a => new MovieDetails()
                {
                    MovieID = a.MovieID,
                    MovieName = a.MovieName,
                    BroughtBy = a.BroughtBy,
                    Director = a.Director,
                    AmountOfRatings = movieReviews.Where(c => c.MovieID == a.MovieID).Count(),
                    RatingSum = movieReviews.Where(y=>y.MovieID==a.MovieID).Count()
                    //Rating =  (movieReviews.Where(x => x.MovieID == a.MovieID).Sum(z=>z.MovieRating) / movieReviews.Where(c=>c.MovieID==a.MovieID).Count())
                }).ToList();
                return movieDetails;
            }
        }

        public bool Remove(MovieDetails item)
        {
            throw new NotImplementedException();
        }
        public MovieDetails Take10()
        {
            using (MovieContext dbContext = new MovieContext())
            {
                var movies = dbContext.Movies.Take(10);
                
            }
        }
    }
}