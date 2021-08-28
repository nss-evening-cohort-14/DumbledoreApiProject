using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class Spy
    {
        public string Alias { get; set; }
        public Guid Id { get; set; }
        public string AboutMe { get; set; }
    }
}
