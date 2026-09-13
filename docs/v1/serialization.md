# Serialization

V1 assets and manifests use UTF-8 JSON and JSON Schema 2020-12. Each document MUST contain `standardVersion: "1-draft"`, `kind`, stable `id`, and shared metadata where required by its asset schema. Property names are case-sensitive. IDs and references never gain meaning from file location.

Core objects allow an `extensions` object. Provider-specific Source/Effect payload belongs in `payload` and is interpreted only by the identified provider. Unknown extensions and payloads SHOULD be preserved byte-semantically during round trips.

Unknown core fields SHOULD be preserved by editing tools and ignored by runtimes unless invalid. Unknown enum values, payload versions, kinds, or Standard major versions MUST NOT be guessed. Missing optional fields take only documented defaults.

Arrays with processing meaning are ordered. Object property order is insignificant. Numeric values MUST be finite. Stable IDs MUST not be rewritten because a package entry moves. Tags are compared case-insensitively for uniqueness while authored casing is preserved.

```json
{
  "standardVersion": "1-draft",
  "kind": "sourcePreset",
  "id": "source-preset:bright",
  "metadata": {
    "name": "Bright Lead",
    "description": "A bright analog-style lead.",
    "authors": [{ "name": "Jane Smith", "contact": "@janesounds" }],
    "tags": ["lead", "bright", "analog"]
  },
  "providerId": "org.example.source.synth",
  "payloadVersion": "1",
  "resourceIds": [],
  "payload": { "oscillator": "saw" }
}
```

V1 does not define canonical JSON. Resource hashes follow [`.star` package](packages.md) byte rules and never depend on JSON property order.
