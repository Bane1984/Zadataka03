using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.Atributi
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Univerzalni:Attribute
    {
        public DIEnum Name { get; }

        public Univerzalni(DIEnum name = DIEnum.Transient)
        {
            this.Name = name;
        }
    }
}
