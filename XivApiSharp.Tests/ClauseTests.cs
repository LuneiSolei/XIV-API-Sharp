using XivApiSharp.Client.Core;
using XivApiSharp.Client.Services;
using XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[TestFixture]
public class ClauseTests
{
    private static IEnumerable<TestCaseData> ClauseTestCases()
    {
        TestConfig config = AssemblySetup.TestConfig;

        yield return new TestCaseData(
            config.EqualToClauseString,
            (Func<IOperatorStep, string, Clause>)((step, value) =>
                step.EqualTo(value)))
            .SetName("EqualToString");
        
        yield return new TestCaseData(
            config.PartiallyEqualToClauseString,
            (Func<IOperatorStep, string, Clause>)((step, value) =>
                step.PartiallyEqualTo(value)))
            .SetName("PartiallyEqualToString");
        
        yield return new TestCaseData(
            config.GreaterThanClauseString, 
            (Func<IOperatorStep, string, Clause>)((step, value) =>
                step.GreaterThan(value)))
            .SetName("GreaterThanString");
    }

    [TestCaseSource(nameof(ClauseTestCases))]
    public void NewClause_BuildsCorrectly(
        ClauseTestOptions opts,
        Func<IOperatorStep, string, Clause> buildClause)
    {
        Clause clause = buildClause(
            XivApiService.NewClause()
                .WhereSpecifier(opts.Specifier)
                .Is(), 
            opts.Value);
        
        Assert.That(clause.ToString(), 
            Is.EqualTo(opts.ExpectedValue));
    }
}