namespace Lodestar.Standard.V1.Routing;

/// <summary>An alternate or shared routing destination.</summary>
public interface IBus
{
    /// <summary>Gets the routing role of this bus.</summary>
    BusKind Kind { get; }
}
