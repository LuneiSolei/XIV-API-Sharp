using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc/>
internal sealed class WhereSpecifier(string specifier, 
    IClauseFactory clauseFactory) : IWhereSpecifier
{
    /// <summary>
    /// The name of the specifier to be compared.
    /// </summary>
    private readonly string _specifier = specifier;
    
    /// <inheritdoc/>
    public IWithConditional Must
    {
        get => new WithConditional(_specifier, 
            ClauseConditionals.Must, clauseFactory);
    }

    /// <inheritdoc/>
    public IWithConditional MustNot
    {
        get => new WithConditional(_specifier, 
            ClauseConditionals.MustNot, clauseFactory);
    }
}