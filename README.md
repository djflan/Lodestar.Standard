# Lodestar Standard

Lodestar Standard defines the portable object model, routing concepts, provider contracts, and `.star` package format used by the Lodestar ecosystem.

> **Status: Draft — Lodestar Standard v1**

The repository is intentionally specification-first:

- [`docs/v1`](docs/v1/README.md) contains the human-readable v1 specification.
- [`schemas/v1`](schemas/v1) contains draft machine-readable schemas.
- [`src/Lodestar.Standard.V1`](src/Lodestar.Standard.V1) contains minimal .NET contracts for settled concepts.
- [`tests`](tests) contains contract tests.
- [`examples/v1`](examples/v1) is reserved for conforming examples.

## Settled model

The core content hierarchy is:

```text
Performance -> Part -> Instrument -> Layer -> Source
```

Channels process one signal, Mixers combine signals, and Buses provide alternate or shared routing destinations. The routing model supports submix buses and send buses. Sources and Effects are supplied through provider abstractions. `.star` is the Lodestar content package format.

Anything not explicitly documented as a requirement remains open for design.

## Build

```sh
dotnet build src/Lodestar.Standard.slnx
dotnet test src/Lodestar.Standard.slnx
```

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md). Draft changes should preserve the distinction between settled requirements, proposals, and placeholders.

## Licensing

Lodestar Standard uses a dual-license structure: code, schemas, API/contracts, tests, and executable/reference examples are licensed under [Apache-2.0](LICENSE-CODE), while specification and documentation content under `docs/` is licensed under [CC BY 4.0](LICENSE-DOCS) unless a file states otherwise. See [LICENSE](LICENSE) for the full scope and [NOTICE](NOTICE) for attribution.
