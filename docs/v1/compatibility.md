# Compatibility and Conformance

A **v1 runtime** conforms when it validates/loads v1 JSON, resolves stable references, implements the hierarchy and both mixer scopes, supports stereo audio, enforces acyclic routing, schedules Part-targeted events, honors required/optional handling, and reports unsupported features without silent reinterpretation.

A **source provider** conforms when it registers stable identity and supported payload versions, prepares outside render, accepts applicable timed events, produces stereo boundary audio, and meets realtime rules. An **effect provider** does the equivalent for ordered input processing and bypass/passthrough behavior.

A **content package/tool** conforms when its ZIP/manifest/assets validate, references and requirements are explicit, paths are safe, and serialized meaning is preserved. Authoring tools SHOULD preserve unknown fields/extensions.

Required missing assets, resources, providers, payload versions, or unknown required semantics make the affected asset unavailable. Optional items MUST declare fallback at their point of use: source silence/omission, effect bypass, or optional asset omission. Hosts MUST surface degradation and MUST NOT silently replace providers or presets.

Package release compatibility is separate from Standard compatibility. Provider implementation versions are separate from payload versions. A runtime may support newer optional extensions while remaining v1-conforming; it MUST reject an unsupported Standard version or required feature.
