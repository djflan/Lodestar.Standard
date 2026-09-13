# Providers

Source and Effect Providers are code discovered and registered with a host; they are normally not packaged inside `.star` content. The Standard defines roles and identity, not a plugin binary format or language ABI.

A provider registration MUST expose a stable provider ID, role (`source` or `effect`), implementation version, and supported payload versions. Hosts MUST match both role and ID and verify payload compatibility before preparation. Providers MAY advertise capabilities for discovery and authoring UI, but presets MUST NOT duplicate those declarations as compatibility requirements.

Provider and asset IDs use lowercase reverse-DNS authority followed by optional colon-separated local components, for example `org.lodestar.helios` or `org.lodestar.factory:instrument:dream-piano`. Each component MUST match `[a-z0-9](?:[a-z0-9._-]*[a-z0-9])?`; the authority MUST contain at least one dot. IDs are case-sensitive, immutable, stable across compatible releases, and MUST NOT derive from an install path. A registry prevents authority collisions but does not assign meaning to local components.

`payloadVersion` is an opaque exact-match token in v1, not a SemVer range. A provider advertises every exact payload version it supports. A host may load a definition only when its exact token is advertised; breaking interpretation requires a new token or provider identity.

If a required provider or payload version is missing, the host MUST diagnose the exact requirement and MUST NOT substitute another provider silently. If usage is marked optional, the host MAY bypass/omit it, produce the declared silence/passthrough, and report degradation. Unknown provider payload remains opaque and SHOULD be preserved.

Helios, Aurora, and FluidSynth are ecosystem examples only. Conformance cannot require them, and independent—including commercial or closed-source—hosts/providers are allowed.
