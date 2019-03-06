using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zadataka03.Filters;
using Zadataka03.Models;

namespace Zadataka03.Repositories
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly ZadatakContext _context;

        public Repository(ZadatakContext context)
        {
            _context = context; 
        }

        public T GetId(int id)
        {
            var svi = _context.Set<T>().Find(id);
            if (svi == null)
            {
                throw new InvalidQuantityException("Trazeni entitet nije pronadjen."); //eksepsn koji sam kreirao u Filters
            }
            return svi;
        }

        public IEnumerable<T> GetAll()
        {
            var sve = _context.Set<T>().ToList();
            return sve;
        }

        public void Create(T entitet)
        {
            _context.Set<T>().Add(entitet);
        }

        public void Update(int id, T entitet)
        {
            var ureFind = _context.Set<T>().Find(id);
            if (ureFind == null)
            {
                throw new InvalidQuantityException("Trazeni entitet nije pronadjen.");
            }
            var apdejtuj = _context.Set<T>().Attach(entitet);
            apdejtuj.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var find = _context.Set<T>().Find(id);
            //ovdje ubaciti eksepsn
            if (find == null)
            {
                throw new InvalidQuantityException("Trazeni entitet nije pronadjen.");
            }
            _context.Set<T>().Remove(find);
        }
    }
}
