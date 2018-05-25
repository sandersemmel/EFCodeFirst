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
        
        MOVIEREVIEWRepository movieReviewRepository = new MOVIEREVIEWRepository();
        List<MovieReviewDTO> MovieReviewDTO = new List<MovieReviewDTO>();
        public MovieReviewStats()
        {
            var movieReviews = movieReviewRepository.GetAll();
            this.MovieReviewDTO = AutoMapper.Mapper.Map(movieReviews, MovieReviewDTO);
        }
        public int GetAllMovieReviewsCountByPersonID(int id)
        {
            return MovieReviewDTO.Where(o => o.Reviewer == id).Count();
        }
    }
}
