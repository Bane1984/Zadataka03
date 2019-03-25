using System.Collections.Generic;

namespace Zadataka03.Expressionss
{
    public class FilterInfo
    {
        // AND/OR
        public string Condition { get; set; }
        public List<RuleInfo> Rules { get; set; } = new List<RuleInfo>();
    }
}
