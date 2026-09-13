using System.Collections.Generic;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Providers;

namespace Lodestar.Standard.V1.Effects;

public interface IEffectDefinition
{
    ProviderId ProviderId { get; }
    string? PayloadVersion { get; }
    IReadOnlyList<string> RequiredCapabilities { get; }
    string PayloadJson { get; }
}

public interface IInsertSlotDefinition
{
    LodestarId Id { get; }
    bool Bypass { get; }
    bool Optional { get; }
    LodestarId? EffectPresetId { get; }
    IEffectDefinition? Effect { get; }
}

public interface IEffectChainDefinition
{
    LodestarId Id { get; }
    IReadOnlyList<IInsertSlotDefinition> Slots { get; }
}
