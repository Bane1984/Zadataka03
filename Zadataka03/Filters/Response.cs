using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.Filters
{
    public class Response
    {
        public object Data { get; set; }
        public bool IsError { get; set; }
        public Error Error { get; set; }
    }
    public class Error
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
