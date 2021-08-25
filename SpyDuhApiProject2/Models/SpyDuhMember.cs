using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class SpyDuhMember: Spy
    {
        public List<SpyDuhMember> Friends { get; set; }
        public List<SpyDuhMember> Enemies { get; set; }
    }
}
