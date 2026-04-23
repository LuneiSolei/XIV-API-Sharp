namespace XivApiSharp.Client.Core;

/// <summary>
/// Represents a type that is the base type for all clauses related to
/// <see cref="QueryString"/>.
/// </summary>
public interface IClauseElement
{
    /// <summary>
    /// Converts this instance into its URI encoded string representation.
    /// </summary>
    /// <remarks>
    /// All strings are automatically URI encoded by default. To retrieve an
    /// unencoded string, use <see cref="ToUnencodedString"/> instead.
    /// </remarks>
    /// <returns>
    /// The URI encoded string representation of this instance.
    /// </returns>
    /// <seealso cref="ToUnencodedString"/>
    string ToUriEncodedString();

    /// <summary>
    /// Converts this instance into its unencoded string representation.
    /// </summary>
    /// <remarks>
    /// To retrieve a URI encoded version, use <see cref="ToUriEncodedString"/> instead.
    /// </remarks>
    /// <returns>
    /// The unencoded string representation of this instance. 
    /// </returns>
    /// <seealso cref="ToUriEncodedString"/>
    string ToUnencodedString();
}