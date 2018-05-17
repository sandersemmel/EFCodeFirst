using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data_Transfer_Object;

namespace WebApplication1
{
    public class MovieRepository : IRepository<Movie>
    {
        MovieContext dbContext = new MovieContext();


        public List<Movie> Find()
        {
            throw new NotImplementedException();
        }

        public void Add(Movie item)
        {
            try
            {
                dbContext.Movies.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Remove(Movie item)
        {
            try
            {
                dbContext.Movies.Remove(item);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
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