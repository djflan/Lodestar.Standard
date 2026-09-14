# Object Model

## Ownership and cardinality

```text
Performance 1 ─owns─ 1..* Part
Part        1 ─refs─  0..1 Instrument
Instrument 1 ─owns─ 1..* Layer
Layer      1 ─owns─ 1 Source Definition
```

A Performance MUST own at least one Part. A Part MAY be unassigned; an unassigned Part remains an event target but produces silence. An Instrument MUST contain at least one ordered Layer. Each Layer MUST contain exactly one Source Definition. Voice is runtime state below a Source Provider and MUST NOT appear as a persistent child.

Ownership means the child has one structural parent in the serialized asset. References resolve by stable logical ID and allow reuse across packages/libraries. Implementations MAY materialize referenced assets as copies internally, but MUST preserve their observable Lodestar identity and semantics.

## Processing composition

```text
events → Part → Instrument → Layers → Source Providers
                         Layer Channels ─┐
                                        ├→ Instrument Mixer → Instrument Channel
                                        └→ Instrument buses
Part Channel outputs ─────────────────────→ Performance Mixer/buses → Master Channel
```

The Instrument Mixer owns Layer Channels and Instrument-scope buses. The Performance Mixer owns Part Channels, Performance-scope buses, and the Master Channel. An Instrument Channel represents the mixed instrument output before it enters its containing Part Channel; implementations MAY fuse adjacent processing stages if results remain equivalent.

A Performance owns one logical main stereo output configuration. A host adapter maps that output to a device, file, plugin bus, or other endpoint. Sequences, tempo maps, transport, automation lanes, and other DAW/editor state are host-owned and are not part of a Performance or `.star` package.

## Lifecycle and invariants

Hosts MUST resolve all required asset, resource, provider, and capability references during preparation, before realtime rendering. Runtime instances and provider voices are ephemeral; serialized definitions/presets are persistent. Editing an instance does not mutate a referenced reusable asset unless the authoring operation explicitly creates a new revision.

IDs MUST be unique within their declared scope. Routes MUST remain within their mixer scope and MUST form an acyclic graph by default. A source provider cannot change Layer ownership; an effect provider cannot add hidden persistent routes. Hosts MUST preserve unknown extensions as described in [serialization](serialization.md) when round-tripping.

## Example

A Performance `performance:stage` owns Parts `part:lead` and `part:pad`. Both may reference `instrument:hybrid-pad`. That Instrument owns two Layers, each with a different Source Definition/provider. The two Part runtime instances can carry different part-channel state without changing the shared Instrument asset. See [assets](assets.md) and the [examples](../../examples/v1/).
