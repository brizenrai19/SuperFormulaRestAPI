using System.Linq.Expressions;

namespace SuperFormulaRestAPI.Helpers
{
    #region Helper
    public static class CustomSort
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> query, string sortField, bool ascending)
        {
            var param = Expression.Parameter(typeof(T), "param");
            var property = Expression.Property(param, sortField);
            var expression = Expression.Lambda(property, param);
            string method = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { query.ElementType, expression.Body.Type };
            var result = Expression.Call(typeof(Queryable), method, types, query.Expression, expression);
            return query.Provider.CreateQuery<T>(result);
        }
    }

    public static class RandomGenerator
    {
        public static int GetRandomNumber(int from, int to, int numberOfElement)
        {
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < numberOfElement)
            {
                numbers.Add(new Random().Next(from, to));
            }
            return numbers.First();
        }

    }
    #endregion
}
