using Lodestar.Standard.V1.Assets;

namespace Lodestar.Standard.V1.Events;

public enum EventKind { NoteOn, NoteOff, PerNoteExpression, PartControl, ParameterAutomation }
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
