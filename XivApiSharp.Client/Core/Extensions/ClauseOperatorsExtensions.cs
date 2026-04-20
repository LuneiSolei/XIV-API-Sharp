using System.Web;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.Extensions;

/// <summary>
/// Extension methods for <see cref="ClauseOperators"/>.
/// </summary>
internal static class ClauseOperatorsExtensions
{
    extension(ClauseOperators op)
    {
        /// <summary>
        /// Converts the instance into its string representation.
        /// </summary>
        /// <returns>
        /// The symbol(s) that represent the operator in the
        /// <see cref="QueryString"/>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Indicates that an invalid operator option was used.
        /// </exception>
        public string Stringify()
        {
            return op switch
            {
                ClauseOperators.Equal => "=",
                ClauseOperators.PartiallyEqual => "~",
                ClauseOperators.LessThan => "<",
                ClauseOperators.LessThanOrEqual => "<=",
                ClauseOperators.GreaterThan => ">",
                ClauseOperators.GreaterThanOrEqual => ">=",
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }

        public string ToString()
        {
            return op switch
            {
                ClauseOperators.Equal => HttpUtility.UrlEncode("="),
                ClauseOperators.PartiallyEqual => HttpUtility.UrlEncode("~"),
                ClauseOperators.GreaterThan => HttpUtility.UrlEncode(">"),
                ClauseOperators.LessThan => HttpUtility.UrlEncode("<"),
                ClauseOperators.LessThanOrEqual =>
                    HttpUtility.UrlEncode("<="),
                ClauseOperators.GreaterThanOrEqual =>
                    HttpUtility.UrlEncode(">="),
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    }
}