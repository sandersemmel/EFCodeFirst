using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository.Repository;
using WebApplication1.Data_Transfer_Object;
using EF.Model;

namespace WebApplication1.Controllers
{
    public class MovieController : ApiController
    {
        MovieRepository MovieRepository = new MovieRepository();

        [Route("api/movies/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var movies = MovieRepository.GetAll();

            if (movies.Count == 0)
            {
                return NotFound();
            }
            else
            {
                // MAP Movie -> MovieDTO
                return Ok();
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
        [Route("api/movies/{id}")]
        public IHttpActionResult GetMovieDetails(int id)
        {
            var movie = MovieRepository.FindSingle(id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                // MAP Movie -> MovieDTO
                return Ok();
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
