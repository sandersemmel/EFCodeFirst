using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Business;
using WebApplication1.Data_Transfer_Object;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class MovieController : ApiController
    {
        MovieRepository MovieRepository = new MovieRepository();
        MovieDetailsRepository movieDetailsRepository = new MovieDetailsRepository();

        [Route("api/movies/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<MovieDetails> movieDetails = movieDetailsRepository.GetAll();

            if (movieDetails.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(movieDetails);
            }
        }

        [HttpPost]
        [Route("api/movies/add")]
        public IHttpActionResult AddMovie([FromBody] Movie movie)
        {
            if (MovieRepository.Add(movie))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("api/moviedetails/{id}")]
        public IHttpActionResult GetMovieDetails(int id)
        {
            MovieDetails foundMovie = movieDetailsRepository.FindSingle(id);

            if (foundMovie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundMovie);
            }
        }
        [HttpGet]
        [Route("api/movienodto/{id}")]
        public IHttpActionResult GetMovieDetailsNoDto(int id)
        {
            Movie newMovie = MovieRepository.FindSingle(id);

            return Ok(newMovie);
        }
        [HttpGet]
        [Route("api/moviedetails/homepage")]
        public IHttpActionResult GetHomePageDTO()
        {
            // Return person, movie and date
            DTOMethods dTOMethods = new DTOMethods();
            return Ok(dTOMethods.GetHomePageDTO());
        }
    }
}
