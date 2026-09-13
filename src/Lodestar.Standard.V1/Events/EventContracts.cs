using Lodestar.Standard.V1.Assets;

namespace Lodestar.Standard.V1.Events;

public enum EventKind { NoteOn, NoteOff, PerNoteExpression, PartControl, ParameterAutomation }
public enum AutomationInterpolation { Step, Linear }
public interface IParameterDescriptor
{
    LodestarId Id { get; }
    double Minimum { get; }
    double Maximum { get; }
    double Default { get; }
    string Unit { get; }
    bool IsNormalized { get; }
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
