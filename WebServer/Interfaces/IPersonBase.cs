using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interfaces
{
    public interface IPersonBase
    {
        List<City> GetCitiesList();
        List<Person> GetPersonsList();
        Person GetPerson(int id);
        void Insert(Person item);
        void Update(int id, Person item);
        void Delete(int id);
    }
}
