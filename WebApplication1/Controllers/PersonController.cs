using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_Transfer_Object;
using Repository.Repository;
using EF.Model;
using AutoMapper;

namespace WebApplication1.Controllers
{

    public class PersonController : ApiController
    {
        PersonRepository personRepository = new PersonRepository();

        [Route("api/person/add")]
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
                return BadRequest("Id can not be null.");
            }
            else
            {
                PERSON person = personRepository.FindSingle(id);
                if (person == null)
                {
                    return BadRequest("Person not found.");
                }
                else
                {
                    PersonDTO personDTO = new PersonDTO();
                    AutoMapper.Mapper.Map(person,personDTO);
                    
                    return Ok(personDTO);
                }

            }

        }
        [HttpGet]
        [Route("api/person/getall")]
        public IHttpActionResult GetAll()
        {
            var people = personRepository.GetAll();
            if (people.Count == 0)
            {
                return BadRequest("No people found.");
            }
            else
            {
                List<PersonDTO> personDTOList = new List<PersonDTO>();
                AutoMapper.Mapper.Map(people, personDTOList);
                return Ok(personDTOList);
            }

        }
    }
}
