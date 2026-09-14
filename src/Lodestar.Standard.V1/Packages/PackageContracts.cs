using System.Collections.Generic;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Providers;

namespace Lodestar.Standard.V1.Packages;

public enum PackageAssetKind { Instrument, Performance, SourcePreset, EffectPreset, EffectChain }
public enum OptionalFallback { Silence, Bypass, Omit }
public interface IPackageAssetEntry
{
    LodestarId Id { get; }
    PackageAssetKind Kind { get; }
    string Path { get; }
}
public interface IExternalResourceReference
{
    LodestarId PackageId { get; }
    LodestarId ResourceId { get; }
}
public interface IPackageResourceEntry
{
    LodestarId Id { get; }
    string? MediaType { get; }
    string? Path { get; }
    IExternalResourceReference? External { get; }
    string? ContentHash { get; }
}
public interface IPackageDependency
{
    LodestarId PackageId { get; }
    string PackageVersion { get; }
}
public interface IProviderRequirement
{
    ProviderId ProviderId { get; }
    ProviderRole Role { get; }
    bool Required { get; }
    OptionalFallback? Fallback { get; }
}
public interface IPackageManifest
{
    string StandardVersion { get; }
    LodestarId Id { get; }
    IAssetMetadata Metadata { get; }
    string PackageVersion { get; }
    IReadOnlyList<IPackageAssetEntry> Assets { get; }
    IReadOnlyList<IPackageResourceEntry> Resources { get; }
    IReadOnlyList<IPackageDependency> Dependencies { get; }
    IReadOnlyList<IProviderRequirement> Providers { get; }
}
