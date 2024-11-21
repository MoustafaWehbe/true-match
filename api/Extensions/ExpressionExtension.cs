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
    }
}
