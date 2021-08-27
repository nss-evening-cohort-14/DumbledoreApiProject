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
                Friends = new List<Spy>(),
                Enemies = new List<Spy>(),
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
        
    }
}
