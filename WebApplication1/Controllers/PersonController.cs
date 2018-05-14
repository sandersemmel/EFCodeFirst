using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{

    public class PersonController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();


        [Route("api/getpeople")]
        public List<Models.Person> Get()
        {
            return db.Person.ToList();
        }
        [Route("api/addperson")]
        [HttpPost]
        public IHttpActionResult Post()
        {
            Models.Person uusi = new Models.Person();
            uusi.FirstName = "testi";
            uusi.LastName = "testi";
            db.Person.Add(uusi);
            db.SaveChanges();
            return Ok();
        }
    }
}
