namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents the operation that a group of clauses will use when performing
/// comparisons in the query.
/// </summary>
public enum ClauseGroupOperators
{
    Or,
    Must,
    MustNot
}