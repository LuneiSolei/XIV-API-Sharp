using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XivApiSharp.Client.Application;
using XivApiSharp.Tests.Options;

namespace XivApiSharp.Tests;

[SetUpFixture]
internal class TestsSetup
{
    internal static TestConfig TestConfig { get; } = new();
    internal readonly static XivApiService ApiService;

    static TestsSetup()
    {
        ConfigureOptions();
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddXivApiService()
            .BuildServiceProvider();
        ApiService = serviceProvider.GetRequiredService<XivApiService>();
    }

    private static void ConfigureOptions()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        config.GetSection(nameof(TestConfig)).Bind(TestConfig);
        
        // Require all values be filled in appsettings.json
        List<ValidationResult> validationResults = [];
        bool isValid = Validator.TryValidateObject(
            TestConfig,
            new ValidationContext(TestConfig),
            validationResults,
            validateAllProperties: true);
        
        if (isValid) return;
        
        string errors = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
        throw new InvalidOperationException($"TestConfig is invalid: {errors}");
    }
}