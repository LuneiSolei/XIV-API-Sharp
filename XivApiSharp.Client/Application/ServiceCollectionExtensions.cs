using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Application;

public static class ServiceCollectionExtensions
{
    private const string FileName = "appsettings.json";
    private static IConfiguration _config = null!;
    
    extension(IServiceCollection services)
    {
        public IServiceCollection AddXivApiService(IConfiguration config)
        {
            _config = config;
            services.RegisterCommon();
            
            return services;
        }
        
        public IServiceCollection AddXivApiService()
        {
            services.BuildConfig();
            services.RegisterCommon();

            return services;
        }

        private void BuildConfig()
        {
            ConfigurationBuilder builder = new();
            Assembly assembly = typeof(ServiceCollectionExtensions).Assembly;
            string? resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(n => n.EndsWith(FileName, StringComparison.OrdinalIgnoreCase));

            if (resourceName is not null)
            {
                Stream stream = assembly.GetManifestResourceStream(resourceName)
                                ?? throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");
                builder.AddJsonStream(stream);
            }
            
            // Load default values from appsettings.json
            _config = builder.Build();
        }

        private void RegisterCommon()
        {
            services
                // Configure options
                .Configure<XivApiOptions>(_config.GetSection("XivApiOptions"))
                
                // Add HttpClient 
                .AddHttpClient<XivApiService>((sp, client) =>
                {
                    XivApiOptions opts = sp
                        .GetRequiredService<IOptions<XivApiOptions>>().Value;
                    
                    client.BaseAddress = new Uri($"{opts.Scheme}://{opts.BaseUrl}");
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                })
                .Services
                    
                // Inject dependencies
                .AddScoped<IClauseFactory, ClauseFactory>()
                .AddScoped<IInternalDependencies, InternalDependencies>(sp =>
                {
                    IClauseFactory clauseFactory = sp.GetRequiredService<IClauseFactory>();
                    return new InternalDependencies(clauseFactory);
                })
                .AddScoped<IClauseBuilder, ClauseBuilder>();
        }
    }
}