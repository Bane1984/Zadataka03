using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Models;

namespace Zadataka03.Repositories
{
    public class RUredjajUzetVracen:Repository<UredjajUzetVracen>,IUredjajUzetVracen
    {
        private readonly ZadatakContext _context;

        public RUredjajUzetVracen(ZadatakContext context) : base(context)
        {
            _context = context;
        }
    }
}
