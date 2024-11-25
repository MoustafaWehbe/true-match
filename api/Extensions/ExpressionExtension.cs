using System.Linq.Expressions;

namespace api.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TOuter, bool>> Compose<TOuter, TInner>(
            this Expression<Func<TInner, bool>> innerExpression,
            Expression<Func<TOuter, TInner>> outerExpression
        )
        {
            var parameter = Expression.Parameter(typeof(TOuter), "outer");

            var body = Expression.Invoke(
                innerExpression,
                Expression.Invoke(outerExpression, parameter)
            );

            return Expression.Lambda<Func<TOuter, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var parameter = expression.Parameters[0];
            var body = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
