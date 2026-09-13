using System.Collections.Generic;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Effects;

namespace Lodestar.Standard.V1.Routing;

public enum MixerScope { Instrument, Performance }
public enum ChannelKind { Layer, Instrument, Part, BusReturn, Master }
public enum RouteDestinationKind { MixerOutput, Bus, Master }
public enum SendTap { PreFader, PostFader }

public interface IRouteDestination
{
    RouteDestinationKind Kind { get; }
    LodestarId? BusId { get; }
}

public interface ISendDefinition
{
    LodestarId BusId { get; }
    double Amount { get; }
    SendTap? Tap { get; }
}

public interface IChannelDefinition
{
    LodestarId Id { get; }
    ChannelKind Kind { get; }
    bool Enabled { get; }
    bool Mute { get; }
    bool Solo { get; }
    double Gain { get; }
    double Pan { get; }
    IReadOnlyList<IInsertSlotDefinition> Inserts { get; }
    IReadOnlyList<ISendDefinition> Sends { get; }
    IRouteDestination Output { get; }
}

public interface IBusDefinition
{
    LodestarId Id { get; }
    BusKind Kind { get; }
    IChannelDefinition Channel { get; }
}

public interface IMixerDefinition
{
    MixerScope Scope { get; }
    IReadOnlyList<IBusDefinition> Buses { get; }
}
