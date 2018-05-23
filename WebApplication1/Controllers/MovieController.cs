using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository.Repository;
using WebApplication1.Data_Transfer_Object;

namespace WebApplication1.Controllers
{
    public class MovieController : ApiController
    {
        MovieRepository MovieRepository = new MovieRepository();

        [Route("api/movies/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<MovieDetailsDTO> movieDetails = MovieRepository.GetAll();

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
    }
}
