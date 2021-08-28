using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class HireASpyCommand
    {
        public double Price { get; set; }
        public string Service { get; set; }
        public double days { get; set; }
        public Guid EmployerId { get; set; }
    }
}
