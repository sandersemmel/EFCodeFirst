using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class MovieController : ApiController
    {
        MovieRepository MovieRepository = new MovieRepository();

        [Route("api/movies/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Movie> movies = MovieRepository.GetAll().ToList();
            if (movies.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(movies);
            }
        }

        [HttpPost]
        [Route("api/movies/add")]
        public IHttpActionResult AddMovie([FromBody] Movie movie)
        {
            if ((movie.MovieName == "" || movie.MovieName == null) ||
                movie.BroughtBy == 0 || movie.BroughtBy == null)
            {
                return NotFound();
            }
            else
            {
                MovieRepository.FindSingle(movie.BroughtBy);
            
                Movie newMovie = new Movie();
                newMovie.MovieName = movie.MovieName;

                MovieRepository.Add(newMovie);
                return Ok();
            }
        }
    }
}
