using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <summary>
/// Builds a singular clause for use in a <see cref="QueryString"/>.
/// </summary>
/// <seealso cref="IClause"/>
public sealed class ClauseBuilder : IClauseBuilder
{
    /// <summary>
    /// Creates a new instance of ClauseBuilder(). 
    /// </summary>
    public ClauseBuilder() {}

    /// <inheritdoc/>
    public IWhereSpecifier WhereSpecifier(string name) => 
        new WhereSpecifier(name);
}