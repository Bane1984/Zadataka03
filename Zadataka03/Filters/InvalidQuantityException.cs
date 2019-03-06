using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Zadataka03.Filters
{
    //korisnicki definisan exception koji se nasledjuj iz klase Exception koja ukljucuje 3 konstruktora - koja se moraju naslijediti
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException()
        {

        }

        public InvalidQuantityException(string message) : base(message)
        {

        }

        public InvalidQuantityException(string message, Exception innerException) : base(message, innerException)
        {

        }


    }
}
