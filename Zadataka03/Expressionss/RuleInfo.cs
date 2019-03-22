using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace Zadataka03.Expressionss
{
    public class RuleInfo
    {
        public string Property { get; set; }
        //EQ, LT, GTE... - za string samo EQ, za int sve tri
        public string Operator { get; set; }
        public string Value { get; set; }



        private static Expression<Func<TEntity, bool>> GetWhereExpre<TEntity>(string prop, string op, string val)
        {
            // x- parametar
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");

            //x.Property
            MemberExpression property = Expression.Property(parameter, prop);

            var tip = property.Type;
            var konvert = Convert.ChangeType(val, tip);

            // value
            ConstantExpression konstanta = Expression.Constant(val);

            BinaryExpression binarnaEkspresija;
            switch (konvert)
            {
                case int _:
                    binarnaEkspresija = GetBinInt(property, op, konstanta);
                    break;
                case string _:
                    binarnaEkspresija = GetBinString(property, op, konstanta);
                    break;
                default:
                    throw new ArgumentException("Nije kreirana ekspresija za dat.");
            }

            Expression<Func<TEntity, bool>> lambda =
                Expression.Lambda<Func<TEntity, bool>>(binarnaEkspresija, parameter);

            return lambda;
        }

        // nad stringom cemo imati samo EQ
        private static BinaryExpression GetBinString(MemberExpression properti, string op, ConstantExpression konst)
        {
            switch (op.ToUpper())
            {
                case "EQ":
                    return Expression.Equal(properti, konst);
                default:
                    throw new InvalidOperationException("Nedozvoljen operator.");
            }
        }

        // nad int cemo imati EQ, LT, GTE
        private static BinaryExpression GetBinInt(MemberExpression properti, string op, ConstantExpression konst)
        {
            switch (op.ToUpper())
            {
                case "EQ":
                    return Expression.Equal(properti, konst);
                case "LT":
                    return Expression.LessThan(properti, konst);
                case "GTE":
                    return Expression.GreaterThan(properti, konst);
                default:
                    throw new InvalidOperationException("Nedozvoljen operator.");
            }
        }

        //
        public Expression<Func<TEntity, object>> GetOrderBy<TEntity>(string property)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression currentParameter = parameter;

            //zadati properti dijeli na vise elemenata
            string[] allProperties = property.Split(".");
            foreach (string currentProperty in allProperties)
            {
                currentParameter = Expression.Property(currentParameter, currentProperty);
            }

            var convertEx = Expression.Convert(currentParameter, typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(convertEx, parameter);
        }
    }
}
