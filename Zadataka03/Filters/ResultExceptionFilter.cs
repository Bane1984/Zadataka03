using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Zadataka03.Filters
{
    public class ResultExceptionFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result as ObjectResult;
            if (result != null)
            {
                if (result.StatusCode >= StatusCodes.Status200OK && result.StatusCode <= StatusCodes.Status300MultipleChoices)
                {
                    var response = new Response
                    {
                        Data = result.Value,
                        IsError = false,
                        Error = null
                    };

                    context.Result = new ObjectResult(response);
                }
                else if (result.StatusCode >= StatusCodes.Status400BadRequest && result.StatusCode <= StatusCodes.Status500InternalServerError)
                {
                    var response = new Response
                    {
                        Data = null,
                        IsError = true,
                        Error = new Error
                        {
                            Message = result.Value.ToString(),
                            Exception = null,
                            StackTrace = null
                        }
                    };
                    context.Result = new ObjectResult(response);
                }
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}
