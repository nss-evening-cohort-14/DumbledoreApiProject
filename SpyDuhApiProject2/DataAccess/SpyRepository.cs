using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyRepository
    {

        const string _connectionString = "Server=localhost; Database=SpyDuh; Trusted_Connection=true;";

        internal IEnumerable<Spy> GetAll()
        {
            using var db = new SqlConnection(_connectionString);
            var spies = db.Query<Spy>(@"Select * From Spy");
            return spies;
        }

        internal Spy GetById(Guid spyId)
        {
            using var db = new SqlConnection(_connectionString);

            var sql = @"Select * 
                        From Spy
                        Where Id = @id";
            var spy = db.QuerySingleOrDefault<Spy>(sql, new {id = spyId });

            return spy;
        }

    }
}
