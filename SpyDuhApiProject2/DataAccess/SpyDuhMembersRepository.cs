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
                Id = Guid.NewGuid(),
                AboutMe = "I'm super nosy so I became a spy.",
                Skills = new List<string> { "Stealth", "Investigation", "camouflage" },
                Services = new List<string> {"Breaking in to read people's diaries", "Infiltrating an organization"},
                
                // For right now, friends and enemies need to be spies instead of members. Otherwise, we need to includes friends and enemies
                // inside the friends and enemies, and inside those etc. It's like the never ending russian dolls

                Friends = new List<Spy>
                {
                    new Spy
                    {
                        Alias = "Barry",
                        Id = Guid.NewGuid(),
                        AboutMe = "Becoming a spy sounded cool.",
                        Skills = new List<string> { "Stealth", "Impersonation", "camouflage" },
                        Services = new List<string> {"Impersonating high-profile people", "Breaking into safes"}
                    }
                },
                Enemies = new List<Spy>{
                     new Spy
                    {
                        Alias = "Carry",
                        Id = Guid.NewGuid(),
                        AboutMe = "It's fun to do hood rat stuff with your friends.",
                        Skills = new List<string> { "Stealth", "Armed Robbery", "GTA" },
                        Services = new List<string> {"Burning your grandmother's cookies", "Infiltrating a book club"}
                    }
                }
            },
             new SpyDuhMember
            {
                Alias = "Larry",
                Id = Guid.NewGuid(),
                AboutMe = "I became a spy to take down evil corporations.",
                Skills = new List<string> { "Hacking", "Investigation", "Impersonation" },
                Services = new List<string> {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"},
                Friends = new List<Spy>
                {
                    new Spy
                    {
                        Alias = "Carry",
                        Id = Guid.NewGuid(),
                        AboutMe = "It's fun to do hood rat stuff with your friends.",
                        Skills = new List<string> { "Stealth", "Armed Robbery", "GTA" },
                        Services = new List<string> {"Burning your grandmother's cookies", "Infiltrating a book club"}
                    }
                },
                Enemies = new List<Spy>{

                     new Spy
                    {
                        Alias = "Barry",
                        Id = Guid.NewGuid(),
                        AboutMe = "Becoming a spy sounded cool.",
                        Skills = new List<string> { "Stealth", "Impersonation", "camouflage" },
                        Services = new List<string> {"Impersonating high-profile people", "Breaking into safes"}
                    }
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

        internal List<string> GetMemberSkills(Guid memberId)
        {
            var singleMember = _spyDuhMembers.FirstOrDefault(member => member.Id == memberId);
            return singleMember.Skills;
        }

        internal List<string> GetMemberServices(Guid memberId)
        {
            var singleMember = _spyDuhMembers.FirstOrDefault(member => member.Id == memberId);
            return singleMember.Services;
        }
    }
}
