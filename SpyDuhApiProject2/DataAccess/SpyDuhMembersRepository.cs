using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyDuhMembersRepository
    {
        static List<SpyDuhMember> _spyDuhMembers = new List<SpyDuhMember>
        {
            new SpyDuhMember
            {
                Alias = "Harry",
                Id = Guid.Parse("e7c4af1e-c8d4-4998-a611-0b31cc62d312"),
                AboutMe = "I'm super nosy so I became a spy.",
                Skills = new List<string> { "Stealth", "Investigation", "camouflage" },
                Services = new List<string> {"Breaking in to read people's diaries", "Infiltrating an organization"},
                Friends = new List<Guid>
                {
                    Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a")
                },
                Enemies = new List<Guid>
                {
                    Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274")
                }
            },
             new SpyDuhMember
            {
                Alias = "Larry",
                Id = Guid.Parse("11692ac4-9d81-4be5-8fd3-5154b1579a94"),
                AboutMe = "I became a spy to take down evil corporations.",
                Skills = new List<string> { "Hacking", "Investigation", "Impersonation" },
                Services = new List<string> {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"},
                Friends = new List<Guid>
                {
                    Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274")
                },
                Enemies = new List<Guid>
                {
                    Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a")
                }
             }
        };
        internal void Add(SpyDuhMember spyDuhMember)
        {
            _spyDuhMembers.Add(spyDuhMember);
        }

        internal IEnumerable<SpyDuhMember> GetAll()
        {
            return _spyDuhMembers;
        }
    }
}
