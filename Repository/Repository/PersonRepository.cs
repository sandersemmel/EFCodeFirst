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
            if (item.FirstName == "" || item.LastName == "")
            {
                return false;
            }
            else
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
            using (MovieContext dbContext = new MovieContext())
            {
                try
                {
                    var people = dbContext.People.ToList();
                    if (people == null)
                    {
                        return null;
                    }
                    else
                    {
                        return people;
                    }
                }
                catch (Exception)
                {

                    return null;
                }
                
            }

        }

        public bool Remove(PERSON item)
        {
            throw new NotImplementedException();
        }
    }
}