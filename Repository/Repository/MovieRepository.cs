using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF;
using EF.Model;

namespace Repository.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        MovieContext dbContext = new MovieContext();


        public List<Movie> Find()
        {
            throw new NotImplementedException();
        }

        public bool Add(Movie movie)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                if (movie.MovieName == "" || movie.MovieName == null ||
                    movie.BroughtBy == null || movie.BroughtBy == 0)
                {
                    return false;
                }
                else
                {
                    dbContext.Movies.Add(movie);
                    dbContext.SaveChanges();
                    return true;
                }
            }
        }

        public bool Remove(Movie item)
        {
            try
            {
                dbContext.Movies.Remove(item);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
        public List<Movie> GetAll()
        {
               return dbContext.Movies.ToList();
        }


        public Movie FindSingle(int? id)
        {
            return dbContext.Movies.Find(id);
        }
    }
}