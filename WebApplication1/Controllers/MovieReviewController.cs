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
                List<MovieReviewsDTO> movieReviewsDTO = new List<MovieReviewsDTO>();
                AutoMapper.Mapper.Map(movieReviews, movieReviewsDTO);
                foreach (MovieReviewsDTO m in movieReviewsDTO)
                {
                    m.ReviewerFirstName = people.Where(z => z.PersonID == m.Reviewer).FirstOrDefault().FirstName;
                    m.ReviewerLastName = people.Where(z => z.PersonID == m.Reviewer).FirstOrDefault().LastName;

                }
                return Ok(movieReviewsDTO);
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
        public IHttpActionResult Add([FromBody] MovieReviewsDTO MovieReviewsDTO)
        {
            // MAP MovieReviewsDTO -> Moviereview

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
