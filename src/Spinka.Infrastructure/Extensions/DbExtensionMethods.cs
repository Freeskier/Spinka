using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Infrastructure.Exceptions;

namespace Spinka.Infrastructure.Extensions
{
    public static class DbExtensionMethods
    {
        public static async Task<TEntity> GetBy<TEntity>(this DbContext context, Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            IQueryable<TEntity> set = context.Set<TEntity>();
            set = includeProperties.Aggregate(set, (current, includeProperty) => current.Include(includeProperty));

            var entity = await set.FirstOrDefaultAsync(predicate);

            if (entity != null) 
                return entity;
            
            var entityName = typeof(TEntity).Name;
            var propNameValue = GetPropNameValueFromExpression(predicate);
            throw new EntityNotExistsException(entityName, propNameValue.Value);
        }

        private static KeyValuePair<string, object> GetPropNameValueFromExpression<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            object value;
            string propName;

            var eq = (BinaryExpression)predicate.Body;
            var productToPrice = (MemberExpression)eq.Right;

            var captureToProductConst = productToPrice.Expression as ConstantExpression;
            if (captureToProductConst != null)
            {
                value = ((FieldInfo)productToPrice.Member).GetValue(captureToProductConst.Value);
            }
            else
            {
                var captureToProduct = (MemberExpression)productToPrice.Expression;
                var captureConst = (ConstantExpression)captureToProduct.Expression;
                var product = ((FieldInfo)captureToProduct.Member).GetValue(captureConst.Value);
                value = ((PropertyInfo)productToPrice.Member).GetValue(product, null);
            }


            if (eq.Left is MemberExpression)
            {
                var leftMember = (MemberExpression)eq.Left;
                propName = leftMember.Member.Name;
            }
            else
            {
                //TODO this can be done better, but cannot find type MethodBinaryExpression
                propName = eq.Left.ToString();
            }

            return new KeyValuePair<string, object>(propName, value);
        }

        public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc)
        {
            return items
                .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item);
        }
    }
}