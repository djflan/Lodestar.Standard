# Assets and References

Reusable v1 assets are Instruments, Performances, Source Presets, Effect Presets, and Effect Chains. Resources are non-code dependencies such as SoundFonts and samples. Every exported asset/resource/provider uses a stable logical ID; references contain IDs, not relative path coupling.

An asset reference resolves first within the package manifest's exported assets, then through declared package dependencies/installed libraries. Resolution MUST be deterministic and MUST NOT search arbitrary filesystem locations. Duplicate IDs in one resolution scope are invalid. A package MAY embed a referenced asset/resource or depend on an external package that exports it.

Definitions are persistent authoring state. Runtime source/effect instances, voices, meters, smoothing/history buffers, and transient automation are instance state and are not assets. Changing instance state MUST NOT silently mutate shared presets or definitions. Tools SHOULD create a new asset/revision when committing reusable changes.

Required references must resolve before activation. Optional references declare explicit fallback behavior such as `silence`, `bypass`, or `omit`; no implicit substitution is allowed. Content hashes MAY verify resources but are Draft-optional pending canonicalization. See [packages](packages.md) and [serialization](serialization.md).
