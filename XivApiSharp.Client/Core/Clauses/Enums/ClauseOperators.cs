namespace XivApiSharp.Client.Core.Clauses.Enums;

/// <summary>
/// Represents the operation that the clause will use to compare its value to.
/// </summary>
/// <seealso cref="Clause{T}"/>
public enum ClauseOperators
{
    PartiallyEqualTo,
    EqualTo,
    LessThan,
    LessThanOrEqualTo,
    GreaterThan,
    GreaterThanOrEqualTo
}