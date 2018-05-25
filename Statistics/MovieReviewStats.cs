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
    public static class MovieReviewStats
    {
        public int GetAllMovieReviewsCountByPersonID(IEnumerable<MOVIEREVIEW> movieReviewEnumerable,int id)
        {
            return movieReviewEnumerable.Where(o => o.Reviewer == id).Count();

        }
        public double? GetAverageMovieRatingByPersonID(int personID)
        {
            var averageRating = MovieReviewDTO.Where(o => o.Reviewer == personID).Average(o => o.MovieRating);
            return averageRating;
        }
    }
}
