# Terminology

These definitions are normative throughout v1.

- **Performance** — a top-level playable asset owning one or more Parts and a Performance Mixer.
- **Part** — an event target and channel within a Performance. It owns zero or one Instrument assignment; absence is valid and silent.
- **Instrument** — a reusable asset owning one or more Layers and an Instrument Mixer. It may compose Sources from many providers.
- **Layer** — an Instrument constituent owning exactly one Source Definition and one Layer Channel.
- **Source / Source Definition** — the persistent identity and provider payload needed to create a signal origin. Each identifies exactly one Source Provider.
- **Voice** — provider-managed runtime polyphony created while rendering notes. A Voice is never a persistent hierarchy node.
- **Channel** — a path that processes one signal. V1 identifies Layer, Instrument, Part, Bus/Return, and Master channels.
- **Mixer** — an owner/summing context that combines multiple channel or bus outputs. Instrument Mixer combines Layer Channels; Performance Mixer combines Part Channels.
- **Bus** — a shared or alternate scoped routing destination with input summing and a processing channel.
- **Send** — a parallel tap from a channel or bus to a send bus, with an amount and `preFader` or `postFader` placement; omission defaults to `postFader`.
- **Return / Return Channel** — the processed output path of a send bus back into its owning mixer graph.
- **Submix bus** — a serial/group destination replacing a signal's direct output route.
- **Effect / Effect Definition** — persistent identity and provider payload describing a signal processor. Each identifies exactly one Effect Provider.
- **Insert / Insert Slot** — an ordered effect position in a channel; it can be bypassed and can reference an Effect Definition or preset.
- **Effect Chain** — a reusable ordered collection of Insert Slots that may use many Effect Providers.
- **Provider** — independently registered code that creates sources or effects.
- **Asset** — a stable-ID reusable Lodestar definition such as an Instrument, Performance, or preset.
- **Resource** — non-code data consumed by an asset, such as a SoundFont, sample, or impulse response.
- **Source Preset** — reusable configuration owned by exactly one Source Provider. Multiple Source Providers are composed by an Instrument's Layers.
- **Effect Preset** — reusable configuration owned by exactly one Effect Provider. Multiple Effect Providers are composed by an Effect Chain or channel.
- **Metadata** — descriptive, non-rendering asset information: name, description, authors, optional author contact, and tags.
- **Package** — a `.star` ZIP-compatible content container with one manifest.
- **Library** — installed package/content collection addressable by stable logical IDs.
- **ID / reference** — a stable logical identifier and a typed pointer to it. Neither is a relative filesystem path.

See [object model](object-model.md), [routing](routing.md), [assets](assets.md), and [packages](packages.md) for rules attached to these terms.
