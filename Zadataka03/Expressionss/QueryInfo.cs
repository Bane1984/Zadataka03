using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.Expressionss
{
    public class QueryInfo
    {
        // Skip/Take preciziraju koliko podataka preskociti/uzeti
        public int Skip { get; set; }
        public int Take { get; set; }
        //
        public List<SortInfo> Sorters { get; set; }
        public FilterInfo Filter { get; set; }
    }
}
