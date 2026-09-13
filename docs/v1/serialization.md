# Serialization

V1 assets and manifests use UTF-8 JSON and JSON Schema 2020-12. Each document MUST contain `standardVersion: "1-draft"`, `kind`, and stable `id`. Property names are case-sensitive. IDs and references are JSON strings; references never gain meaning from their file location.

Core objects allow an `extensions` object. Extension keys MUST be stable namespace-like provider/organization IDs; values are arbitrary JSON. Provider-specific Source/Effect payload belongs in `payload` and is interpreted only by the identified provider. Unknown extensions and payloads SHOULD be preserved byte-semantically when a tool round-trips a document it otherwise understands.

Unknown core fields SHOULD be preserved by editing tools and ignored by runtimes unless a schema marks them invalid. Unknown enum values, required capabilities, kinds, or Standard major versions MUST NOT be guessed; loaders report unsupported content. Missing optional fields take only schema/documented defaults.

Arrays with processing meaning—Layers, Parts, inserts—are ordered. Object property order is insignificant. Numeric values MUST be finite JSON numbers. Stable IDs MUST not be rewritten merely because a package entry moves.

Example:

```json
{
  "standardVersion": "1-draft",
  "kind": "sourcePreset",
  "id": "source-preset:bright",
  "providerId": "org.example.source.synth",
  "payloadVersion": "1",
  "payload": { "oscillator": "saw" },
  "extensions": { "org.example.authoring": { "color": "gold" } }
}
```

Canonical JSON and hash rules remain open. See [compatibility](compatibility.md).
