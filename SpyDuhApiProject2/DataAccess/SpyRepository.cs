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
                Skills = { "Stealth", "Investigation", "camouflage" },
                Services = {"Breaking in to read people's diaries", "Infiltrating an organization"}
            },
             new Spy
            {
                Alias = "Larry",
                Id = Guid.NewGuid(),
                AboutMe = "I became a spy to take down evil corporations.",
                Skills = { "Hacking", "Investigation", "Impersonation" },
                Services = {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"}
            },
              new Spy
            {
                Alias = "Barry",
                Id = Guid.NewGuid(),
                AboutMe = "Becoming a spy sounded cool.",
                Skills = { "Stealth", "Impersonation", "camouflage" },
                Services = {"Impersonating high-profile people", "Breaking into safes"}
            },
               new Spy
            {
                Alias = "Harry",
                Id = Guid.NewGuid(),
                AboutMe = "I'm super nosy so I became a spy.",
                Skills = { "Stealth", "Investigation", "camouflage" },
                Services = {"Breaking in to read people's diaries", "Infiltrating a book club"}
            },
        };
    }
}
