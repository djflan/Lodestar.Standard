# Decisions and Open Questions

## Settled for v1

The product names, hierarchy/cardinalities, channel/mixer/bus distinctions, two mixer scopes, send and submix buses, insert locations, provider abstractions, native Part-targeted events, `.star` ZIP container, stable logical IDs, separate Standard/package versions, licensing split, and independent implementability are requirements.

Helios, Aurora, FluidSynth, workstation/plugin plans, and GM-family mappings are informative ecosystem context rather than mandatory dependencies.

The September 2026 reconciliation also settles:

1. `preFader` and `postFader` sends, defaulting to `postFader`.
2. Equal-power stereo panning and mono duplication before panning.
3. Optional host-owned Insert Slot `wetDry`, defaulting to fully wet.
4. Lowercase reverse-DNS IDs with optional colon-separated local components.
5. Exact opaque provider `payloadVersion` matching in v1.
6. Optional SHA-256 hashes over exact uncompressed resource bytes.
7. Required step and linear automation plus parameter descriptors.
8. Deterministic offline rendering as an optional reported capability.
9. One required main stereo output and optional named Part/bus auxiliary stereo outputs.
10. An optional Performance Sequence and Tempo Map with explicitly selected Performance or host timing authority.

## Open Draft-v1 questions

No unresolved architecture decision is currently recorded. New unresolved semantics MUST enter through the [proposal process](../proposals/README.md) rather than being inferred by implementations.
