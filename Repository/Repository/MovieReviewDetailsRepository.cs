using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Model;
using EF;

namespace Repository
{
    public class MOVIEREVIEWRepository : IRepository<MOVIEREVIEW>
    {
        public bool Add(MOVIEREVIEW item)
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

        public bool Remove(MOVIEREVIEW item)
        {
            throw new NotImplementedException();
        }

        public List<MOVIEREVIEW> GetAll()
        {
           
            using (MovieContext dbContext = new MovieContext())
            {
                var movieReviews = dbContext.MOVIEREVIEWs.ToList();

                var movieReviewDTO = movieReviews.Select(item => new MOVIEREVIEW()
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
        public List<MOVIEREVIEW> GetAllByMovieID(int movieID)
        {

            using (MovieContext dbContext = new MovieContext())
            {
                var movieReviews = dbContext.MOVIEREVIEWs.Where(x => x.MovieID == movieID).ToList();
                var person = dbContext.People.ToList(); // älä tee näin, ellei ole pakko

                var movieReviewDTO = movieReviews.Select(item => new MOVIEREVIEW()
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
        public List<MOVIEREVIEW> GetAllByPersonID(int personID)
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
                    List<MOVIEREVIEW> mappedList = Mapper.Mapper.MapItems(movieReviews);
                    return mappedList;
                }
            }
        }

        public List<MOVIEREVIEW> Find()
        {
            throw new NotImplementedException();
        }

        public MOVIEREVIEW FindSingle(int? id)
        {
            throw new NotImplementedException();
        }
    }
}