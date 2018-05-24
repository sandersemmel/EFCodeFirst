using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Model;
using EF;

namespace Repository.Repository
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
                try
                {
                    var reviews = dbContext.MOVIEREVIEWs.ToList();
                    if (reviews.Count == 0 || reviews == null)
                    {
                        return null;
                    }
                    else
                    {
                        return reviews;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
        }
        public List<MOVIEREVIEW> GetAllByMovieID(int movieID)
        {

            using (MovieContext dbContext = new MovieContext())
            {
                return dbContext.MOVIEREVIEWs.Where(x => x.MovieID == movieID).ToList();
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
                    var reviews = dbContext.MOVIEREVIEWs.Where(z=> z.Reviewer == personID).ToList();
                    return reviews;
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