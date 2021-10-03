using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyDuhApiProject2.DataAccess;
using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Controllers
{
    [Route("api/spyDuhMembers")]
    [ApiController]
    public class SpyDuhMembersController : ControllerBase
    {
        SpyRepository _spiesRepository;
        SpyDuhMembersRepository _spyDuhMembersRepository;

        public SpyDuhMembersController()
        {
            _spiesRepository = new SpyRepository(); 
            _spyDuhMembersRepository = new SpyDuhMembersRepository();
        }

        [HttpGet]
        public IActionResult GetAllSpyDuhMembers()
        {
            return Ok(_spyDuhMembersRepository.GetAll());
        }

        [HttpPost]
        public IActionResult CreateSpyDuhMember(Guid spyId)
        {
            var spy = _spiesRepository.GetById(spyId);
            if (spy == null) return NotFound("There was no matching spy in the database");

            var memberExistsCheck = _spyDuhMembersRepository.GetById(spyId);
            if (memberExistsCheck != null) return BadRequest("This spy is already a SpyDuh member.");

            var newSpyDuhMember = new SpyDuhMember();
            newSpyDuhMember.Id = spy.Id;
            newSpyDuhMember.Alias = spy.Alias;
            newSpyDuhMember.AboutMe = spy.AboutMe;
            
            _spyDuhMembersRepository.Add(newSpyDuhMember);
            return Created($"/api/spyDuhMembers/{newSpyDuhMember.Id}", newSpyDuhMember); 

        }

        

        //[HttpGet("membersBySkill")]
        //public IActionResult GetMembersBySkill(string skill)
        //{
        //    var foundBySkill = _spyDuhMembersRepository.FindBySkill(skill);

        //    if (foundBySkill.Any() == false)
        //        return NotFound("No members possess this skill.");

        //    return Ok(foundBySkill);      
        //}


        [HttpPost("addFriend/{accountToUpdateId}")]
        public IActionResult AddFriendToSpyDuhAccount(Guid accountToUpdateId, Guid newFriendId, string newFriendAlias)
        {
            var relationshipCheck = _spyDuhMembersRepository.CheckFriendExists(accountToUpdateId, newFriendId);
            if (relationshipCheck == null)
            {
                var updatedMember = _spyDuhMembersRepository.AddFriendToSpyDuhAccount(accountToUpdateId, newFriendId, newFriendAlias);
                return Ok(updatedMember);
            }
            return BadRequest("This friendship already exists.");

        }

        //[HttpPatch("removeFriend/{accountId}")]
        //public IActionResult RemoveFriendFromSpyDuhAccount(Guid accountId, Guid friendId)
        //{
        //    var member = _spyDuhMembersRepository.GetById(accountId);
        //    if (!(member.Friends.Any()) || !(member.Friends.Contains(friendId)))
        //    {
        //        return NotFound("No friends exist, or friend does not exist under this member.");
        //    }
        //    _spyDuhMembersRepository.RemoveFriendFromSpyDuhAccount(accountId, friendId);
        //    return Ok(member);
        //}

        //[HttpPatch("addEnemy/{accountId}")]
        //public IActionResult AddEnemyToSpyDuhAccount(Guid accountId, Guid enemyId)
        //{
        //    _spyDuhMembersRepository.AddEnemyToSpyDuhAccount(accountId, enemyId);
        //    var updatedAccount = _spyDuhMembersRepository.GetById(accountId);
        //    return Ok(updatedAccount);
        //}

        //[HttpPatch("removeEnemy/{accountId}")]
        //public IActionResult RemoveEnemyFromSpyDuhAccount(Guid accountId, Guid enemyId)
        //{
        //    var member = _spyDuhMembersRepository.GetById(accountId);
        //    if (!(member.Enemies.Any()) || !(member.Enemies.Contains(enemyId)))
        //    {
        //        return NotFound("No enemies exist, or enemy does not exist under this member.");
        //    }
        //    _spyDuhMembersRepository.RemoveEnemyFromSpyDuhAccount(accountId, enemyId);
        //    return Ok(member);
        //}

        //[HttpGet("enemies/{accountId}")]
        //public IActionResult ShowEnemiesOfAccount(Guid accountId)
        //{
        //    return Ok(_spyDuhMembersRepository.ShowAccountEnemies(accountId));
        //}
        //[HttpGet("friends/{accountId}")]
        //public IActionResult ShowFriendsOfAccount(Guid accountId)
        //{
        //    return Ok(_spyDuhMembersRepository.ShowAccountFriends(accountId));
        //}

        //[HttpGet("skills")]
        //public IActionResult GetSpyDuhMemberSkills(Guid accountId)
        //{
        //    return Ok(_spyDuhMembersRepository.GetMemberSkills(accountId));
        //}

        //[HttpGet("services")]
        //public IActionResult GetSpyDubMemberServices(Guid accountId)
        //{
        //    return Ok(_spyDuhMembersRepository.GetMemberServices(accountId));
        //}

        //[HttpPatch("addSkill/{accountId}")]
        //public IActionResult AddMemberSkill(Guid accountId, string newSkill)
        //{
        //    return Ok(_spyDuhMembersRepository.AddSkill(accountId, newSkill));
        //}

        //[HttpPatch("removeSkill/{accountId}")]
        //public IActionResult RemoveMemberSkill(Guid accountId, string skill)
        //{
        //    var member = _spyDuhMembersRepository.GetById(accountId);
        //    if (!(member.Skills.Any()) || !(member.Skills.Contains(skill)))
        //    {
        //        return NotFound("No skills exist, or skill does not exist under this member.");
        //    }
        //    return Ok(_spyDuhMembersRepository.RemoveSkill(accountId, skill));
        //}

        //[HttpPatch("addService/{accountId}")]
        //public IActionResult AddMemberService(Guid accountId, string newService)
        //{
        //    return Ok(_spyDuhMembersRepository.AddService(accountId, newService));
        //}

        //[HttpPatch("removeService/{accountId}")]
        //public IActionResult RemoveMemberService(Guid accountId, string service)
        //{
        //    var member = _spyDuhMembersRepository.GetById(accountId);
        //    if (!(member.Services.Any()) || !(member.Services.Contains(service)))
        //    {
        //        return NotFound("No services exist, or service does not exist under this member.");
        //    }
        //    return Ok(_spyDuhMembersRepository.RemoveService(accountId, service));
        //}

    }
}
