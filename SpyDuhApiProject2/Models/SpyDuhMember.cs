using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class SpyDuhMember: Spy
    {
        public List<Spy> Friends { get; set; }
        public List<Spy> Enemies { get; set; }
    }
}
