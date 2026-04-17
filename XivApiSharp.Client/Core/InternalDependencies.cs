using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <inheritdoc/>
internal class InternalDependencies(IClauseFactory clauseFactory) : IInternalDependencies
{
    /// <inheritdoc/>
    public IClauseFactory ClauseFactory { get; } =  clauseFactory;
}