using Lodestar.Standard.V1.Sources;

namespace Lodestar.Standard.V1.ObjectModel;

/// <summary>A constituent of an instrument that refers to a source.</summary>
public interface ILayer
{
    /// <summary>Gets the source used by this layer.</summary>
    ISource Source { get; }
}
