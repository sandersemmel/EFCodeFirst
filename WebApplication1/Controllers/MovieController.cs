using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository.Repository;
using Data_Transfer_Object;
using EF.Model;

namespace WebApplication1.Controllers
{
    public class MovieController : ApiController
    {
        MovieRepository MovieRepository = new MovieRepository();
        MOVIEREVIEWRepository movieReviewRepository = new MOVIEREVIEWRepository();


        [Route("api/movies/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var movies = MovieRepository.GetAll();
            var reviews = movieReviewRepository.GetAll();


            if (movies.Count == 0 || movies == null)
            {
                return BadRequest("There are no movies or the movie list is empty.");
            }
            else
            {
                // MAP Movie -> MovieDTO
                List<MovieDTO> MovieDTO = new List<MovieDTO>();
                AutoMapper.Mapper.Map(movies, MovieDTO);

                // ADDING Rating to MovieDTO
                foreach (MovieDTO m in MovieDTO)
                {
                    m.Rating = reviews.Where(z => z.MovieID == m.MovieID).Average(o => o.MovieRating);
                }
                return Ok(MovieDTO);
            }
        }

        [HttpPost]
        [Route("api/movies/add")]
        public IHttpActionResult AddMovie([FromBody] MovieDTO movieDTO)
        {
            Movie movie = new Movie();
            AutoMapper.Mapper.Map(movieDTO, movie);

            if (MovieRepository.Add(movie))
            {
                return Ok("Movie was added.");
            }
            else
            {
                return BadRequest("Movie was not added!");
            }
        }
        [HttpGet]
        [Route("api/movies/{id}")]
        public IHttpActionResult GetMovieDetails(int id)
        {
            var movie = MovieRepository.FindSingle(id);
            var reviews = movieReviewRepository.GetAllByMovieID(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                // MAP Movie -> MovieDTO
                MovieDTO movieDTOReturn = new MovieDTO();
                AutoMapper.Mapper.Map(movie, movieDTOReturn);
                movieDTOReturn.Rating = reviews.Average(o => o.MovieRating);
                return Ok(movieDTOReturn);
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
            return null;
        }
        [HttpDelete]
        [Route("api/movie/remove/{id}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            
            if (MovieRepository.Remove(id))
            {
                return Ok("Movie was removed");
            }
            else
            {
                return BadRequest("Movie was not removed");
            }
        }
    }
}
