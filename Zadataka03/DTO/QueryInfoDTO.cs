using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.DTO
{
    public class QueryInfoDTO
    {
        public string Id { get; set; }
        public string OsobaId { get; set; }
        public string Osoba { get; set; }
        public string UredjajId { get; set; }
        public string Uredjaj { get; set; }
        public DateTime Uzet { get; set; }
        public DateTime? Vracen { get; set; }

    }
}
