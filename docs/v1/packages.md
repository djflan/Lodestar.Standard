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

The manifest MUST contain `standardVersion: "1-draft"`, package `id`, metadata, independently versioned `packageVersion`, asset/resource entries, dependencies, and provider requirements as applicable. Provider summaries MUST agree with contained assets; tooling SHOULD generate or validate them. Entry paths locate container entries only; serialized references use logical IDs. A resource may be embedded or external, never both.

Dependencies identify an exact package ID plus `packageVersion`; range grammar is not part of v1. A dependency record is only a declaration. Whether a particular resource, Source, or Effect use is required or has a fallback is defined at that use site; hosts diagnose unresolved references during preparation. Provider requirements remain declarations of provider availability, while optional behavior is declared at the relevant use.

Readers MUST reject absolute paths, drive-prefixed paths, NUL, `..` traversal, links escaping extraction roots, duplicate security-equivalent names, unreasonable expansion, and entries that overwrite one another. Package content MUST be treated as untrusted data.

Content hashes are optional in v1 and use `sha256:` followed by exactly 64 lowercase hexadecimal characters. The digest covers the exact uncompressed resource entry bytes. Canonical JSON, whole-package hashes, and signing remain outside v1.
