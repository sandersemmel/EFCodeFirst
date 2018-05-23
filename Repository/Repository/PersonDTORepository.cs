//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;


//namespace Repository
//{
//    public class PersonDTORepository : IRepository<PersonDTO>
//    {
//        public bool Add(PersonDTO item)
//        {
//            throw new NotImplementedException();
//        }

//        public List<PersonDTO> Find()
//        {
//            throw new NotImplementedException();
//        }

//        public PersonDTO FindSingle(int? id)
//        {
//            throw new NotImplementedException();
//        }

//        public List<PersonDTO> GetAll()
//        {
//            using (MovieContext dbContext = new MovieContext())
//            {
//                var people = dbContext.People.ToList();
//                var peopleDTO = people.Select(a => new PersonDTO
//                {
//                    PersonID = a.PersonID,
//                    FirstName = a.FirstName,
//                    LastName = a.LastName
//                }).ToList();
//                return peopleDTO;
//            }


//        }

//        public bool Remove(PersonDTO item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}