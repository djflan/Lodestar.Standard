# Channels

V1 defines Layer, Instrument, Part, Bus/Return, and Master channel roles. Each processes one signal and MAY expose gain, pan, ordered insert slots, sends, and an output route. Mute and solo are applicable to Layer, Instrument, Part, and Bus/Return channels; Master mute is allowed, while Master solo is not meaningful.

Common persistent state is a stable channel ID, enabled/mute/solo flags where applicable, linear gain, normalized pan, insert chain, sends, and output destination. Metering and UI state are not portable channel state.

The settled conceptual order is:

```text
source/input → ordered inserts → fader/gain and pan → sends/output
```

V1 supports `preFader` and `postFader` send taps. An omitted tap defaults to `postFader`. A pre-fader tap occurs after ordered inserts and before channel gain, pan, and mute; a post-fader tap occurs after those operations. Implementations MUST diagnose an unsupported placement rather than substitute it. Insert slots process in list order. Mute produces silence on the affected channel and its post-fader routes; pre-fader sends remain active. Solo resolution is host/mixer policy but MUST retain required ancestors and bus returns so a soloed signal remains audible.

Gain 1 is unity and 0 is silence. Pan is -1 left, 0 center, and +1 right. V1 uses an equal-power stereo pan law: `leftGain = cos((pan + 1) * pi / 4)` and `rightGain = sin((pan + 1) * pi / 4)`. Channels MAY be optimized away only if audible routing and state semantics remain equivalent.
