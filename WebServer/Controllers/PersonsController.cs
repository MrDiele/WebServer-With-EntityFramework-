﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServer.Interfaces;
using WebServer.Model;
using Newtonsoft.Json;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonBase _PersonBase;

        public PersonsController(IPersonBase PersonBase)
        {
            _PersonBase = PersonBase;
        }
        
        [HttpGet]
        [Route("Cities")]
        public IEnumerable<City> GetCities()
        {
            return _PersonBase.GetCitiesList();
        }
         
        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return _PersonBase.GetPersonsList();
        }
        
        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            return _PersonBase.GetPerson(id);
        }

        [HttpPost("{id}")]
        public void Create(string id, [FromBody] Person person)
        {
            _PersonBase.Insert(person);
        }

        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Person person)
        {
            _PersonBase.Update(id, person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _PersonBase.Delete(id);
        }
    }    
}
