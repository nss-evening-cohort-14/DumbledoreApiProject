using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class SpyDuhMember: Spy
    {
        public List<Guid> Friends { get; set; }
        public List<Guid> Enemies { get; set; } 
        public List <string> Skills { get; set; }
        public List <string> Services { get; set; }
    }
}
