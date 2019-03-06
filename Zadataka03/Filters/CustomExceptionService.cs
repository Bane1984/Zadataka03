using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace Zadataka03.Filters
{
    public class CustomExceptionService : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var error = new Error
            {
                Message = context.Exception.Message,
                Exception = context.Exception.Data.ToString(),
                StackTrace = context.Exception.StackTrace
            };

            //ukoliko pokusamo da izbrisemo zapis iz tabele koja ima PK, a zapis koji se brise referencira se kao FK u drugoj tabli
            //Msg 547
            if (context.Exception.GetBaseException() is SqlException ex)
            {
                if (ex.Number == 547)
                {
                    error.Message = "Ne moze se obrisati sve dok ga koristi druga tabela - Msg 547.";
                }
            }

            var exception = new Response
            {
                Data = null,
                IsError = true,
                Error = error
            };
            context.Result = new ObjectResult(exception);
        }
    }
}
