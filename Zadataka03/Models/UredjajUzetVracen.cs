using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zadataka03.Models
{
    public class UredjajUzetVracen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UredjajUzetVracenId { get; set; }
        public DateTime Uzet { get; set; }
        public DateTime? Vracen { get; set; }

        public int OsobaId { get; set; }
        [ForeignKey("OsobaId")]
        public Osoba Osoba { get; set; }

        public int UredjajId { get; set; }
        [ForeignKey("UredjajId")]
        public Uredjaj Uredjaj { get; set; }
    }
}
