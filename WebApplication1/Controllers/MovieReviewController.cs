using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_Transfer_Object;
using Repository.Repository;
using EF.Model;

namespace WebApplication1.Controllers
{
    public class MovieReviewController : ApiController
    {

        MOVIEREVIEWRepository MOVIEREVIEWRepository = new MOVIEREVIEWRepository();
        PersonRepository personRepository = new PersonRepository();

        [HttpGet]
        [Route("api/moviereviews/{id}")]
        public IHttpActionResult GetAllByMovieID(int id)
        {
           var movieReviews = MOVIEREVIEWRepository.GetAllByMovieID(id);
            var people = personRepository.GetAll();
            if (movieReviews == null || !movieReviews.Any())
            {
                return NotFound();
            }
            else
            {
                // MAP moviereview -> moviereviewDTO
                List<MovieReviewDTO> MovieReviewDTO = new List<MovieReviewDTO>();
                AutoMapper.Mapper.Map(movieReviews, MovieReviewDTO);
                foreach (MovieReviewDTO m in MovieReviewDTO)
                {
                    m.ReviewerFirstName = people.Where(z => z.PersonID == m.Reviewer).FirstOrDefault().FirstName;
                    m.ReviewerLastName = people.Where(z => z.PersonID == m.Reviewer).FirstOrDefault().LastName;

                }
                return Ok(MovieReviewDTO);
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
        public IHttpActionResult Add([FromBody] MovieReviewDTO MovieReviewDTO)
        {
            // MAP MovieReviewDTO -> Moviereview

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
