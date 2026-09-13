namespace Lodestar.Standard.V1.ObjectModel;

/// <summary>A playable role within a performance.</summary>
public interface IPart
{
    /// <summary>Gets the instrument assigned to this part.</summary>
    IInstrument Instrument { get; }
}
