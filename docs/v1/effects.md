# Effects

An Effect Definition identifies an Effect Provider, required capabilities, optional preset, and provider-specific payload. An Insert Slot owns or references one Effect Definition, has stable slot identity, enabled/bypass state, and participates in an ordered Effect Chain.

Insert effects are permitted on Layer, Instrument, Part, Bus/Return, and Master channels. Slots process strictly in chain order. Bypass MUST pass the input without invoking effect-dependent coloration; hosts SHOULD preserve state while bypassed. Failure behavior follows [compatibility](compatibility.md).

Wet/dry MAY be exposed by a provider or slot in Draft v1, but its mandatory location and law remain open. Hosts MUST NOT infer that every effect supports wet/dry. Send topology is defined by routing, independently of effect wet/dry.

Effect Presets and Effect Chains are reusable assets. Runtime parameter changes and delay/history buffers are instance state unless explicitly saved. Effect providers MUST use stable IDs and namespaced payloads; Aurora is the canonical in-house provider but is not a normative dependency. Providers may be used on buses and Master without provider-specific Standard APIs.
