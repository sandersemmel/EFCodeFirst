using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieReviewController : ApiController
    {

        [Route("api/addmoviereview")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] int id)
        {

            using (DatabaseContext dbcontext = new DatabaseContext())
            {
                MovieReview uusiMovieReview = new MovieReview();
                //Person uusiPerson = dbcontext.Person.FirstOrDefault(e => e.Id == id);
                //uusiMovieReview.Person = uusiPerson;
                uusiMovieReview.ReviewText = "Tosi hyvä elokuva";

                dbcontext.MovieReview.Add(uusiMovieReview);
                dbcontext.SaveChanges();
            }
                return Ok();
        }
    }
}
