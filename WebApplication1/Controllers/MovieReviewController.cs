using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Data_Transfer_Object;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class MovieReviewController : ApiController
    {
        MovieReviewDetailsRepository movieReviewDetailsRepository = new MovieReviewDetailsRepository();

        [HttpGet]
        [Route("api/moviereviewdetails/{id}")]
        public IHttpActionResult GetAllByMovieID(int id)
        {
            List<MovieReviewDetails> movieReviewDTO = movieReviewDetailsRepository.GetAllByMovieID(id);

            if (movieReviewDTO == null || !movieReviewDTO.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(movieReviewDTO);
            }
            
        }

        [HttpGet]
        [Route("api/moviereviewdetails/person/{id}")]
        public IHttpActionResult GetAll(int id)
        {
            List<MovieReviewDetails> movieReviewDTO = movieReviewDetailsRepository.GetAllByPersonID(id);

            if (movieReviewDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movieReviewDTO);
            }

        }
        [HttpPost]
        [Route("api/moviereviewdetails/add")]
        public IHttpActionResult Add([FromBody] MovieReviewDetails movieReviewDetails)
        {
            if (movieReviewDetailsRepository.Add(movieReviewDetails))
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Moviereview was not added!");
            }
            
        }
    }
}
