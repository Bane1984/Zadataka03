using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Models;

namespace Zadataka03.Repositories
{
    public class RKancelarija:Repository<Kancelarija>, IKancelarija
    {
        private readonly ZadatakContext _context;

        public RKancelarija(ZadatakContext context) : base(context)
        {
            _context = context;
        }
    }
}
