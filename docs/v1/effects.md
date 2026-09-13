# Effects

An Effect Definition identifies exactly one Effect Provider, provider payload version, optional preset, direct resource references, and provider-specific payload. An Insert Slot owns or references one Effect Definition, has stable slot identity and bypass state, and participates in an ordered Effect Chain.

Insert effects are permitted on Layer, Instrument, Part, Bus/Return, and Master channels. Slots process strictly in chain order. Bypass MUST pass the input without provider-dependent coloration; hosts SHOULD preserve state while bypassed. Failure behavior follows [compatibility](compatibility.md).

An Insert Slot MAY define `wetDry` in the normalized range 0..1, defaulting to 1. The host computes `output = dryInput * (1 - wetDry) + processedOutput * wetDry`; bypass remains an exact dry passthrough independent of this value. A provider MAY expose an internal mix parameter, but that parameter is provider-specific and does not replace the portable slot property. Send topology is defined independently by routing.

Each Effect Preset belongs to exactly one Effect Provider. An Effect Chain or channel may compose slots from many Effect Providers. Effect Presets MAY directly reference resources such as impulse responses or captured models. Runtime parameters and delay/history buffers are instance state unless explicitly saved. Aurora is the canonical in-house provider but is not a normative dependency.
