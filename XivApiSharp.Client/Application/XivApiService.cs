using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Application;

/// <summary>
/// Provides functionality to interact with the XIV API.
/// </summary>
/// <seealso href="https://xivapi.com"/>
public class XivApiService
{
    /// <summary>
    /// Stores the options configuration.
    /// </summary>
    /// <seealso cref="XivApiOptions"/>
    private readonly XivApiOptions _opts;
    
    /// <summary>
    /// Stores access to internal dependencies required by XivApiService.
    /// </summary>
    /// <remarks>
    /// This pattern ensures that internal dependencies are encapsulated and not
    /// exposed directly to users.
    /// </remarks>
    /// <seealso cref="IInternalInstances"/>
    private readonly IInternalInstances _internalInstances;

    /// <summary>
    /// Constructor for XivApiService.
    /// </summary>
    /// <param name="opts">
    /// The options configuration used to modify behavior of
    /// the XivApiService.
    /// </param>
    /// <param name="_client">
    /// The HttpClient used for making requests.
    /// </param>
    /// <param name="internalInstances">
    /// The dependencies required by XivApiService.
    /// </param>
    public XivApiService(IOptions<XivApiOptions> opts, HttpClient _client, IInternalInstances internalInstances)
    {
        _opts = opts.Value;
        _internalInstances = internalInstances;
    }

    /// <summary>
    /// Creates a new instance of ClauseBuilder.
    /// </summary>
    /// <returns>
    /// The interface for ClauseBuilder.
    /// </returns>
    /// <seealso cref="IClauseBuilder"/>
    public IClauseBuilder NewClause() => new ClauseBuilder(_internalInstances.ClauseFactory);
}