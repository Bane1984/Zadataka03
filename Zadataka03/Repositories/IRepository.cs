using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetId(int id);
        void Create(T entitet);
        void Update(int id, T entitet);
        void Delete(int id);
    }
}
