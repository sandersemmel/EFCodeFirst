using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;

namespace WebApplication1.Repository
{
    public class MovieDetailsRepository : IRepository<MovieDetails>
    {

        public void Add(MovieDetails item)
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
                var newMovieDetails = dbContext.Movies.FirstOrDefault(x => x.MovieID == id);
                if (newMovieDetails == null)
                {
                    return null;
                }
                var MappedDetails = new MovieDetails
                {
                    MovieID = newMovieDetails.MovieID,
                    MovieName = newMovieDetails.MovieName
                };
                return MappedDetails;
            }
        }

        public List<MovieDetails> GetAll()
        {
            using (MovieContext dbContext = new MovieContext()) 
            {
                var movies = dbContext.Movies.ToList();

                var movieDetails = movies.Select(a => new MovieDetails()
                {
                    MovieID = a.MovieID,
                    MovieName = a.MovieName,
                    BroughtBy = a.BroughtBy,
                    Director = a.Director,
                    Rating = a.Rating
                }).ToList();
                return movieDetails;
            }
        }

        public void Remove(MovieDetails item)
        {
            throw new NotImplementedException();
        }
    }
}