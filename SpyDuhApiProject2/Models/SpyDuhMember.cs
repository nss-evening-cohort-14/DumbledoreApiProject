using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class SpyDuhMember
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string AboutMe { get; set; }
        public IEnumerable<SpyDuhMemberFriend> Friends { get; set; }
        public Guid Enemies { get; set; } 
        public Guid Skills { get; set; }
        public Guid Services { get; set; }
    }

    public class SpyDuhMemberFriend
    {
        public Guid Id { get; set; }
        public string Alias { get; set; } 
        public Guid SpyDuhMemberId { get; set; }
    }
}
