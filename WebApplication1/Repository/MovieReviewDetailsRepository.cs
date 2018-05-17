using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;
using WebApplication1.Mapper;

namespace WebApplication1.Repository
{
    public class MovieReviewDetailsRepository : IRepository<MovieReviewDetails>
    {
        public void Add(MovieReviewDetails item)
        {
            throw new NotImplementedException();
        }

        public void Remove(MovieReviewDetails item)
        {
            throw new NotImplementedException();
        }

        public List<MovieReviewDetails> GetAll()
        {
           
            using (MovieContext dbContext = new MovieContext())
            {
                var movieReviews = dbContext.MOVIEREVIEWs.ToList();

                var movieReviewDTO = movieReviews.Select(item => new MovieReviewDetails()
                {
                    MovieReviewID = item.MovieReviewID,
                    MovieID = item.MovieID,
                    MovieRating = item.MovieRating,
                    MovieReviewText = item.MovieReviewText,
                    Reviewer = item.Reviewer
                }).ToList();
                return movieReviewDTO;

            }
        }
        public List<MovieReviewDetails> GetAllByMovieID(int movieID)
        {

            using (MovieContext dbContext = new MovieContext())
            {
                var movieReviews = dbContext.MOVIEREVIEWs.Where(x => x.MovieID == movieID).ToList();

                var movieReviewDTO = movieReviews.Select(item => new MovieReviewDetails()
                {
                    MovieReviewID = item.MovieReviewID,
                    MovieID = item.MovieID,
                    MovieRating = item.MovieRating,
                    MovieReviewText = item.MovieReviewText,
                    Reviewer = item.Reviewer
                }).ToList();
                return movieReviewDTO;

            }
        }
        public List<MovieReviewDetails> GetAllByPersonID(int personID)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                var movieReviews = dbContext.MOVIEREVIEWs.Where(item => item.Reviewer == personID).ToList();
                if (movieReviews == null || !movieReviews.Any())
                {
                    return null;
                }
                else
                {
                    List<MovieReviewDetails> mappedList = Mapper.Mapper.MapItems(movieReviews);
                    return mappedList;
                }
            }
        }

        public List<MovieReviewDetails> Find()
        {
            throw new NotImplementedException();
        }

        public MovieReviewDetails FindSingle(int? id)
        {
            throw new NotImplementedException();
        }
    }
}