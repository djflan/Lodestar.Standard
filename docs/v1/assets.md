# Assets and References

Reusable v1 assets are Instruments, Performances, Source Presets, Effect Presets, and Effect Chains. Resources are non-code dependencies such as SoundFonts, samples, and impulse responses. Every exported asset/resource/provider uses a stable logical ID; references contain IDs, not relative path coupling.

## Metadata

Every reusable asset MUST contain metadata with a non-empty display name and at least one author. Each author has a non-empty name and MAY provide one free-form contact string. Contact is display-only: consumers MUST NOT assume it is an email address or URI or activate it without user intent.

Description and tags are optional. Tags MUST be non-empty and unique under case-insensitive comparison, while tools SHOULD preserve authored casing. V1 defines no category field or controlled tag taxonomy. Metadata MUST NOT affect rendering, identity, or compatibility.

## References and dependencies

An asset reference resolves first within the package manifest's exported assets, then through declared package dependencies/installed libraries. Resolution MUST be deterministic and MUST NOT search arbitrary filesystem locations. Duplicate IDs in one resolution scope are invalid. A package MAY embed a referenced asset/resource or depend on an external package that exports it.

Source and Effect Presets declare only direct semantic dependencies: one provider, one provider-owned payload version, and stable resource IDs. Source Presets may reference samples, SoundFonts, or wavetables; Effect Presets may reference impulse responses, captured models, or similar data. Package manifests locate external dependencies. Transitive dependencies remain on the referenced object and are not copied into every consumer.

Definitions are persistent authoring state. Runtime source/effect instances, voices, meters, smoothing/history buffers, and transient automation are instance state and are not assets. Changing instance state MUST NOT silently mutate shared presets or definitions. Tools SHOULD create a new asset/revision when committing reusable changes.

Required references must resolve before activation. Optional fallback such as `silence`, `bypass`, or `omit` belongs where an asset is used, such as a Layer or Insert Slot—not inside the reusable preset. No implicit substitution is allowed. Content hashes MAY verify resources but are Draft-optional pending canonicalization.
