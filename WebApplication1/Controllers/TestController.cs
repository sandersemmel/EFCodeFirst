using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StatisticsLibraryTest;
using Data_Transfer_Object;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/tests")]
        public IHttpActionResult TestResults()
        {
            StatisticsLibraryTest.StatisticsLibraryTest test = new StatisticsLibraryTest.StatisticsLibraryTest();

            test.GetAllMovieReviewsCountByPersonID(1,10);
            TestDTO testDTO = new TestDTO();
            testDTO.
            //test.GetAverageMovieRatingByPersonID(1,);

        }
    }
}
