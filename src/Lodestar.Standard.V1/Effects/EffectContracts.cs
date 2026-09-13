using System.Collections.Generic;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Providers;

namespace Lodestar.Standard.V1.Effects;

public interface IEffectDefinition
{
    LodestarId Id { get; }
    ProviderId ProviderId { get; }
    string PayloadVersion { get; }
    IReadOnlyList<LodestarId> ResourceIds { get; }
    string PayloadJson { get; }
}

/// <summary>Reusable configuration owned by exactly one Effect Provider.</summary>
public interface IEffectPresetDefinition
{
    LodestarId Id { get; }
    IAssetMetadata Metadata { get; }
    ProviderId ProviderId { get; }
    string PayloadVersion { get; }
    IReadOnlyList<LodestarId> ResourceIds { get; }
    string PayloadJson { get; }
}

public interface IInsertSlotDefinition
{
    LodestarId Id { get; }
    bool Bypass { get; }
    /// <summary>Host-owned dry/processed mix in 0..1; defaults to 1.</summary>
    double WetDry { get; }
    bool Optional { get; }
    LodestarId? EffectPresetId { get; }
    IEffectDefinition? Effect { get; }
}

public interface IEffectChainDefinition
{
    LodestarId Id { get; }
    IAssetMetadata Metadata { get; }
    IReadOnlyList<IInsertSlotDefinition> Slots { get; }
}
