using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyDuhMembersRepository
    {
        const string _connectionString = "Server=localhost; Database=SpyDuh; Trusted_Connection=true;";
 
        static List<SpyDuhMember> _spyDuhMembers = new List<SpyDuhMember>
        {
            new SpyDuhMember
            {
                Alias = "Harry",
                Id = Guid.Parse("e7c4af1e-c8d4-4998-a611-0b31cc62d312"),
                AboutMe = "I'm super nosy so I became a spy.",
                /*Skills = new List<string> { "Stealth", "Investigation", "camouflage" },
                Services = new List<string> {"Breaking in to read people's diaries", "Infiltrating an organization"},
                Friends = new List<Guid>
                {
                    Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a")
                },
                Enemies = new List<Guid>
                {
                    Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274")
                }*/
            },
             new SpyDuhMember
            {
                Alias = "Larry",
                Id = Guid.Parse("11692ac4-9d81-4be5-8fd3-5154b1579a94"),
                AboutMe = "I became a spy to take down evil corporations.",
                //Skills = new List<string> { "hacking", "investigation", "impersonation" },
                //Services = new List<string> {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"},
                //Friends = new List<Guid>
                //{
                //    Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274")
                //},
                //Enemies = new List<Guid>
                //{
                //    Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a")
                //}
             }
        };

        internal void Add(SpyDuhMember newSpyDuhMember)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"insert into SpyDuhMembers(Id, Alias, AboutMe)
                                    values(@Id, @Alias, @AboutMe)";

            command.Parameters.AddWithValue("Id", newSpyDuhMember.Id);
            command.Parameters.AddWithValue("Alias", newSpyDuhMember.Alias);
            command.Parameters.AddWithValue("AboutMe", newSpyDuhMember.AboutMe);

            command.ExecuteNonQuery();
          
        }

        internal IEnumerable<SpyDuhMember> GetAll()
        {
            using var db = new SqlConnection(_connectionString);

            var sql = @"select * 
                        from SpyDuhMembers";
            var members = db.Query<SpyDuhMember>(sql);

            return members;
        }

        //internal IEnumerable<SpyDuhMember> FindBySkill(string skill)
        //{
        //    var foundBySkill = _spyDuhMembers.Where(member => member.Skills.ConvertAll(skill => skill.ToLower()).Contains(skill.ToLower()));
        //    return foundBySkill;
        //}

        //internal SpyDuhMember FindByService(string service)
        //{
        //    var foundByService = _spyDuhMembers.FirstOrDefault(member => member.Services.ConvertAll(service => service.ToLower()).Contains(service.ToLower()));
        //    return foundByService;
        //}

        internal SpyDuhMember GetById(Guid spyDuhId)
        {
            using var db = new SqlConnection(_connectionString);

            var sql = @"Select * 
                        From SpyDuhMembers 
                        where Id = @id";

            var member = db.QuerySingleOrDefault<SpyDuhMember>(sql, new { id = spyDuhId });

            return member;

        }

        internal object CheckFriendExists(Guid spyDuhMemberId, Guid friendsId)
        {
            using var db = new SqlConnection(_connectionString);

            var sql = @"select * from Friends
                        Where SpyDuhMemberId = @id and 
                              FriendsId = @friendId";
            var relationshipCheck = db.QueryFirstOrDefault(sql, new { id = spyDuhMemberId, friendId = friendsId });
            return relationshipCheck;
        }
        internal object AddFriendToSpyDuhAccount(Guid spyDuhMemberId, Guid friendsId, string friendsAlias)
        {
            using var db = new SqlConnection(_connectionString);

            var sql = @"insert into Friends (SpyDuhMemberId, FriendsId, FriendsAlias)
                        output inserted.SpyDuhMemberId
	                    values(@id, @friendId, @friendAlias)";
            var parameters = new DynamicParameters();
            parameters.Add("id", spyDuhMemberId);
            parameters.Add("friendId", friendsId);
            parameters.Add("friendAlias", friendsAlias);
            var updatedMember = db.ExecuteScalar(sql, parameters);

            return updatedMember;
        }

        //internal void RemoveFriendFromSpyDuhAccount(Guid accountId, Guid friendId)
        //{
        //    var repo = new SpyDuhMembersRepository();
        //    var spyDuhMember = repo.GetById(accountId);
        //    spyDuhMember.Friends.Remove(friendId);
        //}
        //internal void AddEnemyToSpyDuhAccount(Guid accountId, Guid enemyId)
        //{
        //    var repo = new SpyDuhMembersRepository();
        //    var spyDuhMember = repo.GetById(accountId);
        //    spyDuhMember.Enemies.Add(enemyId);
        //}
        //internal void RemoveEnemyFromSpyDuhAccount(Guid accountId, Guid enemyId)
        //{
        //    var repo = new SpyDuhMembersRepository();
        //    var spyDuhMember = repo.GetById(accountId);
        //    spyDuhMember.Enemies.Remove(enemyId);
        //}

        //internal List<Guid> ShowAccountEnemies(Guid accountId)
        //{
        //    var repo = new SpyDuhMembersRepository();
        //    var spyDuhMember = repo.GetById(accountId);
        //    return spyDuhMember.Enemies;
        //}

        //internal List<Guid> ShowAccountFriends(Guid accountId)
        //{
        //    var repo = new SpyDuhMembersRepository();
        //    var spyDuhMember = repo.GetById(accountId);
        //    return spyDuhMember.Friends;
        //}

        //internal List<string> GetMemberSkills(Guid accountId)
        //{
        //    var singleMember = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
        //    return singleMember.Skills;
        //}

        //internal List<string> GetMemberServices(Guid accountId)
        //{
        //    var singleMember = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
        //    return singleMember.Services;
        //}

        //internal List<string> AddSkill(Guid accountId, string newSkill)
        //{
        //    var member = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
        //    member.Skills.Add(newSkill);
        //    return (member.Skills);
        //}

        //internal List<string> RemoveSkill(Guid accountId, string skill)
        //{
        //    var member = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
        //    member.Skills.Remove(skill);
        //    return (member.Skills);
        //}

        //internal List<string> AddService(Guid accountId, string newService)
        //{
        //    var member = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
        //    member.Services.Add(newService);
        //    return (member.Services);
        //}

        //internal List<string> RemoveService(Guid accountId, string service)
        //{
        //    var member = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
        //    member.Services.Remove(service);
        //    return (member.Services);
        //}

        SpyDuhMember MapFromReader(SqlDataReader reader)
        {
            var spyDuhMember = new SpyDuhMember();

            spyDuhMember.Id = reader.GetGuid(0);
            spyDuhMember.Alias = reader["Alias"].ToString();
            spyDuhMember.AboutMe = reader["AboutMe"].ToString();
            //spyDuhMember.Skills = reader.GetGuid(3);
            //spyDuhMember.Services = reader.GetGuid(4);
            //spyDuhMember.Friends = reader.["Friends"];
            //spyDuhMember.Enemies = reader.GetGuid(6);

            return spyDuhMember;
        }
    }
}
