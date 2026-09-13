# Lodestar Standard v1 Draft

> **Status: Draft**

This directory is the human-readable Lodestar Standard v1 Draft. It defines portable meaning, not a workstation implementation or DSP algorithm.

The key words **MUST**, **MUST NOT**, **REQUIRED**, **SHOULD**, **SHOULD NOT**, and **MAY** express conformance requirements. Until v1 is finalized, requirements can change through the proposal process. Prose using those words, schema constraints, and declared invariants are normative. Examples, diagrams, rationale, implementation notes, product references, and proposal documents are informative. If schema and normative prose disagree, that is a draft defect; implementations SHOULD report it rather than silently choosing a new meaning.

Standard version `1` denotes an interoperability generation and is independent of package `releaseVersion` values and library/package SemVer. A future Standard version is expected only for breaking interoperability changes.

## Scope

V1 specifies the persistent musical hierarchy, stereo interchange/render boundary, channels/mixers/buses, sources/effects/providers, native events, reusable assets, JSON serialization, `.star` containers, compatibility, and realtime obligations. It does not standardize UI, plugin APIs, a provider's internal voice engine, fixed polyphony or DSP limits, MIDI as a native model, or DAW product packaging.

## Contents

1. [Terminology](terminology.md)
2. [Canonical architecture map and inventory](architecture-map.md)
3. [Object model](object-model.md)
4. [Audio model](audio-model.md)
5. [Routing](routing.md)
6. [Channels](channels.md)
7. [Mixers](mixers.md)
8. [Buses](buses.md)
9. [Sources](sources.md)
10. [Effects](effects.md)
11. [Providers](providers.md)
12. [Events](events.md)
13. [Assets](assets.md)
14. [`.star` packages](packages.md)
15. [Serialization](serialization.md)
16. [Compatibility](compatibility.md)
17. [Real-time behavior](realtime.md)
18. [Host and adapter boundaries](host-boundaries.md)
19. [Decisions and open questions](decisions-and-open-questions.md)
20. [Repository reconciliation](reconciliation.md)

See also the [JSON Schemas](../../schemas/v1/), [worked examples](../../examples/v1/), and [proposal process](../proposals/README.md).
