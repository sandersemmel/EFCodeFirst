using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatisticsLibrary;

namespace StatisticsLibraryTest
{
    [TestClass]
    public class StatisticsLibraryTest
    {
        [TestMethod]
        public void GetAllMovieReviewsCountByPersonID()
        {
            StatisticsLibrary.MovieReviewStats movieReviewStats = new MovieReviewStats();
            int personID = 1;
            int result = 10;
            int actual = movieReviewStats.GetAllMovieReviewsCountByPersonID(personID);
            if (actual == result)
            {

            }
            else
            {
                throw new Exception();
            }

        }
        [TestMethod]
        public void Test2()
        {
            string teksti = "hello";
            string teksti2 = "hello2";
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetAverageMovieRatingByPersonID()
        {
            int personID = 1;
            int result = 0;
            StatisticsLibrary.MovieReviewStats movieReviewStats = new MovieReviewStats();

            var actual = movieReviewStats.GetAverageMovieRatingByPersonID(personID);
            if (actual == result)
            {

            }
            else
            {
                throw new Exception();
            }
        }




        //[ClassCleanup]
        //public void ThrowError()
        //{
        //    throw new Exception();
        //}
    }
}
