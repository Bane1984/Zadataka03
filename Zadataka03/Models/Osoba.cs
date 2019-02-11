using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Zadataka03.Models;

namespace Zadataka03.Models
{
    public class Osoba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        
        public int KancelarijaId { get; set; }
        [ForeignKey("KancelarijaId")]
        public Kancelarija Kancelarija { get; set; }

        public IList<UredjajUzetVracen> UzetiUredjaji { get; set; }
    }
}
