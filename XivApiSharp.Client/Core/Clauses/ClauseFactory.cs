namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc/>
internal class ClauseFactory : IClauseFactory
{
    /// <inheritdoc/>
    IClause IClauseFactory.CreateClause<T>(string specifier, ClauseOperators op,
        T value)
    {
        Clause<T> clause = new() { Specifier = specifier, 
            Operator = op, Value = value };
        
        return clause;
    }
}