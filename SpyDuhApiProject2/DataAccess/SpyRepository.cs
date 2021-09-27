using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyRepository
    {

        const string _connectionString = "Server=localhost; Database=SpyDuh; Trusted_Connection=true;";
        internal Spy GetById(Guid spyId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"Select * 
                                    From Spy
                                    Where Id = @id";
            command.Parameters.AddWithValue("id", spyId);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return MapFromReader(reader);
            }

            return null;

        }

        internal IEnumerable<Spy> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"Select *
                                    From Spy";
            var reader = command.ExecuteReader();
            var spies = new List<Spy>();

            while (reader.Read())
            {
                var spy = MapFromReader(reader);
                spies.Add(spy);
            }

            return spies;
        }

        Spy MapFromReader(SqlDataReader reader)
        {
            var spy = new Spy();

            spy.Id = reader.GetGuid(0);
            spy.Alias = reader["Alias"].ToString();
            spy.AboutMe = reader["AboutMe"].ToString();

            return spy;
        }
    }
}
