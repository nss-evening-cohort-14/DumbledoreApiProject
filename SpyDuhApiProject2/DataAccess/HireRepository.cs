using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.DataAccess
{
    public class HireRepository
    {
        static List<Hire> _hires = new List<Hire>();

        internal void Add(Hire hire)
        {
            hire.Id = Guid.NewGuid();
            _hires.Add(hire);
        }
    }
}
