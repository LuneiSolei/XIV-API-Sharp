using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <summary>
/// Represents a type that is used to build clause groups.
/// </summary>
internal interface IClauseGroupFactory
{
    /// <summary>
    /// Creates a new instance of a clause group with the provided clauses.
    /// </summary>
    /// <param name="clauses">
    /// The clauses to instantiate the clause group with.
    /// </param>
    /// <returns>
    /// The created clause group.
    /// </returns>
    /// <seealso cref="IClauseGroup"/>
    IClauseGroup CreateClauseGroup(IEnumerable<IClause> clauses);
}