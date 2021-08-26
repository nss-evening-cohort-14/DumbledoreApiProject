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
                Friends = new List<SpyDuhMember>(),
                Enemies = new List<SpyDuhMember>(),
            };
            
            _spyDuhMembersRepository.Add(spyDuhMember);

            return Created($"/api/spyDuhMembers/{spy.Id}", spyDuhMember); 

        }

        [HttpGet] //update url?
        public IActionResult GetSpyDuhMemberSkills(SpyDuhMember member)
        {
            if (member == null)
                return NotFound("There are no matching skills for this SpyDuh Member.");

            return Ok(_spyDuhMembersRepository.GetMemberSkills(member));
        }   
        
        public IActionResult GetSpyDuhMemberServices(SpyDuhMember member)
        {
            if (member == null)
                return NotFound("There are no matching services for this SpyDuh Member.");

            return Ok(_spyDuhMembersRepository.GetMemberServices(member));
        }
        
    }
}
