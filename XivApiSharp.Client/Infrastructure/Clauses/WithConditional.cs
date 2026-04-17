using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc/>
[SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance")]
internal sealed class WithConditional(string specifier, 
    ClauseConditionals condition, IClauseFactory clauseFactory) 
    : IWithConditional
{
    /// <summary>
    /// The name of the specifier to be compared.
    /// </summary>
    private readonly string _specifier = specifier;
    
    /// <summary>
    /// The matching condition with which any returned results from the XIV API
    /// must meet.
    /// </summary>
    private readonly ClauseConditionals _condition = condition;
    
    /// <summary>
    /// The matching operation with which the specifier and value will be
    /// compared.
    /// </summary>
    private ClauseOperators _operator;

    /// <inheritdoc/>
    public IClause PartiallyEqualTo(string value) =>
        BuildClause(ClauseOperators.PartiallyEqualTo, value);

    /// <inheritdoc/>
    public IClause EqualTo(string value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public IClause EqualTo(bool value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public IClause EqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public IClause GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, value);

    /// <inheritdoc/>
    public IClause GreaterThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqualTo, value);

    /// <inheritdoc/>
    public IClause LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, value);

    /// <inheritdoc/>
    public IClause LessThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, value);
    
    /// <summary>
    /// Builds a clause by assigning the specified operator and
    /// <paramref name="value"/> to the clause.
    /// </summary>
    /// <param name="op">The comparison operator to use for the clause.</param>
    /// <param name="value">The value to compare against.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    /// <returns>A fully constructed clause.</returns>
    /// <seealso cref="ClauseOperators"/>
    /// <seealso cref="IClause"/>

    private IClause BuildClause<T>(ClauseOperators op, T value) where T : notnull
    {
        IClause newClause = clauseFactory.CreateClause(_specifier, op, value);

        return newClause;
    }
    
    /// <summary>
    /// Adds the builder's stored specifier to the clause.
    /// </summary>
    /// <param name="clause">The clause to add the specifier to.</param>
    /// <seealso cref="IClause"/>
    private void AddSpecifier(IClause clause)
    {
        string specifier = _condition == ClauseConditionals.MustBe
            ? string.Empty
            : "-";

        specifier += $"{_specifier}";
        clause.Specifier = specifier;
    }

    /// <summary>
    /// Adds the builder's stored operator to the clause.
    /// </summary>
    /// <param name="clause">The clause to add the operator to.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    /// <seealso cref="ClauseOperators"/>
    /// <seealso cref="IClause"/>
    private void AddOperator(IClause clause) =>
        clause.Operator = _operator;
}