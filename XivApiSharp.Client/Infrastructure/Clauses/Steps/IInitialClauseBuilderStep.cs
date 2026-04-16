namespace XivApiSharp.Client.Infrastructure.Clauses.Steps;

public interface IInitialClauseBuilderStep
{
    IConditionStep WhereSpecifier(string name);
}