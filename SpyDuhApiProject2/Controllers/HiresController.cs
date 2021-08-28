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
    [Route("api/[controller]")]
    [ApiController]
    public class HiresController : ControllerBase
    {
        HireRepository _hireRepo;
        SpyDuhMembersRepository _memberRepo;
        public HiresController()
        {
            _hireRepo = new HireRepository();
            _memberRepo = new SpyDuhMembersRepository();
        }
        [HttpPost]
        public IActionResult HireASpy(string service, Guid employerId, double price) 
        {
            var findSpy = _memberRepo.FindByService(service);

            var hire = new Hire
            {
                EmployerId = employerId,
                HireeId = findSpy.Id,
                HireeAlias = findSpy.Alias,
                Price = price,
                Service = service
            };

            _hireRepo.Add(hire);
            return Created($"/api/hires/{hire.Id}", hire);
        }
    }
}
