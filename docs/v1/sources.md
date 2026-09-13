# Sources

A Layer owns exactly one Source Definition. The definition contains its stable ID, Source Provider ID, optional required capabilities, an optional Source Preset reference, resource references, and provider-specific payload. Core Lodestar fields describe identity and dependencies; they do not attempt to normalize every synthesis or sampling parameter.

A host resolves the provider by stable provider ID, negotiates required capabilities, resolves resources/presets, and asks the provider to prepare a runtime source. Provider payload MUST live under that provider's extension namespace and MUST remain opaque to hosts that do not understand it.

Providers may implement one shared engine serving many Layers or local engines per Layer. This is intentionally implementation-neutral: observable Layer ownership, event routing, isolation of instance state, and audio boundaries MUST remain equivalent. Voices are provider runtime polyphony and MUST NOT be serialized.

Source Presets are reusable definitions. An instance MAY hold overrides or runtime state without mutating the preset. Resource references use logical IDs, never assumed relative filesystem paths. Helios and FluidSynth are informative initial providers; neither identity is mandatory. Future SFZ or other providers require no core model change. See [providers](providers.md) and [assets](assets.md).
