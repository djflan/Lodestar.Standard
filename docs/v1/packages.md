# `.star` Packages

A `.star` file is a ZIP-compatible v1 content container with `manifest.json` at its root. It may contain Instruments, Performances, Source Presets, Effect Presets, Effect Chains, and Resources. Providers are executable code and SHOULD NOT be bundled; manifests declare provider requirements.

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

The manifest MUST contain `standardVersion: "1-draft"`, package `id`, independently versioned `releaseVersion`, asset/resource entries, dependencies, and provider requirements as applicable. Entry paths are container locations only; serialized references use logical IDs. A resource may be embedded with a path or external with a package/resource reference, never both.

Dependencies identify package ID plus a compatible release expression; Draft v1 treats the expression as an opaque string pending final grammar. Required dependencies/providers fail preparation. Optional requirements use declared fallback.

Readers MUST reject absolute paths, drive-prefixed paths, NUL, `..` traversal, links escaping extraction roots, duplicate security-equivalent names, unreasonable expansion, and entries that overwrite one another. Readers SHOULD stream safely and impose declared implementation limits. Package content MUST be treated as untrusted data; provider payload is data, not executable instructions.

Optional content hashes use algorithm-qualified values such as `sha256:<hex>` and cover the uncompressed entry bytes. Signing and canonical package hashing remain outside Draft v1. See the [schemas](../../schemas/v1/) and [package example](../../examples/v1/package/).
