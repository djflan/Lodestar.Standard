# Lodestar Standard v1 Draft

> **Status: Draft**

This directory is the human-readable Lodestar Standard v1 Draft. It defines portable meaning, not a workstation implementation or DSP algorithm.

The key words **MUST**, **MUST NOT**, **REQUIRED**, **SHOULD**, **SHOULD NOT**, and **MAY** express conformance requirements. Until v1 is finalized, requirements can change through the proposal process. Prose using those words, schema constraints, and declared invariants are normative. Examples, diagrams, rationale, implementation notes, product references, and proposal documents are informative. If schema and normative prose disagree, that is a draft defect; implementations SHOULD report it rather than silently choosing a new meaning.

Standard version `1` denotes an interoperability generation and is independent of package `releaseVersion` values and library/package SemVer. A future Standard version is expected only for breaking interoperability changes.

## Scope

V1 specifies the persistent musical hierarchy, stereo interchange/render boundary, channels/mixers/buses, sources/effects/providers, native events, reusable assets, JSON serialization, `.star` containers, compatibility, and realtime obligations. It does not standardize UI, plugin APIs, a provider's internal voice engine, fixed polyphony or DSP limits, MIDI as a native model, or DAW product packaging.

## Contents

1. [Terminology](terminology.md)
2. [Object model](object-model.md)
3. [Audio model](audio-model.md)
4. [Routing](routing.md)
5. [Channels](channels.md)
6. [Mixers](mixers.md)
7. [Buses](buses.md)
8. [Sources](sources.md)
9. [Effects](effects.md)
10. [Providers](providers.md)
11. [Events](events.md)
12. [Assets](assets.md)
13. [`.star` packages](packages.md)
14. [Serialization](serialization.md)
15. [Compatibility](compatibility.md)
16. [Real-time behavior](realtime.md)
17. [Decisions and open questions](decisions-and-open-questions.md)

See also the [JSON Schemas](../../schemas/v1/), [worked examples](../../examples/v1/), and [proposal process](../proposals/README.md).
