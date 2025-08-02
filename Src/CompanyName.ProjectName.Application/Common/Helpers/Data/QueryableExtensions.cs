using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyName.ProjectName.Common.Helpers.Data
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyDataRequestParameters<T>(this IQueryable<T> query, DataRequest request)
        {
            // Apply filtering
            if (!string.IsNullOrEmpty(request.FilterBy) && !string.IsNullOrEmpty(request.Filter))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, request.FilterBy);
                var constant = Expression.Constant(request.Filter);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsExpression = Expression.Call(property, containsMethod, constant);
                var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
                query = query.Where(lambda);
            }

            // Apply ordering
            if (!string.IsNullOrEmpty(request.OrderBy))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, request.OrderBy);
                var lambda = Expression.Lambda(property, parameter);
                var methodName = request.Order?.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";
                var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { query.ElementType, property.Type }, query.Expression, Expression.Quote(lambda));
                query = query.Provider.CreateQuery<T>(resultExpression);
            }

            // Apply pagination
            if (request.Page > 0 && request.PageSize > 0)
            {
                query = query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);
            }

            return query;
        }

        public static DataResponse<T> ToDataResult<T>(this IQueryable<T> query, DataRequest request)
        {
            var total = query.Count();
            query = query.ApplyDataRequestParameters(request);
            return new DataResponse<T> { Total = total, Data = query };
        }
    }
}