using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zadataka03.DTO
{
    public class UredjajUzetVracenDTO
    {
        public DateTime Uzet { get; set; }
        public DateTime? Vracen { get; set; }
    }
}
