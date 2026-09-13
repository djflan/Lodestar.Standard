using System.Collections.Generic;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Providers;

namespace Lodestar.Standard.V1.Packages;

public enum PackageAssetKind { Instrument, Performance, SourcePreset, EffectPreset, EffectChain }
public enum OptionalFallback { Silence, Bypass, Omit }
public interface IPackageDependency
{
    LodestarId PackageId { get; }
    string VersionExpression { get; }
    bool Required { get; }
}
public interface IProviderRequirement
{
    ProviderId ProviderId { get; }
    ProviderRole Role { get; }
    bool Required { get; }
    IReadOnlyList<string> Capabilities { get; }
    OptionalFallback? Fallback { get; }
}
public interface IPackageManifest
{
    string StandardVersion { get; }
    LodestarId Id { get; }
    string ReleaseVersion { get; }
    IReadOnlyList<IPackageDependency> Dependencies { get; }
    IReadOnlyList<IProviderRequirement> Providers { get; }
}
