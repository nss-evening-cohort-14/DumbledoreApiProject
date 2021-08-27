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

        [HttpPost]
        public IActionResult CreateSpyDuhMember(CreateSpyDuhMemberCommand command)
        {
            var spy = _spiesRepository.GetById(command.SpyId);

            if (spy == null) 
                return NotFound("There was no matching spy in the database");
            var spyDuhMember = new SpyDuhMember 
            {
                Alias = spy.Alias,
                Id = spy.Id,
                AboutMe = spy.AboutMe,
                Skills = spy.Skills,
                Services = spy.Services,
                Friends = new List<Guid>(),
                Enemies = new List<Guid>(),
            };
            
            _spyDuhMembersRepository.Add(spyDuhMember);

            return Created($"/api/spyDuhMembers/{spy.Id}", spyDuhMember); 

        }

        [HttpGet]
        public IActionResult GetAllSpyDuhMembers()
        {
            return Ok(_spyDuhMembersRepository.GetAll());
        }

        [HttpGet("member")]
        public IActionResult GetMembersBySkill(string skill)
        {
            var foundBySkill = _spyDuhMembersRepository.FindBySkill(skill);

            if (foundBySkill == null)
                return NotFound("No members possess this skill.");

            return Ok(foundBySkill);      
        }
        

        [HttpPatch("addFriend/{accountId}")]
        public IActionResult AddFriendToSpyDuhAccount(Guid accountId, Guid friendId)
        {
            _spyDuhMembersRepository.AddFriendToSpyDuhAccount(accountId, friendId);
            var updatedAccount = _spyDuhMembersRepository.GetById(accountId);
            return Ok(updatedAccount);
        }

        [HttpPatch("removeFriend/{accountId}")]
        public IActionResult RemoveFriendFromSpyDuhAccount(Guid accountId, Guid friendId)
        {
            _spyDuhMembersRepository.RemoveFriendFromSpyDuhAccount(accountId, friendId);
            var updatedAccount = _spyDuhMembersRepository.GetById(accountId);
            return Ok(updatedAccount);
        }

        [HttpPatch("addEnemy/{accountId}")]
        public IActionResult AddEnemyToSpyDuhAccount(Guid accountId, Guid enemyId)
        {
            _spyDuhMembersRepository.AddEnemyToSpyDuhAccount(accountId, enemyId);
            var updatedAccount = _spyDuhMembersRepository.GetById(accountId);
            return Ok(updatedAccount);
        }

        [HttpPatch("removeEnemy/{accountId}")]
        public IActionResult RemoveEnemyFromSpyDuhAccount(Guid accountId, Guid enemyId)
        {
            _spyDuhMembersRepository.RemoveEnemyFromSpyDuhAccount(accountId, enemyId);
            var updatedAccount = _spyDuhMembersRepository.GetById(accountId);
            return Ok(updatedAccount);
        }

        [HttpGet("enemies/{accountId}")]
        public IActionResult ShowEnemiesOfAccount(Guid accountId)
        {
            return Ok(_spyDuhMembersRepository.ShowAccountEnemies(accountId));
        }
        [HttpGet("friends/{accountId}")]
        public IActionResult ShowFriendsOfAccount(Guid accountId)
        {
            return Ok(_spyDuhMembersRepository.ShowAccountFriends(accountId));
        }

        [HttpGet("skills")]
        public IActionResult GetSpyDuhMemberSkills(Guid accountId)
        {
            return Ok(_spyDuhMembersRepository.GetMemberSkills(accountId));
        }

        [HttpGet("services")]
        public IActionResult GetSpyDubMemberServices(Guid accountId)
        {
            return Ok(_spyDuhMembersRepository.GetMemberServices(accountId));
        }

    }
}
