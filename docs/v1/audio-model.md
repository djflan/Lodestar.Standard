# Audio Model

V1 exchanges non-interleaved floating-point audio at provider/channel boundaries. Each buffer contains an equal number of sample frames per channel; a frame is the simultaneous sample position across channels. Stereo is the REQUIRED interchange layout. Providers that are internally mono or multichannel MUST adapt to stereo at their boundary and MUST declare any lossy adaptation. The normative pan law and mono conversion rule remain [open](decisions-and-open-questions.md).

The host supplies sample rate and block frame count during preparation. Implementations MUST support variable block lengths up to a prepared maximum and MUST NOT assume one fixed musical duration per block. Sample rate, maximum block size, and layout MUST NOT change during a render call; hosts MUST re-prepare affected instances for configuration changes.

A source provider receives time-stamped events and writes/replaces its Layer input buffer. Effects transform one channel signal. Channels, buses, and mixers remain host-owned semantic boundaries even when an optimized engine fuses operations.

Silence is numeric zero. Providers MUST handle silent input and MUST NOT deliberately emit NaN or infinity; hosts SHOULD contain non-finite output at provider boundaries. Implementations SHOULD suppress or flush denormals without changing audible behavior. V1 does not mandate headroom, saturation, a limiter, or hard clipping. Hosts MUST avoid integer-style clipping inside the floating-point graph and MUST document any output clipping/limiting.

Offline and realtime rendering MUST preserve routing and sample-position event semantics. Bit-identical results are not currently required; declared deterministic providers SHOULD reproduce output for identical prepared state, events, timing, and render configuration. See [events](events.md) and [realtime](realtime.md).
