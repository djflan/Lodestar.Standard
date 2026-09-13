using System.Collections.Generic;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Providers;

namespace Lodestar.Standard.V1.Sources;

/// <summary>Persistent provider-neutral source identity and opaque provider payload.</summary>
public interface ISourceDefinition
{
    LodestarId Id { get; }
    ProviderId ProviderId { get; }
    string PayloadVersion { get; }
    LodestarId? PresetId { get; }
    IReadOnlyList<LodestarId> ResourceIds { get; }
    string PayloadJson { get; }
    bool Optional { get; }
}

/// <summary>Reusable configuration owned by exactly one Source Provider.</summary>
public interface ISourcePresetDefinition
{
    LodestarId Id { get; }
    IAssetMetadata Metadata { get; }
    ProviderId ProviderId { get; }
    string PayloadVersion { get; }
    IReadOnlyList<LodestarId> ResourceIds { get; }
    string PayloadJson { get; }
}
