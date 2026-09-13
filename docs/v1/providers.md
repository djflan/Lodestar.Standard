# Providers

Source and Effect Providers are code discovered and registered with a host; they are normally not packaged inside `.star` content. The Standard defines roles and identity, not a plugin binary format or language ABI.

A provider registration MUST expose a stable provider ID, role (`source` or `effect`), implementation version, supported payload versions, and capability IDs. Hosts MUST match both role and ID and MUST verify every required capability before preparation. Discovery MAY use static registration, dependency injection, OS services, or plugin scanning.

Provider IDs and capability IDs are logical identifiers. They MUST remain stable across compatible releases and MUST NOT be derived from an install path. The final lexical/registry policy remains open. Provider version changes SHOULD remain backward-compatible for supported payload versions; breaking payload interpretation requires a new payload version or provider identity.

If a required provider/capability is missing, the host MUST diagnose the exact requirement and MUST NOT substitute a different provider silently. If marked optional, the host MAY bypass/omit that Source or Effect, produce silence/passthrough as declared by the asset, and report degradation. Unknown provider payload remains opaque and SHOULD be preserved by tools.

Helios, Aurora, and FluidSynth are ecosystem examples only. Conformance cannot require them, and independent—including commercial or closed-source—hosts/providers are allowed. Preparation/lifetime and render obligations are in [realtime](realtime.md).
