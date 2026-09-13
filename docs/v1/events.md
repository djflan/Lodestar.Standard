# Events

Native Lodestar events target a Part by stable ID. The Performance resolves Part → optional Instrument → Layers → Sources → Providers. Providers receive relevant events with sample offsets inside the current render block.

V1 event concepts include note-on (note identity, pitch, velocity), note-off (note identity and release velocity when known), per-note expression, Part control, and parameter automation. A note identity distinguishes overlapping notes of equal pitch. Normalized values use 0..1 unless a parameter declares another unit/range.

Events MUST be ordered by absolute musical/sample time; events at the same sample retain source order. A host MUST deliver block-local offsets in `0..frameCount-1` and carry boundary events to the correct block. Tempo/beat conversion belongs to the host timeline; rendered providers receive resolved timing plus any declared musical context.

MIDI is an import/live adapter. An adapter maps channel/port addressing to Part IDs, translates messages, and may apply GM/GM2/GS/XG profiles. Those protocols MUST NOT alter the persistent hierarchy or force 16 Parts/channels. Lossy or ambiguous mappings SHOULD be reported. Automation curve/interpolation requirements remain open.
