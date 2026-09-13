using System.Collections.Generic;

namespace Lodestar.Standard.V1.ObjectModel;

/// <summary>A playable top-level configuration containing parts.</summary>
public interface IPerformance
{
    /// <summary>Gets the parts in this performance.</summary>
    IReadOnlyList<IPart> Parts { get; }
}
