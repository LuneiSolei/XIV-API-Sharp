namespace XivApiSharp.Tests.Options.ClauseConfigs.ClauseTestTypes;

public class StringClauseTestType : BaseClauseTestType<string>
{
    public override string Value { get; set; } = null!;
}