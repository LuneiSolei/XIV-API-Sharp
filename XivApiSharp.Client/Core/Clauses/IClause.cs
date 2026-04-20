namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used as a clause as defined by the XIV API
/// QueryString model. A clause combines a specifier, operator, a value, and
/// an optional decorator.
/// </summary>
public interface IClause
{
    /// <summary>
    /// Name of the field to compare the value against.
    /// </summary>
    internal string Specifier { get; set; }
    
    /// <summary>
    /// The comparison operator to use.
    /// </summary>
    internal ClauseOperators Operator { get; set; }

    /// <summary>
    /// The boolean operator state of the clause.
    /// </summary>
    internal ClauseConditionals Condition { get; set; }
    
    /// <summary>
    /// Converts the specifier, operator, and value of this instance into its
    /// string representation.
    /// </summary>
    /// <remarks>
    /// Clauses have several rules that they must follow.
    /// <list type="number">
    ///     <item>
    ///     Each clause is formed from a <c>[specifier][operator][value]</c>.
    ///     </item>
    ///     <item>
    ///     Multiple clauses are specified by a literal plus (+) sign.*
    ///     </item>
    /// </list>
    /// <br/>
    /// <br/>
    /// *The official documentation states that multiple clauses are separated
    /// by whitespace. However, experimentation has proven that this results in
    /// undesired behavior. Using literal plus signs (+) for multiple clauses
    /// instead of whitespace resolves this issue. By extension, use URI encoded
    /// plus signs (%2B) when using "Must Be" decorated clauses.
    /// </remarks>
    /// <returns>
    /// The string representation of this instance.
    /// </returns>
    string ToString();
}