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

        private DatabaseContext db = new DatabaseContext();
        
        

        //hard code dele:
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person() { Id = 1, FirstName = "Allan", LastName = "Tori" });
            people.Add(new Person() { Id = 2, FirstName = "Adrian", LastName = "Tori" });
            people.Add(new Person() { Id = 3, FirstName = "Jon", LastName = "Jensen" });
            people.Add(new Person() { Id = 4, FirstName = "Ben", LastName = "Pedersen" });
        }




        [HttpGet]
        // GET: api/People
        public List<Person> Get()
        {
            //return people;
            return db.person.ToList();
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            //hard code dele:
            /* var p = people.Where(x => x.Id == id).FirstOrDefault();
             return p;*/

            var p = db.person.FirstOrDefault(x => x.Id == id);
            return p;
        }

        //Get med specific route(hard code)
        [Route("api/People/GetFirstName")]
        [HttpGet]
        public List<string> GetFirstName()
        {
            List<string> listOfFirstName = new List<string>();

            foreach (var p in people)
            {
                listOfFirstName.Add(p.FirstName);
            }

            return listOfFirstName;
        }


        //Get med first Name
        [Route("api/People/GFN")]
        [HttpGet]
        public List<string> GetFN()
        {
            List<string> LP = new List<string>();
            foreach (var i in db.person)
            {
                LP.Add(i.FirstName);
            }
            return LP;
        }

        [HttpPost]
        // POST: api/People
        public void Post(Person personAdd)
        {
            //hard code mode:
            /*var addPerson = new Person(){Id=5,FirstName="Mikki", LastName="Bery" };
            people.Add(addPerson);*/

           // people.Add(personAdd);

           
                personAdd = new Person()
                {
                    Id = personAdd.Id,
                    FirstName = personAdd.FirstName,
                    LastName = personAdd.LastName
                };
            

            db.person.Add(personAdd);
            db.SaveChanges();
        }

        [HttpPut]
        // PUT: api/People/5
        public void Put(int id , Person personUpdate)
        {
            //hard code dele:
            /*var personUpdate = people.FirstOrDefault(x => x.Id == id);
            personUpdate.LastName = "PUHEEE";*/

            //var personUpdate = db.person.FirstOrDefault(x => x.Id == id);
            db.Entry(personUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }



        [HttpDelete]
        // DELETE: api/People/5
        public void Delete(int id)
        {

            //hard code dele:
            /*var personDelete = people.FirstOrDefault(x => x.Id == id);
            people.Remove(personDelete);*/

            var personDelete = db.person.FirstOrDefault(x => x.Id == id);
            db.person.Remove(personDelete);
            db.SaveChanges();
        }
    }
}
