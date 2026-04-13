namespace XivApiSharp.Tests.Options;

public class TestConfig
{
    public ClauseTestOptions EqualToClauseString { get; set; } = new();
    public ClauseTestOptions PartiallyEqualToClauseString { get; set; } = new();
    public ClauseTestOptions GreaterThanClauseString { get; set; } = new();
}