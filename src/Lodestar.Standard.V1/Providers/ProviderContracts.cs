using System.Collections.Generic;

namespace Lodestar.Standard.V1.Providers;

public readonly struct ProviderId
{
    public ProviderId(string value) => Value = value;
    public string Value { get; }
    public override string ToString() => Value;
}
public enum ProviderRole { Source, Effect }
public interface IProviderDescriptor
{
    ProviderId Id { get; }
    ProviderRole Role { get; }
    string ImplementationVersion { get; }
    IReadOnlyList<string> PayloadVersions { get; }
    IReadOnlyList<string> Capabilities { get; }
}
public static class StandardCapabilities
{
    public const string DeterministicOfflineRendering = "deterministicOfflineRendering";
}
public interface IProviderRegistry
{
    bool TryGet(ProviderId id, ProviderRole role, out IProviderDescriptor? descriptor);
}
