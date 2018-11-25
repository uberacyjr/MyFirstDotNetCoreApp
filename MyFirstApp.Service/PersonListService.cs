using System.Collections.Generic;
using MyFirstApp.Domain;
using System.Linq;
using MyFirstApp.Infrastructure;

namespace MyFirstApp.Service
{
    public class PersonListService
    {
        private SqlQuery<Person> _query;
        public PersonListService(SqlQuery<Person> query)
        {
            _query = query;
        }

        public List<Person> GetAllPersons()
        {
            List<Person> persons = _query.GetAll("SELECT * FROM PERSON").ToList();
            return persons;
        }
    }
}
