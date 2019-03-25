using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;


namespace Zadataka03.Expressionss
{
    public class QueryInfo
    {
        // Skip/Take preciziraju koliko podataka preskociti/uzeti
        public int Skip { get; set; }
        public int Take { get; set; }
        //
        public List<SortInfo> Sorters { get; set; } = new List<SortInfo>();
        public FilterInfo Filter { get; set; }


        public BinaryExpression GetBinary<TEntity>(ParameterExpression parameter, string op, string prop, string val)
        {

            Expression propExp = parameter;
            Expression curExp = parameter;
            var tip = parameter.Type;

            string[] propImena = prop.Split(".");
            foreach (string currentProperty in propImena)
            {

                curExp = Expression.Property(curExp, currentProperty);
                propExp = Expression.Property(propExp, currentProperty);
            }

            var type = propExp.Type;
            var konvert = Convert.ChangeType(val, type);

            ConstantExpression konstanta = Expression.Constant(konvert);
            BinaryExpression binarnaEkspresija;
            switch (konvert)
            {
                case int _:
                    binarnaEkspresija = GetBinInt(op, propExp, konstanta);
                    break;
                case string _:
                    binarnaEkspresija = GetBinString(op, propExp, konstanta);
                    break;
                default:
                    throw new ArgumentException("Nije kreirana ekspresija za dati tip.");
            }

            return binarnaEkspresija;
        }

        public Expression<Func<TEntity, bool>> GetWhere<TEntity>(Expression binary, ParameterExpression parameter)
        {
            var lambda = Expression.Lambda<Func<TEntity, bool>>(binary, parameter);
            return lambda;
        }

        // nad stringom cemo imati samo EQ
        private static BinaryExpression GetBinString(string op, Expression properti, ConstantExpression konst)
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
        private static BinaryExpression GetBinInt(string op, Expression properti, ConstantExpression konst)
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

        ////OrderBy
        //public Expression<Func<TEntity, object>> GetOrderBy<TEntity>(string property)
        //{
        //    ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
        //    Expression trenutniParam = parameter;

        //    var tip = parameter.Type;

        //    //zadati properti dijeli na vise elemenata
        //    string[] allProperties = property.Split(".");
        //    foreach (string trenutniProperty in allProperties)
        //    {
        //        if (PostojanjePropertija(trenutniProperty, tip) == false)
        //        {
        //            throw new Exception($"Properti sa imenom {property} ne postoji u tipu {tip.Name}");
        //        }
        //        trenutniParam = Expression.Property(trenutniParam, trenutniProperty);
        //        tip = parameter.Type;
        //    }

        //    var convertEx = Expression.Convert(trenutniParam, typeof(object));
        //    return Expression.Lambda<Func<TEntity, object>>(convertEx, parameter);
        //}

        //OrderBy - Dejo mi proslijedio sa linka
        public Expression<Func<TEntity, object>> GetOrderBy<TEntity>(string propName, string direction)
        {
            var type = typeof(TEntity);
            var prop = type.GetProperty(propName);
            var param = Expression.Parameter(type);
            var access = Expression.Property(param, prop);
            var convert = Expression.Convert(access, typeof(object));
            var finalExp = Expression.Lambda<Func<TEntity, object>>(convert, param);
            return finalExp;
        }

        //provjera postojanja propertija u tipu
        private bool PostojanjePropertija(string trenutniProp, Type trenutniTip)
        {
            PropertyInfo[] sviProperiji = trenutniTip.GetProperties();
            foreach (var prop in sviProperiji)
            {
                if (prop.Name == trenutniProp)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
