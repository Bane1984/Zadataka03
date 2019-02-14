using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Zadataka03.Models;
using Zadataka03.DTO;

namespace Zadataka03.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }

        //public User(int id, string ime, string prezime, string email)
        //{
        //    Ime = ime;
        //    Prezime = prezime;
        //    Email = email;
        //}
    }
}
