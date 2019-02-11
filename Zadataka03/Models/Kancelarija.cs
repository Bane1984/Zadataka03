using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zadataka03.Models
{
    public class Kancelarija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KancelarijaId { get; set;}
        public string Opis { get; set; }

        public IList<Osoba> Osobe { get; set; }
    }
}
