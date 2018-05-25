using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using EF.Model;
using Data_Transfer_Object;
using StatisticsLibrary;
using Mapper.MapProfile;
using AutoMapper;


namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

            HttpConfiguration config = GlobalConfiguration.Configuration;

            AutoMapProfile.Run();

            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            MovieReviewStatsTest.MovieReviewStatsTest test = new MovieReviewStatsTest.MovieReviewStatsTest();
            test.GetAllMovieReviewsCountByPersonID();
        }
    }
}
