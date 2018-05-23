using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;
using WebApplication1.Repository;

namespace WebApplication1.Business
{
    public class DTOMethods
    {
        public List<MovieDetails> GetHomePageDTO()
        {
            MovieDetailsRepository movieDetailsRepository = new MovieDetailsRepository();

            var moviedetails = movieDetailsRepository.GetAll();

            return moviedetails;
        }
    }
}