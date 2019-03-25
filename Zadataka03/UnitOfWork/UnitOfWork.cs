using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Zadataka03.Atributi;

namespace Zadataka03.UnitOfWork
{
    //[Univerzalni]
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly ZadatakContext _context;
        private IDbContextTransaction _trans;

        public UnitOfWork(ZadatakContext context)
        {
            _context = context; 
        }

        public void Start()
        {
            _trans = _context.Database.BeginTransaction();
        }
        public void Complete()
        {
           _context.SaveChanges();
        }

        public void Commit()
        {
            _trans.Commit();
        }


        public void Dispose()
        {
            _trans?.Dispose();
        }
    }
}
