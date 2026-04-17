using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <inheritdoc/>
internal class InternalInstances(IClauseFactory clauseFactory) : IInternalInstances
{
    /// <inheritdoc/>
    public IClauseFactory ClauseFactory { get; } =  clauseFactory;
}