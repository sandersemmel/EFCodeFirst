using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatisticsLibrary;

namespace MovieReviewStatsTest
{
    [TestClass]
    public class MovieReviewStatsTest
    {
        [TestMethod]
        public void GetAllMovieReviewsCountByPersonID()
        {
            StatisticsLibrary.MovieReviewStats movieReviewStats = new MovieReviewStats();

            int id = 1;
            int count = 10;

            int result = movieReviewStats.GetAllMovieReviewsCountByPersonID(1);

            try
            {

            }
            Assert.AreEqual(count, result);
        }
    }
}
