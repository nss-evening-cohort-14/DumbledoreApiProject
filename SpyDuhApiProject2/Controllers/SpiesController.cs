using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyDuhApiProject2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SpyDuhApiProject2.Controllers
{
    [Route("api/spies")]
    [ApiController]
    public class SpiesController : ControllerBase
    {
        SpyRepository _spyRepo;
        public SpiesController(SpyRepository spyRepo) 
        {
            _spyRepo = spyRepo;
        }


        [HttpGet]
        public IActionResult GetAllSpies()
        {
            return Ok(_spyRepo.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetSpyById (Guid id)
        {
            var spy = _spyRepo.GetById(id);

            if (spy == null) return NotFound($"No spy with the id {id} was found.");

            return Ok(spy);
        }
    }
}
