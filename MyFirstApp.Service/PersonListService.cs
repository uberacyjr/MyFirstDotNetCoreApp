using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using MyFirstApp.Domain;
using System.Linq;
using Microsoft.Extensions.Options;

namespace MyFirstApp.Service
{
    public class PersonListService
    {
        private ConnectionStrings _config;

        public PersonListService(IOptions<ConnectionStrings> config)
        {
            _config = config.Value;
        }

        public List<Person> GetAllPersons()
        {
            var connectionString = _config.DefaultConnection;
            var persons = new List<Person>();

            using (var sqlConn = new SqlConnection(connectionString))
            {
                persons = sqlConn.Query<Person>("SELECT * FROM PERSON").ToList();
            }

            return persons;
        }
    }
}
