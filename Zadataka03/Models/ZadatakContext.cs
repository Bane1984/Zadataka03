using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Zadataka03.Models
{
    public class ZadatakContext:DbContext
    {
        //public ZadatakContext(DbContextOptions options) : base(options)
        //{
        //}
        //private static bool _created;

        public ZadatakContext(DbContextOptions<ZadatakContext> options)
            : base(options)
        {
            //if (_created) return;
            //Database.Migrate();
            //_created = true;
        }

        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Kancelarija> Kancelarije { get; set; }
        public DbSet<Uredjaj> Uredjaji { get; set; }
        public DbSet<UredjajUzetVracen> UredjajUzetVraceni { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var jsonString = File.ReadAllText("contact.json");
            //var list = JsonConvert.DeserializeObject<List<Contact>>(jsonString);
            //modelBuilder.Entity<Contact>().HasData(list);
            //var jsonStringLinq = File.ReadAllText("contactLinq.json");
            //var listLinq = JsonConvert.DeserializeObject<List<ContactLinq>>(jsonStringLinq);
            //modelBuilder.Entity<ContactLinq>().HasData(listLinq);

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee { EmployeeId = 1, AddressId = 4, FirstName = "Bane", LastName = "Damjanovic", DateOfBirth = new DateTime(1984, 10, 15), PhoneNumber = "067749312", Email = "bane@gmail.com", Gender = "Male" },
            //    new Employee { EmployeeId = 2, AddressId = 3, FirstName = "Ana", LastName = "Vujovic", DateOfBirth = new DateTime(1985, 10, 8), PhoneNumber = "067068066", Email = "ana@gmail.com", Gender = "Female" },
            //    new Employee { EmployeeId = 3, AddressId = 4, FirstName = "Jole", LastName = "Vujovic", DateOfBirth = new DateTime(1986, 11, 23), PhoneNumber = "067120120", Email = "jole@gmail.com", Gender = "Male" },
            //    new Employee { EmployeeId = 4, AddressId = 4, FirstName = "Sanja", LastName = "Damjanovic", DateOfBirth = new DateTime(1991, 7, 25), PhoneNumber = "066100200", Email = "sanja@gmail.com", Gender = "Female" },
            //    new Employee { EmployeeId = 5, AddressId = 2, FirstName = "Sonja", LastName = "Pavicevic", DateOfBirth = new DateTime(1942, 11, 13), PhoneNumber = "067200110", Email = "sonja@gmail.com", Gender = "Female" },
            //    new Employee { EmployeeId = 6, AddressId = 2, FirstName = "Miki", LastName = "Vujovic", DateOfBirth = new DateTime(1951, 9, 1), PhoneNumber = "067800900", Email = "miki@gmail.com", Gender = "Male" },
            //    new Employee { EmployeeId = 7, AddressId = 3, FirstName = "Branislav", LastName = "Vujovic", DateOfBirth = new DateTime(1955, 3, 27), PhoneNumber = "068500344", Email = "dundo@gmail.com", Gender = "Male" },
            //    new Employee { EmployeeId = 8, AddressId = 1, FirstName = "Sanja", LastName = "Bucalo", DateOfBirth = new DateTime(1980, 6, 2), PhoneNumber = "068504030", Email = "sanjab@gmail.com", Gender = "Femail" },
            //    new Employee { EmployeeId = 9, AddressId = 1, FirstName = "Danijel", LastName = "Bucalo", DateOfBirth = new DateTime(1983, 12, 15), PhoneNumber = "069123456", Email = "danijelb@gmail.com", Gender = "Male" },
            //    new Employee { EmployeeId = 10, AddressId = 1, FirstName = "Nikola", LastName = "Bucalo", DateOfBirth = new DateTime(2000, 4, 30), PhoneNumber = "069654321", Email = "nikolab@gmail.com", Gender = "Male" }
            //    );
            //modelBuilder.Entity<Address>().HasData(
            //    new Address { AddressId = 1, Number = 35, Street = "Marksa i Engelsa", City = "Podgorica", State = "Crna Gora", ZipCode = 81000 },
            //    new Address { AddressId = 2, Number = 51, Street = "sv. Petra Cetinjskog", City = "Podgorica", State = "Crna Gora", ZipCode = 81000 },
            //    new Address { AddressId = 3, Number = 75, Street = "Djure Jaksica", City = "Budva", State = "Crna Gora", ZipCode = 88000 },
            //    new Address { AddressId = 4, Number = 35, Street = "Bijelog Pavla", City = "Danilovgrad", State = "Crna Gora", ZipCode = 82000 }
            //    );
        }
    }
}
