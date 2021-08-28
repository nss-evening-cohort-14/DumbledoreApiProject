using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class Hire
    {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public Guid HireeId { get; set; }
        public string HireeAlias { get; set; }
        public double Price { get; set; }
        public string Service { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
