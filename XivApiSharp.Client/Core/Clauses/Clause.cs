using System.Web;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc />
internal sealed class Clause<T> : IClause where T : notnull
{
        /// <summary>
    /// The value of clause to be compared.
    /// </summary>
    private T Value { get; }

    /// <summary>
    /// Cache for storing the URI encoded string representation of the instance.
    /// </summary>
    private string UriEncodedCache { get; set; }

    /// <summary>
    /// Cache for storing the unencoded string representation of this instance.
    /// </summary>
    private string UnencodedCache { get; set; }

    /// <summary>
    /// Indicates if the cache needs to be rebuilt.
    /// </summary>
    private bool _isCacheStale;

    /// <inheritdoc/>
    public SchemaLanguage Language
    {
        get;
        set
        {
            _isCacheStale = true;
            field = value;
        }
    }

    /// <inheritdoc />
    public string Specifier
    {
        get;
        set
        {
            _isCacheStale = true;
            field = value;
        }
    }

    /// <inheritdoc />
    public ClauseOperators ClauseOperator
    {
        get;
        set
        {
            _isCacheStale = true;
            field = value;
        }
    }

    /// <inheritdoc/>
    public ClauseDecorators Decorator
    {
        get;
        set
        {
            _isCacheStale = true;
            field = value;
        }
    }
        
    /// <summary>
    /// Main constructor for clause.
    /// </summary>
    /// <param name="specifier">
    /// The specifier to be compared against.
    /// </param>
    /// <param name="op">
    /// The comparison operator to perform.
    /// </param>
    /// <param name="value">
    /// The value to be compared.
    /// </param>
    /// <param name="decorator">
    /// The matching decorator for the clause.
    /// </param>
    /// <param name="lang">
    /// (Optional) The language to use for this Clause.
    /// </param>
    /// <seealso cref="IClause"/>
    public Clause(string specifier, ClauseOperators op, T value, 
        ClauseDecorators decorator, SchemaLanguage lang = SchemaLanguage.None)
    {
        Specifier = specifier;
        ClauseOperator = op;
        Value = value;
        Decorator = decorator;
        Language = lang;
        _isCacheStale = true;
    }

    /// <inheritdoc/>
    public string ToUriEncodedString()
    {
        if (_isCacheStale) RebuildUriEncodedCache();
        
        return UriEncodedCache;
    }

    /// <inheritdoc/>
    public string ToUnencodedString()
    {
        if (_isCacheStale) RebuildUnencodedCache();
        
        return UnencodedCache;
    }

    /// <summary>
    /// Rebuilds the URI encoded string cache for this instance.
    /// </summary>
    private void RebuildUriEncodedCache()
    {
        string encodedDecorator = Decorator.ToUriEncodedString();
        string encodedOperator = ClauseOperator.ToUriEncodedString();
        string encodedSpecifier = HttpUtility.UrlEncode(Specifier);
        string encodedLanguage = string.Empty;
        
        // Use language, if any was provided
        if (Language != SchemaLanguage.None)
        {
            encodedLanguage = HttpUtility.UrlEncode(
                $"@{Language.ToString().ToLower()}");
        }
        
        // Determine new encoded clause value
        string encodedValue = Value switch
        {
            // Convert boolean values to lowercase because .NET capitalizes
            // them by default.
            bool b => b.ToString().ToLowerInvariant(), 
            
            // Encode strings.
            string s => $"\"{HttpUtility.UrlEncode(s)}\"", 
            
            // Anything else gets to be a string without encoding.
            _ => Value.ToString() ?? string.Empty 
        };

        UriEncodedCache = $"{encodedDecorator}{encodedSpecifier}"
                          + $"{encodedLanguage}{encodedOperator}{encodedValue}";
    }

    /// <summary>
    /// Rebuilds the unencoded string cache for this instance.
    /// </summary>
    private void RebuildUnencodedCache()
    {
        string decorator = Decorator.GetStringValue();
        string specifier = Specifier;
        string lang = Language == SchemaLanguage.None ? string.Empty : Language.ToString();
        string clauseOperator = ClauseOperator.GetStringValue();
        string value = Value.ToString() ?? string.Empty;

        UnencodedCache =  $"{decorator}{specifier}{lang}"
                          + $"{clauseOperator}{value}";
    }
}