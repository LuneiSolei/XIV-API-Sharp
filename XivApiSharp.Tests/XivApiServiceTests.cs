using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[TestFixture]
public class XivApiServiceTests
{
    // Storage Variables
    private readonly IServiceCollection _services = new ServiceCollection();
    private ServiceProvider _provider;
    private XivApiService _service;
    private XivApiOptions _options;
    private readonly HttpClient _client = new();
    
    [OneTimeSetUp]
    public void Setup()
    {
        _services.AddXivApiService();
        _provider = _services.BuildServiceProvider();
        _service = _provider.GetRequiredService<XivApiService>();
        _options = _provider.GetRequiredService<XivApiOptions>();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _provider.Dispose();
        _client.Dispose();
    }

    [Test]
    public void NewClause_EqualToString_BuildsCorrectly()
    {
        ClauseTestOptions testOpts = AssemblySetup.TestConfig.EqualToClauseString;
        
        Clause clause = XivApiService.NewClause()
            .WhereSpecifier(testOpts.Specifier)
            .Is()
            .EqualTo(testOpts.Value);

        Assert.That(clause.ToString(), 
            Is.EqualTo(testOpts.ExpectedValue));
    }

    [Test]
    public void NewClause_PartiallyEqualToString_BuildsCorrectly()
    {
        ClauseTestOptions testOpts = AssemblySetup.TestConfig
            .PartiallyEqualToClauseString;
        
        Clause clause = XivApiService.NewClause()
            .WhereSpecifier(testOpts.Specifier)
            .Is()
            .PartiallyEqualTo(testOpts.Value);

        Assert.That(clause.ToString(), 
            Is.EqualTo(testOpts.ExpectedValue));
    }

    [Test]
    public void NewClause_GreaterThanString_BuildsCorrectly()
    {
        ClauseTestOptions testOpts = AssemblySetup.TestConfig
            .GreaterThanClauseString;
        
        Clause clause = XivApiService.NewClause()
            .WhereSpecifier(testOpts.Specifier)
            .Is()
            .GreaterThan(testOpts.Value);
        
        Assert.That(clause.ToString(),
            Is.EqualTo(testOpts.ExpectedValue));
    }
}