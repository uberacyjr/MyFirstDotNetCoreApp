using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using MyFirstApp.Domain;
using System.Linq;

namespace MyFirstApp.Service
{
    public class PersonListService
    {
        private IConfiguration _config;

        public PersonListService(IConfiguration config)
        {
            _config = config;
        }

        public List<Person> GetAllPersons()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            var persons = new List<Person>();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                persons = sqlConn.Query<Person>("SELECT * FROM PERSON").ToList();
            }

            return persons;
        }
    }
}
