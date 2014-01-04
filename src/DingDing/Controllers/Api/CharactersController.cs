using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DingDing.Models;

namespace DingDing.Controllers.Api
{
    public class CharactersController : ApiController
    {
        public IEnumerable<Character> Get()
        {
            using (var session = Services.DocumentStore.OpenSession())
            {
                return session.Query<Character>();
            }
        }

        // GET api/characters/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/characters
        public HttpResponseMessage Post([FromBody] Character character)
        {
            using (var session = Services.DocumentStore.OpenSession())
            {
                session.Store(character);
                session.SaveChanges();
            }

            var response = Request.CreateResponse(HttpStatusCode.Created, character);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new{id=character.Id}));

            return response;
        }

        // PUT api/characters/5
        public void Put(int id, [FromBody]Character character)
        {
            using (var session = Services.DocumentStore.OpenSession())
            {
                session.Store(character);
                session.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var session = Services.DocumentStore.OpenSession())
            {
                var character = session.Load<Character>(id);
                session.Delete(character);
                session.SaveChanges();
            }
        }
    }
}
