using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Data_Transfer_Object;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{

    public class PersonController : ApiController
    {
        PersonDTORepository personDTORepository = new PersonDTORepository();
        PersonRepository personRepository = new PersonRepository();

        [Route("api/addperson")]
        [HttpPost]
        public IHttpActionResult Post()
        {
            PERSON uusi = new PERSON();
            uusi.FirstName = "testi";
            uusi.LastName = "testi";
            personRepository.Add(uusi);
            return Ok();
        }
        [HttpGet]
        [Route("api/person/{id}")]
        public IHttpActionResult Get([FromUri] int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                PERSON person = personRepository.FindSingle(id);
                return Ok(person);
            }

        }
        [HttpGet]
        [Route("api/person/getall")]
        public IHttpActionResult GetAll()
        {
            var people = personDTORepository.GetAll();
            if (people.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(people);
            }

        }
    }
}
