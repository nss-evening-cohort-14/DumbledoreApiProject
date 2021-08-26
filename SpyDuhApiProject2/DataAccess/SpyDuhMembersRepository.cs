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
                Skills = { "Stealth", "Investigation", "camouflage" },
                Services = {"Breaking in to read people's diaries", "Infiltrating an organization"},
                Friends = new List<SpyDuhMember>
                {
                    new SpyDuhMember
                    {
                        Alias = "Barry",
                        Id = Guid.NewGuid(),
                        AboutMe = "Becoming a spy sounded cool.",
                        Skills = { "Stealth", "Impersonation", "camouflage" },
                        Services = {"Impersonating high-profile people", "Breaking into safes"}
                    }
                },
                Enemies = new List<SpyDuhMember>{
                     new SpyDuhMember
                    {
                        Alias = "Carry",
                        Id = Guid.NewGuid(),
                        AboutMe = "It's fun to do hood rat stuff with your friends.",
                        Skills = { "Stealth", "Armed Robbery", "GTA" },
                        Services = {"Burning your grandmother's cookies", "Infiltrating a book club"}
                    }
                }
            },                      
             new SpyDuhMember
            {
                Alias = "Larry",
                Id = Guid.NewGuid(),
                AboutMe = "I became a spy to take down evil corporations.",
                Skills = { "Hacking", "Investigation", "Impersonation" },
                Services = {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"},
                Friends = new List<SpyDuhMember>
                {
                    new SpyDuhMember
                    {
                        Alias = "Carry",
                        Id = Guid.NewGuid(),
                        AboutMe = "It's fun to do hood rat stuff with your friends.",
                        Skills = { "Stealth", "Armed Robbery", "GTA" },
                        Services = {"Burning your grandmother's cookies", "Infiltrating a book club"}
                    }
                },
                Enemies = new List<SpyDuhMember>{
                     
                     new SpyDuhMember
                    {
                        Alias = "Barry",
                        Id = Guid.NewGuid(),
                        AboutMe = "Becoming a spy sounded cool.",
                        Skills = { "Stealth", "Impersonation", "camouflage" },
                        Services = {"Impersonating high-profile people", "Breaking into safes"}
                    }
                }
            },
        };
        internal void Add(SpyDuhMember spyDuhMember)
        {
            _spyDuhMembers.Add(spyDuhMember);
        }

        internal IEnumerable<SpyDuhMember> GetMemberSkills(SpyDuhMember spyDuhMember)
        {
            return (IEnumerable<SpyDuhMember>)spyDuhMember.Skills;
        }
        internal IEnumerable<SpyDuhMember> GetMemberServices(SpyDuhMember spyDuhMember)
        {
            return (IEnumerable<SpyDuhMember>)spyDuhMember.Services;
        }
    }
}
