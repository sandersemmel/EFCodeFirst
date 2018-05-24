using EF;
using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Repository.Repository
{
    public class PersonRepository : IRepository<PERSON>
    {
        public bool Add(PERSON item)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                try
                {
                    dbContext.People.Add(item);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
               
            }
        }

        public List<PERSON> Find()
        {
            throw new NotImplementedException();
        }

        public PERSON FindSingle(int? id)
        {
            using (MovieContext dbContext = new MovieContext())
            {
                try
                {
                    var person = dbContext.People.Find(id);
                    return person;
                }
                catch (Exception)
                {

                    return null;
                }
            }
                
        }

        public List<PERSON> GetAll()
        {
            throw new NotImplementedException();

        }

        public bool Remove(PERSON item)
        {
            throw new NotImplementedException();
        }
    }
}