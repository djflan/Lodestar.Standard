# Events

Native Lodestar events target a Part by stable ID. The Performance resolves Part → optional Instrument → Layers → Sources → Providers. Providers receive relevant events with sample offsets inside the current render block.

V1 event concepts include note-on (note identity, pitch, velocity), note-off (note identity and release velocity when known), per-note expression, Part control, and parameter automation. A note identity distinguishes overlapping notes of equal pitch. A runtime parameter address contains a `resolutionScope`, `nodeKind`, stable `nodeId`, and stable provider-owned `parameterId`; it is a control target, not a serialized automation lane. Each parameter descriptor declares its ID, display name, value kind (`number`, `boolean`, or `enum`), native minimum/maximum/default where numeric, unit label, normalized flag, and automatable/read-only flags. V1 requires `step` and `linear`; a target MAY additionally advertise provider-defined curves. A host MUST NOT silently replace an unsupported curve.

Events MUST be ordered by absolute musical/sample time; events at the same sample retain source order. A host MUST deliver block-local offsets in `0..frameCount-1` and carry boundary events to the correct block. Tempo/beat conversion belongs to the host timeline; rendered providers receive resolved timing plus any declared musical context.

MIDI is an import/live adapter. An adapter maps its addressing and messages to Lodestar Part IDs and runtime controls. MIDI conventions and legacy profile behavior are host-defined; they MUST NOT alter the persistent hierarchy, force a Part/channel count, or become native Lodestar state. Lossy or ambiguous mappings SHOULD be reported.

## Sequencing and host automation boundary

Lodestar v1 does not serialize sequences, tempo maps, time signatures, transport, arrangements, automation lanes, or MIDI mappings in a Performance or `.star` package. A DAW, workstation editor, or other host owns that state and resolves it into timestamped native events before delivery. This boundary keeps the Standard focused on portable workstation content and runtime rendering rather than defining a second sequencing or DAW format.
