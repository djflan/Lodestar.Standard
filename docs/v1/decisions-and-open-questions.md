# Decisions and Open Questions

## Settled for v1

The product names, hierarchy/cardinalities, channel/mixer/bus distinctions, two mixer scopes, send and submix buses, insert locations, provider abstractions, native Part-targeted events, `.star` ZIP container, stable logical IDs, separate Standard/package versions, licensing split, and independent implementability are requirements.

Helios, Aurora, FluidSynth, workstation/plugin plans, and GM-family mappings are informative ecosystem context rather than mandatory dependencies.

## Open Draft-v1 questions

1. Whether sends are pre-insert, post-insert/pre-fader, post-fader, selectable, or a smaller required subset.
2. The normative pan law and mono-to-stereo conversion rule; v1 currently requires hosts to declare them.
3. Whether effect wet/dry is always a slot property or only a provider capability.
4. The canonical URI/lexical grammar and registry policy for provider and asset IDs.
5. The exact compatibility expression for provider payload revisions beyond provider-owned version strings.
6. Whether content hashes become required and, if so, the canonical byte representation.
7. Required automation interpolation curves and parameter-unit metadata.
8. Whether deterministic offline rendering is a conformance level or only a best-effort capability.

These questions do not reopen the settled architecture. Proposals follow the [proposal process](../proposals/README.md).
