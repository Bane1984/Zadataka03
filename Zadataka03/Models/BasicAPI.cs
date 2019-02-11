using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.Models
{
    public abstract class BasicAPI
    {
        public abstract IActionResult Get();
        public abstract IActionResult Get(int id);
        public abstract IActionResult Put(int id, object cust);
        public abstract IActionResult Post(object obj);
        public abstract IActionResult Delete(int id);
    }
}
