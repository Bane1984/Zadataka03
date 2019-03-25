using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Atributi;
using Zadataka03.Models;
using Zadataka03.Repositories;

namespace Zadataka03.Repositories
{
    //[Univerzalni]
    public class ROsoba:Repository<Osoba>, IOsoba
    {
        private readonly ZadatakContext _context;

        public ROsoba(ZadatakContext context):base(context)
        {
            _context = context;
        }

    }
}
