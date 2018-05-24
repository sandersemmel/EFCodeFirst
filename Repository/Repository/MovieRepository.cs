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
                //dbContext.Movies.Remove(item);
                //dbContext.SaveChanges();
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
            using (MovieContext dbContext = new MovieContext())
            {
                try
                {
                    var movies = dbContext.Movies.ToList();
                    if (movies == null || movies.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return movies;
                    }
                }
                catch (Exception)
                {

                    return null;
                }
                
            }
        }


        public Movie FindSingle(int? id)
        {
            //return dbContext.Movies.Find(id);
            return null;
        }
    }
}