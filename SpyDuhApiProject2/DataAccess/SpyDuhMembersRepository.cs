using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyDuhMembersRepository
    {
        string _connectionString;

        public SpyDuhMembersRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SpyDuh");
        }
 
        internal void Add(SpyDuhMember newSpyDuhMember)
        {
            using var db = new SqlConnection(_connectionString);
            var sql = @"insert into SpyDuhMembers(Id, Alias, AboutMe)
                        values(@Id, @Alias, @AboutMe)";
            db.Execute(sql, newSpyDuhMember);
        }

        internal IEnumerable<SpyDuhMember> GetAll()
        {
            using var db = new SqlConnection(_connectionString);

            var membersSql = @"select * 
                              from SpyDuhMembers";
            var members = db.Query<SpyDuhMember>(membersSql);

            // get all friends
            var friendsSql = @"Select *
                              From Friends";
            var friends = db.Query<SpyDuhMemberFriend>(friendsSql);

            foreach (SpyDuhMember member in members)
            {
                member.Friends = friends.Where(friend => friend.SpyDuhMemberId == member.Id);
            }
            
            // get all enemies

            // get all skills

            // get all services


            return members;
        }



        internal SpyDuhMember GetById(Guid spyDuhId)
        {
            using var db = new SqlConnection(_connectionString);

            var memberSql = @"Select * 
                              From SpyDuhMembers 
                              where Id = @id";

            var member = db.QuerySingleOrDefault<SpyDuhMember>(memberSql, new { id = spyDuhId });
            
            if (member == null) return null;

            // get member's friends

            var friendSql = @"Select *
                              From Friends 
                              where SpyDuhMemberId = @memberId";

            var friends = db.Query<SpyDuhMemberFriend>(friendSql, new { memberId = spyDuhId });

            member.Friends = friends;

            // get member's enemies

            // get member's skills

            // get member's services

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
