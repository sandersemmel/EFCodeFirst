using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1;

namespace WebApplication1.Repository
{
    public class PersonRepository : IRepository<PERSON>
    {
        MovieContext movieContext = new MovieContext();
        public void Add(PERSON item)
        {
            throw new NotImplementedException();
        }

        public List<PERSON> Find()
        {
            throw new NotImplementedException();
        }

        public PERSON FindSingle(int? id)
        {
           return movieContext.People.Find(id);
        }

        public List<PERSON> GetAll()
        {
            return movieContext.People.ToList();
        }

        public void Remove(PERSON item)
        {
            throw new NotImplementedException();
        }
    }
}