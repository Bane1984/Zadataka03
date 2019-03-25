using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zadataka03.Atributi;
using Zadataka03.Expressionss;
using Zadataka03.Models;

namespace Zadataka03.Repositories
{
    //[Univerzalni]
    public class RUredjajUzetVracen:Repository<UredjajUzetVracen>,IUredjajUzetVracen
    {
        private readonly ZadatakContext _context;

        public RUredjajUzetVracen(ZadatakContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable QueryInfooo([FromBody] QueryInfo input)
        {
            QueryInfo obj = new QueryInfo();
            var result = _context.UredjajUzetVraceni.AsQueryable();
            var ruleInputs = input.Filter.Rules;

            Expression<Func<UredjajUzetVracen, bool>> whereLaqmbdaExpression = null;
            BinaryExpression binWhereExp = null;

            //var filterCondition = input.Filter.Condition;
            ParameterExpression parExp = Expression.Parameter(typeof(UredjajUzetVracen), "x");
            Expression findExp = null;

            foreach (var ruleInput in ruleInputs)
            {


                if (input.Filter.Condition == "and")
                {
                    findExp = Expression.Constant(true);
                    binWhereExp =
                        obj.GetBinary<UredjajUzetVracen>(parExp, ruleInput.Operator, ruleInput.Property, ruleInput.Value);
                    findExp = Expression.AndAlso(findExp, binWhereExp);
                }
                else if (input.Filter.Condition == "or")
                {
                    findExp = Expression.Constant(false);
                    binWhereExp =
                        obj.GetBinary<UredjajUzetVracen>(parExp, ruleInput.Operator, ruleInput.Property, ruleInput.Value);
                    findExp = Expression.OrElse(findExp, binWhereExp);
                }

            }

            whereLaqmbdaExpression = obj.GetWhere<UredjajUzetVracen>(findExp, parExp);

            Expression<Func<UredjajUzetVracen, object>> order = null;
            result = result.Where(whereLaqmbdaExpression);
            var sorters = input.Sorters;
            bool condition = false;
            foreach (var sorter in sorters)
            {
                order = obj.GetOrderBy<UredjajUzetVracen>(sorter.Property, sorter.SortDirection);

                if (sorter.SortDirection.ToLower().Equals("asc"))
                {
                    if (!condition)
                    {
                        result = result.OrderBy(order);
                        condition = true;
                    }
                    else
                    {
                        result = ((IOrderedQueryable<UredjajUzetVracen>)result).ThenBy(order);
                    }

                }
                if (sorter.SortDirection.ToLower().Equals("desc"))
                {
                    if (!condition)
                    {
                        result = result.OrderByDescending(order);
                        condition = true;
                    }
                    else
                    {
                        result = ((IOrderedQueryable<UredjajUzetVracen>)result).ThenByDescending(order);
                    }
                }
            }

            result = result.Skip(input.Skip).Take(input.Take);

            return result;
        }
    }
}
