using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Atributi;
using Zadataka03.Models;

namespace Zadataka03.Repositories
{
    [Univerzalni]
    public class RUredjaj:Repository<Uredjaj>, IUredjaj
    {
        private readonly ZadatakContext _context;

        public RUredjaj(ZadatakContext context) : base(context)
        {
            _context = context;
        }
    }
}
