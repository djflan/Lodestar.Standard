# `.star` Packages

A `.star` file is a ZIP-compatible v1 content container with `manifest.json` at its root. It may contain Instruments, Performances, Source Presets, Effect Presets, Effect Chains, and Resources. Providers are executable code and SHOULD NOT be bundled; manifests summarize provider requirements.

## Layout

```text
Factory.star
├── manifest.json
├── instruments/*.json
├── performances/*.json
├── presets/sources/*.json
├── presets/effects/*.json
├── chains/*.json
└── resources/{soundfonts,samples,...}/*
```

The manifest MUST contain `standardVersion: "1-draft"`, package `id`, metadata, independently versioned `releaseVersion`, asset/resource entries, dependencies, and provider requirements as applicable. Provider summaries MUST agree with contained assets; tooling SHOULD generate or validate them. Entry paths locate container entries only; serialized references use logical IDs. A resource may be embedded or external, never both.

Dependencies identify package ID plus a compatible release expression; Draft v1 treats the expression as opaque pending final grammar. Required dependencies/providers fail preparation. Optional requirements use declared fallback at the point of use.

Readers MUST reject absolute paths, drive-prefixed paths, NUL, `..` traversal, links escaping extraction roots, duplicate security-equivalent names, unreasonable expansion, and entries that overwrite one another. Package content MUST be treated as untrusted data.

Optional content hashes use algorithm-qualified values such as `sha256:<hex>` and cover uncompressed entry bytes. Signing and canonical package hashing remain outside Draft v1.
