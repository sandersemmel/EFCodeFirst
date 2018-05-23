using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;

namespace WebApplication1.Mapper
{
    public class Mapper
    {
        public static List<MovieReviewDetails> MapItems(List<MOVIEREVIEW> unMappedList)
        {
            List<MovieReviewDetails> mappedList = unMappedList.Select(item => new MovieReviewDetails()
            {
                MovieID = item.MovieID,
                MovieRating = item.MovieRating,
                MovieReviewID = item.MovieReviewID,
                MovieReviewText = item.MovieReviewText,
                Reviewer = item.Reviewer

            }).ToList();

            return mappedList;
        }
        public static List<MovieDetails> MapMovieToMovieDetails(List<Movie> movielist)
        {
            List<MovieDetails> movieDetails = movielist.Select(item => new MovieDetails()
            {
                MovieID = item.MovieID,
                MovieName = item.MovieName,
                BroughtBy = item.BroughtBy,
                
            }).ToList();
        }
    }
}