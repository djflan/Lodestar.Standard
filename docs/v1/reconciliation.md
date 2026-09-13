# Architecture Reconciliation

Baseline: [Canonical Architecture Map](architecture-map.md). **Complete** means consistent in prose and applicable projections; **Partial** means present but an applicable projection/detail is incomplete; **Missing** is absent; **Conflicting** contradicts the baseline; **Intentionally Deferred** is explicitly a Draft-v1 decision.

## Concept and relationship audit

| Concept or relationship | Status | Evidence / gap |
|---|---|---|
| Lodestar platform; Helios source; Aurora effects; FluidSynth initial SF2/sample source; sfizz/SFZ later | Complete | [sources](sources.md), [effects](effects.md), [host boundaries](host-boundaries.md); all are informative, not required. |
| Performance owns 1..* Parts | Complete | [object model](object-model.md), `performance.schema.json`, `IPerformanceDefinition`. |
| Part assigns 0..1 Instrument, has Part Channel, no Part Mixer | Complete | [object model](object-model.md), `performance.schema.json`, `IPartDefinition`. |
| Instrument owns 1..* Layers, Instrument Mixer/buses, distinct Instrument Channel | Complete | [object model](object-model.md), `instrument.schema.json`, `IInstrumentDefinition`. |
| Layer owns exactly one Source and Layer Channel | Complete | [sources](sources.md), `instrument.schema.json`, `ILayerDefinition`. |
| Voice is provider-managed runtime-only state | Complete | [sources](sources.md), [assets](assets.md); intentionally no persistent schema/type. |
| Source Definition → exact Source Provider with opaque payload | Complete | [sources](sources.md), source schemas, `ISourceDefinition`. |
| Effect Definition/Insert → exact Effect Provider, symmetric with Source | Complete | [effects](effects.md), effect schemas, `IEffectDefinition`; stable Effect ID added. |
| Channel processes one signal; common gain/pan/mute/solo/inserts/sends/output | Complete | [channels](channels.md), `routing.schema.json`, `IChannelDefinition`. |
| Instrument and Performance Mixers combine signals in distinct scopes | Complete | [mixers](mixers.md), `MixerScope`, schemas. |
| Instrument Mixer → Instrument Channel → Part Channel distinction | Complete | [routing](routing.md), object/schema/contracts. |
| Serial submix vs parallel send bus; selected Layer subset grouping | Complete | [routing](routing.md), [buses](buses.md), `instrument-submix` example. |
| Instrument buses accept only same-Instrument Layer/bus routes | Complete | [buses](buses.md); target/scope validation is semantic. |
| Performance buses accept only same-Performance Part/bus routes | Complete | [buses](buses.md); target/scope validation is semantic. |
| Return Channel is controllable send-processing output | Complete | [terminology](terminology.md), [buses](buses.md), `ChannelKind.BusReturn`. |
| Inserts on Layer/Instrument/Part/BusReturn/Master | Complete | [effects](effects.md), shared channel schema/contract. |
| Sends on Layer/Instrument/Part/bus within permitted scope | Complete | [routing](routing.md), shared channel schema/contract. |
| Same-scope bus chaining only in acyclic combined graph | Complete | [routing](routing.md), [compatibility](compatibility.md); requires semantic validation. |
| Final Performance mix → ordered Master FX → output | Complete | [routing](routing.md), Performance schema/example. |
| Performance owns logical output configuration | Complete | [object model](object-model.md), [host boundaries](host-boundaries.md), schema/contract/example; added here. |
| Performance may own sequence/tempo state | Complete | [events](events.md), `performance.schema.json`, and `ISequenceTempoStateDefinition` define the optional Sequence, Tempo Map, and timing authority. |
| Native Event → Part → Instrument → Layers → Sources → Providers | Complete | [events](events.md), `ILodestarEvent.PartId`, event diagram. |
| MIDI/GM/GM2/GS/XG are adapters, not native model | Complete | [events](events.md), [host boundaries](host-boundaries.md). |
| Shared FluidSynth/backend implementation does not own standard objects | Complete | [sources](sources.md), [host boundaries](host-boundaries.md). |
| Reusable assets/resources and stable logical IDs/references | Complete | [assets](assets.md), asset schemas/contracts. |
| `.star` ZIP; Standard version separate from release SemVer | Complete | [packages](packages.md), manifest schemas/contracts. |
| Embedded resources or declared external package/library dependencies | Complete | [packages](packages.md), manifest schema; package contracts completed here. |
| Provider code normally external; provider requirements declared | Complete | [packages](packages.md), [providers](providers.md). |
| Missing/unknown provider behavior and opaque round-trip preservation | Complete | [providers](providers.md), [compatibility](compatibility.md), example. |
| Capability negotiation and soft limits, no hard DSP/voice/slot limits | Complete | [providers](providers.md), [realtime](realtime.md), descriptor contract. |
| Host-agnostic core; Unity/standalone/VST3/CLAP adapters; VST3 first | Complete | [host boundaries](host-boundaries.md); product order is informative. |
| Plugin state projects Lodestar-native state | Complete | [host boundaries](host-boundaries.md); no plugin ABI standardized. |
| Standard v1 / `Lodestar.Standard.V1.*` separate from SemVer | Complete | [serialization](serialization.md), namespaces, manifest. |
| Apache-2.0 technical artifacts; CC BY 4.0 docs; commercial/closed hosts allowed | Complete | Licenses, [compatibility](compatibility.md), [host boundaries](host-boundaries.md). |
| Send tap placement | Complete | [channels](channels.md): pre/post fader supported, post-fader default. |
| Pan law and mono adaptation | Complete | [audio model](audio-model.md), [channels](channels.md): equal-power pan and mono duplication. |
| Insert wet/dry | Complete | [effects](effects.md), schemas, `IInsertSlotDefinition.WetDry`. |
| ID grammar and provider payload compatibility | Complete | [providers](providers.md): reverse-DNS/colon IDs and exact opaque payload versions. |
| Resource hashes | Complete | [packages](packages.md): optional SHA-256 over uncompressed bytes. |
| Automation descriptors/interpolation | Complete | [events](events.md), `IParameterDescriptor`: step and linear required. |
| Deterministic offline rendering | Complete | [realtime](realtime.md): optional capability with reproducibility obligations. |

No settled baseline item remains **Missing** or **Conflicting** after this reconciliation.

## Specification document audit

| Current document | Status | Coverage / action |
|---|---|---|
| `README.md` / `docs/README.md` / `docs/v1/README.md` | Complete | Scope and navigation; canonical map/audit links added. |
| `terminology.md` | Complete | Canonical vocabulary and role distinctions. |
| `architecture-map.md` | Complete | New exhaustive cross-domain map/inventory. |
| `object-model.md` | Complete | Ownership, cardinality, runtime split, output/timeline ownership. |
| `audio-model.md` | Complete | Stereo boundary, render configuration, numeric behavior. |
| `routing.md` / `channels.md` / `mixers.md` / `buses.md` | Complete | Scoped primary/send graphs, roles, inserts, cycle rules. |
| `sources.md` / `effects.md` / `providers.md` | Complete | Symmetric provider seams, presets, shared backends, capabilities/failure. |
| `events.md` | Complete | Part targeting and mapping-adapter boundary. |
| `assets.md` / `packages.md` / `serialization.md` | Complete | IDs/references, content/dependencies, ZIP/JSON/version rules. |
| `compatibility.md` / `realtime.md` | Complete | Conformance, preparation, failures, soft limits, independence. |
| `host-boundaries.md` | Complete | New host/plugin/protocol boundary. |
| `decisions-and-open-questions.md` | Complete | Only genuine Draft choices; output/timeline shape added. |

## Schema audit

| Current schema | Status | Coverage / gap |
|---|---|---|
| `metadata.schema.json` | Complete | Asset metadata. |
| [`routing.schema.json`](../../schemas/v1/routing.schema.json) | Partial | Structural routes/channels/buses/scopes; cycles, target existence, and role permissions require semantic validation. |
| `instrument.schema.json` | Complete | Layers/Sources/Layer Channels plus Mixer and distinct Instrument Channel. |
| `performance.schema.json` | Complete | Parts, Mixer, Master, main/auxiliary outputs, optional Sequence/Tempo Map and timing authority. |
| `source-preset.schema.json` / `effect-preset.schema.json` | Complete | Provider-owned stable presets/resources/payloads. |
| `effect-chain.schema.json` | Complete | Ordered slots, references/inline stable Effect, bypass/fallback. |
| [`manifest.schema.json`](../../schemas/v1/manifest.schema.json) | Partial | Assets/resources/dependencies/requirements/versions; dependency grammar, canonical hashes and cross-entry uniqueness remain semantic/open. |
| `star-package.schema.json` | Complete | Manifest entry point; ZIP safety is prose/tool behavior. |

## Contract and test/example audit

| Current artifact | Status | Coverage / gap |
|---|---|---|
| `Assets/AssetContracts.cs` | Complete | Hierarchy, distinct channel/mixer roles, outputs, Sequence, Tempo Map, and timing authority. |
| `Audio/RenderContracts.cs` | Complete | Prepared stereo render boundary. |
| `Effects/EffectContracts.cs` / `Sources/SourceDefinition.cs` | Complete | Stable identity and symmetric provider payload/resource model. |
| Runtime markers [`ISource`](../../src/Lodestar.Standard.V1/Sources/ISource.cs), [`IEffect`](../../src/Lodestar.Standard.V1/Effects/IEffect.cs), [`IChannel`](../../src/Lodestar.Standard.V1/Routing/IChannel.cs), [`IMixer`](../../src/Lodestar.Standard.V1/Routing/IMixer.cs), [`IBus`](../../src/Lodestar.Standard.V1/Routing/IBus.cs) | Partial | Minimal by design; executable ABI/lifecycle is not yet a language-neutral Standard contract. |
| [`Events/EventContracts.cs`](../../src/Lodestar.Standard.V1/Events/EventContracts.cs) | Partial | Part/time/note and parameter descriptors/interpolation are present; concrete expression/control payload families remain future additive work. |
| `Packages/PackageContracts.cs` / `StarPackage.cs` | Complete | Manifest/assets/resources/dependencies/requirements/version/extension. |
| [`ProviderContracts.cs`](../../src/Lodestar.Standard.V1/Providers/ProviderContracts.cs), [`ISourceProvider.cs`](../../src/Lodestar.Standard.V1/Providers/ISourceProvider.cs), [`IEffectProvider.cs`](../../src/Lodestar.Standard.V1/Providers/IEffectProvider.cs) | Partial | Identity/payload/capabilities complete; provider marker interfaces intentionally avoid inventing an ABI. |
| `Routing/RoutingContracts.cs` / `BusKind.cs` | Complete | Roles, routes, sends, common channel state, bus definitions. |
| Project/namespace | Complete | v1 namespace and package `0.1.0` remain distinct. |
| [`SettledContractsTests.cs`](../../tests/Lodestar.Standard.V1.Tests/SettledContractsTests.cs) | Partial | Key settled shapes covered; full schema and graph validators remain future work. |
| [All current examples](../../examples/v1/) | Partial | Cover core instruments, submix, Performance/master, presets, manifest and missing provider; full ZIP and cycle fixtures remain useful future conformance examples. |

## Reconciliation changes

- Added canonical and focused Mermaid maps plus the normative inventory.
- Added host/adaptor boundaries and informative product status.
- Added Performance output configuration across prose, schema, contract, and example.
- Recorded optional sequence/tempo ownership without inventing its shape.
- Added stable identity to Effect Definitions and completed package asset/resource contracts.
- Added regression tests and clarified licensing/independent implementation.
