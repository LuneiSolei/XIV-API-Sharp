using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <summary>
/// Represents a type that provides internal dependencies for XivApiService.
/// </summary>
public interface IInternalDependencies
{
    /// <summary>
    /// An internal instance of ClauseFactory used by XivApiService.
    /// </summary>
    internal IClauseFactory ClauseFactory { get; }
    
}