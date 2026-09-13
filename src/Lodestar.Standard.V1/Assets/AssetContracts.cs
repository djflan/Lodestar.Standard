using System.Collections.Generic;
using Lodestar.Standard.V1.Routing;
using Lodestar.Standard.V1.Sources;

namespace Lodestar.Standard.V1.Assets;

/// <summary>A stable logical identifier; it is not a filesystem path.</summary>
public readonly struct LodestarId
{
    public LodestarId(string value) => Value = value;
    public string Value { get; }
    public override string ToString() => Value;
}

/// <summary>One credited asset author with optional display-only contact information.</summary>
public interface IAssetAuthor
{
    string Name { get; }
    string? Contact { get; }
}

/// <summary>Descriptive metadata that does not affect rendering or compatibility.</summary>
public interface IAssetMetadata
{
    string Name { get; }
    string? Description { get; }
    IReadOnlyList<IAssetAuthor> Authors { get; }
    IReadOnlyList<string> Tags { get; }
}

/// <summary>A top-level playable definition.</summary>
public interface IPerformanceDefinition
{
    LodestarId Id { get; }
    IAssetMetadata Metadata { get; }
    IReadOnlyList<IPartDefinition> Parts { get; }
    IMixerDefinition Mixer { get; }
    IChannelDefinition MasterChannel { get; }
    IOutputConfigurationDefinition OutputConfiguration { get; }
    ISequenceTempoStateDefinition? SequenceTempoState { get; }
}

/// <summary>Performance-owned logical outputs mapped to endpoints by a host adapter.</summary>
public interface IOutputConfigurationDefinition
{
    LodestarId MasterOutputId { get; }
    IReadOnlyList<IAuxiliaryOutputDefinition> AuxiliaryOutputs { get; }
}

public enum AuxiliaryOutputSourceKind { Part, PerformanceBus }
public interface IAuxiliaryOutputDefinition
{
    LodestarId Id { get; }
    string Name { get; }
    AuxiliaryOutputSourceKind SourceKind { get; }
    LodestarId SourceId { get; }
}

public enum TimingAuthority { Performance, Host }
public interface ISequenceTempoStateDefinition
{
    TimingAuthority TimingAuthority { get; }
    ISequenceDefinition Sequence { get; }
    ITempoMapDefinition TempoMap { get; }
}

public interface ISequenceDefinition
{
    IReadOnlyList<ISequencedEventDefinition> Events { get; }
}

public interface ISequencedEventDefinition
{
    double Beat { get; }
    LodestarId PartId { get; }
    string Kind { get; }
    string PayloadJson { get; }
}

public interface ITempoMapDefinition
{
    IReadOnlyList<ITempoPointDefinition> Points { get; }
}

public interface ITempoPointDefinition
{
    double Beat { get; }
    double BeatsPerMinute { get; }
}

/// <summary>A Part event target with an optional Instrument reference.</summary>
public interface IPartDefinition
{
    LodestarId Id { get; }
    LodestarId? InstrumentId { get; }
    IChannelDefinition Channel { get; }
}

/// <summary>A reusable layered Instrument.</summary>
public interface IInstrumentDefinition
{
    LodestarId Id { get; }
    IAssetMetadata Metadata { get; }
    IReadOnlyList<ILayerDefinition> Layers { get; }
    IMixerDefinition Mixer { get; }
    IChannelDefinition InstrumentChannel { get; }
}

/// <summary>An Instrument-owned Layer with exactly one Source Definition.</summary>
public interface ILayerDefinition
{
    LodestarId Id { get; }
    ISourceDefinition Source { get; }
    IChannelDefinition Channel { get; }
}
