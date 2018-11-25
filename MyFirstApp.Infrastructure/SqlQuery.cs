using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Options;
using MyFirstApp.Domain;

namespace MyFirstApp.Infrastructure
{
    public class SqlQuery<T> where T : class
    {
        private ConnectionHelper ConnectionString { get; set; }
        public SqlQuery(IOptions<ConnectionHelper> config)
        {
            ConnectionString = config.Value;
        }
        public IEnumerable<T> GetAll(string query) 
        {
            using (var sqlConn = new SqlConnection(ConnectionString.DefaultConnection))
            {
                var queryResult = sqlConn.Query<T>(query).ToList();
                return queryResult;
            }
        }
    }
}
