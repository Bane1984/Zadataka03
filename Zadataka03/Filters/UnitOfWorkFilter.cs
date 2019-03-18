using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Zadataka03.UnitOfWork;

namespace Zadataka03.Filters
{
    public class UnitOfWorkFilter:IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var start = false;
            var request = context.HttpContext.Request.Method.Equals("GET");
            var exceptionRequest = context.HttpContext.Request.QueryString;
            _unitOfWork.Start();
            var success = false;

            if (!request)
            {
                _unitOfWork.Start();
                start = true;
            }
            try
            {
                await next();
                if (start)
                {
                    _unitOfWork.Complete();
                    success = true;
                }
            }
            catch (InvalidQuantityException e)
            {
                success = false;
            }
            finally
            {
                if (!request)
                {
                    if (success)
                    {
                        _unitOfWork.Commit();
                        _unitOfWork.Dispose();
                    }
                    else
                    {
                        _unitOfWork.Dispose();
                    }
                }
                
            }

        }
    }
}
