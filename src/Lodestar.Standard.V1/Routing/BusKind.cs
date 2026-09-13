namespace Lodestar.Standard.V1.Routing;

/// <summary>The settled routing role of a bus.</summary>
public enum BusKind
{
    /// <summary>Combines routed signals before forwarding its output.</summary>
    Submix,

    /// <summary>Receives a send from another signal path.</summary>
    Send
}
