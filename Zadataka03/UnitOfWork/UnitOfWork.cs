using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Zadataka03.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly ZadatakContext _context;
        private IDbContextTransaction trans;

        public UnitOfWork(ZadatakContext context)
        {
            _context = context; 
        }

        public void Start()
        {
            trans = _context.Database.BeginTransaction();
        }
        public void Complete()
        {
           _context.SaveChanges();
        }

        public void Commit()
        {
            trans.Commit();
        }


        public void Dispose()
        {
            trans?.Dispose();
        }
    }
}
