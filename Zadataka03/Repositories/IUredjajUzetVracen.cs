using System.Linq;
using Zadataka03.Expressionss;
using Zadataka03.Models;

namespace Zadataka03.Repositories
{
    public interface IUredjajUzetVracen:IRepository<UredjajUzetVracen>
    {
        IQueryable QueryInfooo(QueryInfo input);
    }
}
