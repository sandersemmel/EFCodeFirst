using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Data_Transfer_Object;
using Repository.Repository;
using EF.Model;

namespace WebApplication1.Controllers
{
    public class MovieReviewController : ApiController
    {

        MOVIEREVIEWRepository MOVIEREVIEWRepository = new MOVIEREVIEWRepository();

        [HttpGet]
        [Route("api/moviereviews/{id}")]
        public IHttpActionResult GetAllByMovieID(int id)
        {
           var movies = MOVIEREVIEWRepository.GetAllByMovieID(id);

            if (movies == null || !movies.Any())
            {
                return NotFound();
            }
            else
            {
                // MAP moviereview -> moviereviewDTO
                return Ok();
            }
            
        }

        [HttpGet]
        [Route("api/moviereviews/person/{id}")]
        public IHttpActionResult GetAll(int id)
        {
            var movieReviews = MOVIEREVIEWRepository.GetAllByPersonID(id);

            if (movieReviews == null)
            {
                return NotFound();
            }
            else
            {
                // MAP moviereview -> moviereviewDTO
                return Ok();
            }

        }
        [HttpPost]
        [Route("api/moviereviews/add")]
        public IHttpActionResult Add([FromBody] MovieReviewDetailsDTO movieReviewDetailsDTO)
        {
            // MAP moviereviewdetailsDTO -> Moviereview

            if (MOVIEREVIEWRepository.Add(null))
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
