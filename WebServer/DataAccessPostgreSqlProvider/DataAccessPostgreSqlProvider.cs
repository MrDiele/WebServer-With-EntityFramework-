using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebServer.Interfaces;
using WebServer.Model;

namespace WebServer.DataAccessPostgreSqlProvider
{
    public class DataAccesPostgreSqlProvider : IPersonBase
    {
        private readonly DomainModelPostgreSqlContext _context;
        private readonly ILogger _logger;

        public DataAccesPostgreSqlProvider(DomainModelPostgreSqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccesPostgreSqlProvider");
        }

        public void Insert(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(int id, Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Persons.First(t => t.idperson == id);
            _context.Persons.Remove(entity);
            _context.SaveChanges();
        }

        public List<Person> GetPersonsList()
        {
            return _context.Persons.ToList();                            //.OrderByDescending(dataEventRecord => EF.Property<DateTime>(dataEventRecord, "UpdatedTimestamp"))
        }

        public List<City> GetCitiesList()
        {
            return _context.Cities.ToList();                            //.OrderByDescending(dataEventRecord => EF.Property<DateTime>(dataEventRecord, "UpdatedTimestamp"))
        }

        public Person GetPerson(int id)
        {
            return _context.Persons.First(t => t.idperson == id);
        }
    }
}
