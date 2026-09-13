# Sources

A Layer owns exactly one Source Definition. The definition contains its stable ID, exactly one Source Provider ID, a provider payload version, an optional Source Preset reference, resource references, and provider-specific payload. Core Lodestar fields describe identity and dependencies; they do not normalize provider parameters.

A host resolves the exact provider by stable provider ID, verifies support for the declared payload version, resolves resources/presets, and asks it to prepare a runtime source. Provider payload MUST remain opaque to hosts that do not understand it.

Each Source Preset belongs to exactly one Source Provider because that provider owns its payload. An Instrument can use many providers by assigning different Source Definitions or Presets to different Layers—for example, one Helios Layer and one FluidSynth Layer. A provider may implement one shared engine serving many Layers or local engines per Layer; observable Layer ownership and isolation MUST remain equivalent. Voices are runtime state and MUST NOT be serialized.

An instance MAY hold overrides or runtime state without mutating its preset. Resource references use logical IDs, never assumed relative filesystem paths. Helios and FluidSynth are informative initial providers; neither identity is mandatory. Future SFZ or other providers require no core model change.
