using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyRepository
    {
        static List<Spy> _spies = new List<Spy>
        {
            new Spy
            {
                Alias = "Harry",
                Id = Guid.Parse("e7c4af1e-c8d4-4998-a611-0b31cc62d312"),
                AboutMe = "I'm super nosy so I became a spy.",
            },
             new Spy
            {
                Alias = "Larry",
                Id = Guid.Parse("11692ac4-9d81-4be5-8fd3-5154b1579a94"),
                AboutMe = "I became a spy to take down evil corporations.",
            },
              new Spy
            {
                Alias = "Barry",
                Id = Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a"),
                AboutMe = "Becoming a spy sounded cool.",
            },
               new Spy
            {
                Alias = "Carry",
                Id = Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274"),
                AboutMe = "It's fun to do hood rat stuff with your friends.",
            },
        };

        internal Spy GetById(Guid spyId)
        {
            return _spies.FirstOrDefault(spy => spy.Id == spyId);
        }

        internal IEnumerable<Spy> GetAll()
        {
            return _spies;
        }
    }
}
