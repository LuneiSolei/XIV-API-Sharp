using XivApiSharp.Client.Core.ClauseGroups;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Application;

public interface IXivApiService
{

    /// <summary>
    /// Creates a new instance of ClauseBuilder.
    /// </summary>
    /// <returns>
    /// The interface for ClauseBuilder.
    /// </returns>
    /// <seealso cref="IClauseBuilder"/>
    IClauseBuilder NewClause();

    /// <summary>
    /// Creates a new instance of <see cref="IClauseGroupBuilder"/>
    /// </summary>
    /// <returns>A new instance of a clause group builder.</returns>
    IClauseGroupBuilder NewClauseGroup();
}