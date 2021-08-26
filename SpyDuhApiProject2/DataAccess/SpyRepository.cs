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
                Id = Guid.NewGuid(),
                AboutMe = "I'm super nosy so I became a spy.",
                Skills = new List<string>{ "Stealth", "Investigation", "camouflage" },
                Services = new List<string>{"Breaking in to read people's diaries", "Infiltrating an organization"}
            },
             new Spy
            {
                Alias = "Larry",
                Id = Guid.NewGuid(),
                AboutMe = "I became a spy to take down evil corporations.",
                Skills = new List<string> { "Hacking", "Investigation", "Impersonation" },
                Services = new List<string> {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"}
            },
              new Spy
            {
                Alias = "Barry",
                Id = Guid.NewGuid(),
                AboutMe = "Becoming a spy sounded cool.",
                Skills = new List<string> { "Stealth", "Impersonation", "camouflage" },
                Services = new List<string> {"Impersonating high-profile people", "Breaking into safes"}
            },
               new Spy
            {
                Alias = "Carry",
                Id = Guid.NewGuid(),
                AboutMe = "It's fun to do hood rat stuff with your friends.",
                Skills = new List<string> { "Stealth", "Armed Robbery", "GTA" },
                Services = new List<string> {"Burning your grandmother's cookies", "Infiltrating a book club"}
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
