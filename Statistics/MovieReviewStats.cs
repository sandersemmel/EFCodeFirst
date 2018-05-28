using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repository;
using EF.Model;
using Mapper;
using AutoMapper;
using Data_Transfer_Object;

namespace StatisticsLibrary
{
    public class MovieReviewStats
    {
        List<MOVIEREVIEW> movieReviews = new List<MOVIEREVIEW>();
        public MovieReviewStats()
        {
            MOVIEREVIEWRepository movieReviewRepository = new MOVIEREVIEWRepository();
            this.movieReviews = movieReviewRepository.GetAll();
        }
        public int GetAllMovieReviewsCountByPersonID(int id)
        {
            return this.movieReviews.Where(o => o.Reviewer == id).Count();

        }
        public double? GetAverageMovieRatingByPersonID(int personID)
        {
            var averageRating = this.movieReviews.Where(o => o.Reviewer == personID).Average(o => o.MovieRating);
            return averageRating;
        }
    }
}
