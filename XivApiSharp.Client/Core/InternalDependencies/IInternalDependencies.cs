using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.InternalDependencies;

/// <summary>
/// Represents a type that provides internal dependencies for XivApiService.
/// </summary>
public interface IInternalDependencies
{
    /// <summary>
    /// An internal instance of concrete type implementing IClauseFactory
    /// used by XivApiService.
    /// </summary>
    internal IClauseFactory ClauseFactory { get; }
}