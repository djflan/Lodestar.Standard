# Events

Native Lodestar events target a Part by stable ID. The Performance resolves Part → optional Instrument → Layers → Sources → Providers. Providers receive relevant events with sample offsets inside the current render block.

V1 event concepts include note-on (note identity, pitch, velocity), note-off (note identity and release velocity when known), per-note expression, Part control, and parameter automation. A note identity distinguishes overlapping notes of equal pitch. Automation targets a stable parameter ID. Each parameter descriptor declares its native minimum, maximum, default, unit label, whether values are normalized, and supported interpolation. V1 requires `step` and `linear`; a target MAY additionally advertise provider-defined curves. A host MUST NOT silently replace an unsupported curve.

Events MUST be ordered by absolute musical/sample time; events at the same sample retain source order. A host MUST deliver block-local offsets in `0..frameCount-1` and carry boundary events to the correct block. Tempo/beat conversion belongs to the host timeline; rendered providers receive resolved timing plus any declared musical context.

MIDI is an import/live adapter. An adapter maps channel/port addressing to Part IDs, translates messages, and may apply GM/GM2/GS/XG profiles. Those protocols MUST NOT alter the persistent hierarchy or force 16 Parts/channels. Lossy or ambiguous mappings SHOULD be reported.

## Portable sequence and tempo state

A Performance MAY contain one ordered Sequence and one Tempo Map. Sequence events use musical beat positions and target Parts by stable ID; event payloads use the same native event concepts as live delivery. A Tempo Map contains ordered tempo points with non-negative beat positions and positive beats-per-minute values. Beat zero MUST have an effective tempo, supplied either by an explicit point or the default 120 BPM.

Exactly one timing authority is active during playback: `performance` uses the Performance Tempo Map; `host` uses the host timeline. The serialized default is `performance`. A host override is allowed only through an explicit user/API selection and MUST NOT rewrite the canonical Performance tempo data. The active authority resolves beat positions to sample time before block-local delivery.
