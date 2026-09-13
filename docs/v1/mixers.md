# Mixers

A Mixer combines multiple signals and owns a routing scope; it is not merely another Channel.

The Instrument Mixer belongs to one Instrument. It combines that Instrument's Layer Channels and Instrument-scope bus outputs into one Instrument output, which is processed by the Instrument Channel. It MUST NOT accept Part Channels.

The Performance Mixer belongs to one Performance. It combines Part Channels and Performance-scope bus outputs and feeds the Master Channel. It MUST NOT directly own Layer Channels.

Mixers MUST sum aligned sample frames without reordering time. They MUST apply the validated graph in dependency order and preserve insert/send/output semantics. V1 requires stereo scope outputs but does not prescribe accumulator precision, summing headroom, pan law, latency compensation, or a maximum channel count. A host SHOULD expose declared implementation limits before loading content and MUST fail cleanly rather than truncate silently.

Mixer-owned bus IDs and channel IDs MUST be unique within the scope. Solo/mute evaluation, missing nodes, and cycles are validation responsibilities. See [routing](routing.md) and [compatibility](compatibility.md).
