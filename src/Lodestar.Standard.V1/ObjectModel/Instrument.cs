using System.Collections.Generic;

namespace Lodestar.Standard.V1.ObjectModel;

/// <summary>A definition composed of layers.</summary>
public interface IInstrument
{
    /// <summary>Gets the layers composing this instrument.</summary>
    IReadOnlyList<ILayer> Layers { get; }
}
