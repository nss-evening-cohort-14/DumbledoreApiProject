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
        //public Guid Friends { get; set; }
        public IEnumerable<Friend> Friends { get; set; }
        public Guid Enemies { get; set; } 
        public Guid Skills { get; set; }
        public Guid Services { get; set; }
    }

    public class Friend
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
    }
}
