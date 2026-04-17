namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type used to build clauses in a <see cref="QueryString"/>.
/// </summary>
public interface IClauseBuilder : IInitialClauseBuilderStep, IConditionalStep,
    IOperatorStep
{
}