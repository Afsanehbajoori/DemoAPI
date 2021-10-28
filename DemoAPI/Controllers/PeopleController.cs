using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person() { Id = 1, FirstName = "Allan", LastName = "Tori" });
            people.Add(new Person() { Id = 2, FirstName = "Adrian", LastName = "Tori" });
            people.Add(new Person() { Id = 3, FirstName = "Jon", LastName = "Jensen" });
            people.Add(new Person() { Id = 4, FirstName = "Ben", LastName = "Pedersen" });
        }
        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            var p = people.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
            var addPerson = new Person(){Id=5,FirstName="Mikki", LastName="Bery" };
            people.Add(addPerson);
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
            var personUpdate = people.FirstOrDefault(x => x.Id == id);
            personUpdate.LastName = "PUHEEE";
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            var personDelete = people.FirstOrDefault(x => x.Id == id);
            people.Remove(personDelete);
        }
    }
}
