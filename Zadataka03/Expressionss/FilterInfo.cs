using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.Expressionss
{
    public class FilterInfo
    {
        // AND/OR
        public string Condition { get; set; }
        public List<RuleInfo> Rules { get; set; }
    }
}
