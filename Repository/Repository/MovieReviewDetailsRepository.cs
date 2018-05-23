using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;
using WebApplication1.Mapper;

namespace Repository
{
    public class MovieReviewDetailsRepository : IRepository<MovieReviewDetails>
    {
        public bool Add(MovieReviewDetails item)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                if (item.MovieReviewText == "" ||
                    (item.Reviewer == null || item.Reviewer == 0) ||
                    item.MovieRating == null || 
                    item.MovieID == null || item.MovieID == 0
                    )
                    return false;
                else
                {
                    MOVIEREVIEW movieReview = new MOVIEREVIEW();

                    movieReview.MovieReviewText = item.MovieReviewText;
                    movieReview.MovieRating = item.MovieRating;
                    movieReview.Reviewer = item.Reviewer;
                    movieReview.MovieID = item.MovieID;

                    dbContext.MOVIEREVIEWs.Add(movieReview);
                    dbContext.SaveChanges();

                    return true;

                }
            }
                

            
        }

        public bool Remove(MovieReviewDetails item)
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
                var person = dbContext.People.ToList(); // älä tee näin, ellei ole pakko

                var movieReviewDTO = movieReviews.Select(item => new MovieReviewDetails()
                {
                    MovieReviewID = item.MovieReviewID,
                    MovieID = item.MovieID,
                    MovieRating = item.MovieRating,
                    MovieReviewText = item.MovieReviewText,
                    Reviewer = item.Reviewer,
                    ReviewerFirstName = person.Where(y=>y.PersonID == item.Reviewer).FirstOrDefault().FirstName,
                    ReviewerLastName = person.Where(y=>y.PersonID == item.Reviewer).FirstOrDefault().LastName
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