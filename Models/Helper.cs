using _5_Gusarova_Pr_25._106.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Gusarova_Pr_25._106
{
    internal class Helper
    {
        private static Entities _context;

        public static Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities();
            }
            return _context;
        }
    }
}