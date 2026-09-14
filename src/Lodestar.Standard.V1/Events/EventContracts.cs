using Lodestar.Standard.V1.Assets;

namespace Lodestar.Standard.V1.Events;

public enum EventKind { NoteOn, NoteOff, PerNoteExpression, PartControl, ParameterAutomation }
public enum AutomationInterpolation { Step, Linear }
public enum ParameterValueKind { Number, Boolean, Enum }

/// <summary>A runtime-only address for a provider or routing parameter.</summary>
public interface IRuntimeControlAddress
{
    string ResolutionScope { get; }
    string NodeKind { get; }
    LodestarId NodeId { get; }
    LodestarId ParameterId { get; }
}

public interface IParameterDescriptor
{
    LodestarId Id { get; }
    string DisplayName { get; }
    ParameterValueKind ValueKind { get; }
    double Minimum { get; }
    double Maximum { get; }
    double Default { get; }
    string Unit { get; }
    bool IsNormalized { get; }
    bool Automatable { get; }
    bool ReadOnly { get; }
    System.Collections.Generic.IReadOnlyList<AutomationInterpolation> SupportedInterpolation { get; }
    System.Collections.Generic.IReadOnlyList<string> ProviderDefinedInterpolationIds { get; }
}
public interface ILodestarEvent
{
    EventKind Kind { get; }
    LodestarId PartId { get; }
    long SampleTime { get; }
    int SampleOffset { get; }
}
public interface INoteEvent : ILodestarEvent
{
    long NoteId { get; }
    double Pitch { get; }
    double Velocity { get; }
}
