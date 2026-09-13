# Routing

A route graph exists independently in each Instrument Mixer and Performance Mixer scope. Nodes are channels, buses/returns, the scope output, and—at Performance scope—the Master Channel. Edges are one primary output route or zero or more send routes. Cross-scope bus references are invalid.

## Signal path

A Layer Source feeds its Layer Channel. Each Layer Channel routes either directly to the Instrument Mixer output or serially to one Instrument submix bus, and MAY send in parallel to Instrument send buses. Bus outputs route to another later bus or the scope output. The Instrument output passes through its Instrument Channel and then its owning Part Channel. The same pattern applies to Part Channels and Performance buses before the Master Channel.

A primary route MUST have exactly one destination. A send duplicates a tap without replacing the primary route and has a linear normalized amount from 0 (silence) through 1 (unity). Values above unity are not portable v1 data. Whether a send tap is pre/post fader is intentionally unresolved; serialized v1 Draft data MAY name a supported placement, and a host MUST report unsupported placement rather than silently substitute it.

A submix bus is serial/group routing. A send bus is parallel routing and its processed Return Channel re-enters the owning mixer graph. A bus MAY send to a send bus and MAY route to a later submix bus.

## Acyclic graph

Authors and hosts MUST reject self-routes and cycles by default. Validation evaluates primary and send edges together. Feedback is not a portable v1 feature. A destination MUST exist in the same scope and accept the route kind.

## Three-layer grouping example

```text
Layer A ─┐
Layer B ─┴→ Submix "Body" → Instrument output
Layer C ───────────────────→ Instrument output
                         all three summed by Instrument Mixer
```

The Body bus may run insert compression before gain/pan/output. Layer C remains direct. This is serial grouping, not a send. See [buses](buses.md), [channels](channels.md), and `examples/v1/instrument-submix/instrument.json`.
