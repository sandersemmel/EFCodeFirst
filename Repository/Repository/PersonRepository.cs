using EF;
using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Repository
{
    public class PersonRepository : IRepository<PERSON>
    {
        MovieContext movieContext = new MovieContext();
        public bool Add(PERSON item)
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
            throw new NotImplementedException();

        }

        public bool Remove(PERSON item)
        {
            throw new NotImplementedException();
        }
    }
}