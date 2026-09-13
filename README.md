# Lodestar Standard

Lodestar is a music workstation and extensible audio platform. **Lodestar Standard** defines its independently implementable content model, routing vocabulary, provider boundaries, event model, and ZIP-compatible `.star` package format.

> **Status: Draft — Lodestar Standard v1**

The repository is intentionally specification-first:

- [`docs/v1`](docs/v1/README.md) contains the human-readable v1 specification.
- [`schemas/v1`](schemas/v1) contains draft machine-readable schemas.
- [`src/Lodestar.Standard.V1`](src/Lodestar.Standard.V1) contains minimal .NET contracts for settled concepts.
- [`tests`](tests) contains contract tests.
- [`examples/v1`](examples/v1) contains worked, provider-neutral examples.

Helios is Lodestar's canonical DaisySP-based synthesis source provider. Aurora is the canonical in-house effect/DSP provider. Those products demonstrate the provider model but do not constrain conforming implementations. FluidSynth is the initial SF2/sample provider. A commercial or closed-source host may implement this open standard.

## Settled model

The core content hierarchy is:

```text
Performance -> Part -> Instrument -> Layer -> Source
```

Channels process one signal, Mixers combine signals, and Buses provide alternate or shared routing destinations. The routing model supports submix buses and send buses. Sources and Effects are supplied through provider abstractions. `.star` is the Lodestar content package format.

MIDI, GM, GM2, GS, and XG are adapter or mapping concerns—not the native Lodestar object model. Standard v1 is versioned independently from package releases and language bindings.

## Start here

Read the [v1 specification index](docs/v1/README.md), then the [object model](docs/v1/object-model.md), [routing model](docs/v1/routing.md), and [package format](docs/v1/packages.md). Draft decisions and unresolved questions are tracked in [decisions and open questions](docs/v1/decisions-and-open-questions.md).

## Build

```sh
dotnet build src/Lodestar.Standard.slnx
dotnet test src/Lodestar.Standard.slnx
```

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md). Draft changes should preserve the distinction between settled requirements, proposals, and placeholders.

## Licensing

Lodestar Standard uses a dual-license structure: code, schemas, API/contracts, tests, and executable/reference examples are licensed under [Apache-2.0](LICENSE-CODE), while specification and documentation content under `docs/` is licensed under [CC BY 4.0](LICENSE-DOCS) unless a file states otherwise. See [LICENSE](LICENSE) for the full scope and [NOTICE](NOTICE) for attribution.
