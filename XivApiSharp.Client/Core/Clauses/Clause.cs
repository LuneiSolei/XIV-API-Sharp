using System.Web;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc />
internal sealed class Clause<T> : IClause where T : notnull
{
    /// <summary>
    /// Main constructor for clause.
    /// </summary>
    /// <param name="specifier">The specifier to be compared against.</param>
    /// <param name="op">The comparison operator to perform.</param>
    /// <param name="value">The value to be compared.</param>
    /// <seealso cref="IClause"/>
    public Clause(string specifier, ClauseOperators op, T value)
    {
        Specifier = specifier;
        Operator = op;
        Value = value;
    }
    
    /// <inheritdoc />
    public string Specifier { get; set; }

    /// <inheritdoc />
    public ClauseOperators Operator { get; set; }

    /// <summary>
    /// The value of clause to be compared.
    /// </summary>
    public T Value
    {
        get;
        init
        {
            if (typeof(T) == typeof(string) && value is string s)
            {
                string encoded = $"\"{HttpUtility.UrlEncode(s)}\"";
                field = (T)(object)encoded;

                return;
            }

            field = value;
        }
    }

    /// <inheritdoc cref="IClause.ToString" />
    public override string ToString()
    {
        // Convert boolean values to lowercase because .NET capitalizes them by default.
        string newValue = Value is bool b
            ? b.ToString().ToLowerInvariant()
            : Value?.ToString() ?? string.Empty;
        
        return $"{Specifier}{Operator.Stringify()}{newValue}";
    }
}