using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Start();
        void Complete();
        void Commit();
        void Dispose();
    }
}
