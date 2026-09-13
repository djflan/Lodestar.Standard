# Terminology

These definitions are normative throughout v1.

- **Performance** — a top-level playable asset owning one or more Parts and a Performance Mixer.
- **Part** — an event target and channel within a Performance. It owns zero or one Instrument assignment; absence is valid and silent.
- **Instrument** — a reusable asset owning one or more Layers and an Instrument Mixer.
- **Layer** — an Instrument constituent owning exactly one Source Definition and one Layer Channel.
- **Source / Source Definition** — the persistent provider-neutral identity plus provider payload needed to create a signal origin. It is not a runtime voice.
- **Voice** — provider-managed runtime polyphony created while rendering notes. A Voice is never a persistent hierarchy node.
- **Channel** — a path that processes one signal. V1 identifies Layer, Instrument, Part, Bus/Return, and Master channels.
- **Mixer** — an owner/summing context that combines multiple channel or bus outputs. Instrument Mixer combines Layer Channels; Performance Mixer combines Part Channels.
- **Bus** — a shared or alternate scoped routing destination with input summing and a processing channel.
- **Send** — a parallel tap from a channel or bus to a send bus, with an amount and an unresolved pre/post-fader placement choice.
- **Return / Return Channel** — the processed output path of a send bus back into its owning mixer graph.
- **Submix bus** — a serial/group destination replacing a signal's direct output route.
- **Effect / Effect Definition** — persistent provider identity and payload describing a provider-created signal processor.
- **Insert / Insert Slot** — an ordered effect position in a channel; it can be bypassed and can reference an Effect Definition or preset.
- **Effect Chain** — a reusable ordered collection of Insert Slots.
- **Provider** — independently registered code that creates sources or effects and advertises identity/capabilities.
- **Asset** — a stable-ID reusable Lodestar definition such as an Instrument, Performance, or preset.
- **Resource** — non-code data consumed by an asset, such as a SoundFont or sample.
- **Preset** — reusable source or effect configuration distinct from mutable runtime instance state.
- **Package** — a `.star` ZIP-compatible content container with one manifest.
- **Library** — installed package/content collection addressable by stable logical IDs.
- **ID / reference** — a stable logical identifier and a typed pointer to it. Neither is a relative filesystem path.

See [object model](object-model.md), [routing](routing.md), [assets](assets.md), and [packages](packages.md) for rules attached to these terms.
