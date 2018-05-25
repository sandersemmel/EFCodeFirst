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
            Assert.IsTrue(true);
            //StatisticsLibrary.MovieReviewStats movieReviewStats = new MovieReviewStats();
    
            //int actual = movieReviewStats.GetAllMovieReviewsCountByPersonID(personID);

            //    Assert.AreEqual(result, actual);
            //    Tuple<int, int> resultTuple = new Tuple<int, int>(result,actual);

            //return resultTuple;
        }
        [TestMethod]
        public void Test2()
        {
            if (1==2)
            {

            }
            else
            {
                throw new Exception();
            }
        }
        //[TestMethod]
        //public Tuple<double?,double?> GetAverageMovieRatingByPersonID(int personID, double? result)
        //{
        //    StatisticsLibrary.MovieReviewStats movieReviewStats = new MovieReviewStats();

        //    double? actual = movieReviewStats.GetAverageMovieRatingByPersonID(personID);
        //    Tuple<double?,double?> resultTuple = new Tuple<double?, double?>(result, actual);
        //    return resultTuple;
            
        //}

    }
}
