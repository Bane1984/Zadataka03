using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadataka03.DTO
{
    public class OsobaDTO
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public  string ImeUredjaja { get; set; }
        public KancelarijaDTO Kancelarijadto { get; set; }
        public UredjajUzetVracenDTO UredjajUzetVracendto { get; set; }
    }
}
