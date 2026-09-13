# Channels

V1 defines Layer, Instrument, Part, Bus/Return, and Master channel roles. Each processes one signal and MAY expose gain, pan, ordered insert slots, sends, and an output route. Mute and solo are applicable to Layer, Instrument, Part, and Bus/Return channels; Master mute is allowed, while Master solo is not meaningful.

Common persistent state is a stable channel ID, enabled/mute/solo flags where applicable, linear gain, normalized pan, insert chain, sends, and output destination. Metering and UI state are not portable channel state.

The settled conceptual order is:

```text
source/input → ordered inserts → fader/gain and pan → sends/output
```

V1 Draft has not settled send tap placement relative to inserts/fader. Implementations MUST preserve a serialized supported placement and MUST diagnose an unsupported placement. Insert slots process in list order. Mute produces silence on the affected channel and its post-mute routes. Solo resolution is host/mixer policy but MUST retain required ancestors and bus returns so a soloed signal remains audible.

Gain 1 is unity and 0 is silence. Pan is -1 left, 0 center, and +1 right. The pan law remains declared implementation/profile behavior until finalized. Channels MAY be optimized away only if audible routing and state semantics remain equivalent.
