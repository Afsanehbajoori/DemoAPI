﻿using DemoAPI.Models;
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

        //private readonly DatabaseContext _databaseContext;
        private DatabaseContext db = new DatabaseContext();
        /*public PeopleController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }*/
        
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
            var p = people.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        //Get med specific route
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
