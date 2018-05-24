using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Data_Transfer_Object;
using Repository.Repository;
using EF.Model;

namespace WebApplication1.Controllers
{

    public class PersonController : ApiController
    {
        PersonRepository personRepository = new PersonRepository();

        [Route("api/addperson")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] PERSON person)
        {
            if (personRepository.Add(person))
            {
                return Ok("Person was added.");
            }
            else
            {
                return BadRequest("Person was not added.");
            }
            
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
            var people = personRepository.GetAll();
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
