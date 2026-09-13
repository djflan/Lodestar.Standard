# Real-Time Behavior

Before activation, hosts resolve packages/resources, validate routes, discover providers, allocate memory, create instances, load/decode resources, and call provider preparation. Render callbacks MUST NOT perform filesystem/network I/O, provider discovery, unbounded allocation, unbounded locks, blocking waits, process creation, logging that can block, or other work without a known realtime bound.

Providers MUST disclose preparation requirements and maximum prepared block/layout constraints. Their render calls MUST operate only on prepared state and supplied buffers/events. State replacement that needs allocation or I/O MUST be prepared off the audio thread and swapped using bounded synchronization. Cleanup MAY occur later off-thread.

Hosts MUST supply monotonically coherent timing and correctly bounded sample offsets. Providers MUST not retain host buffers beyond the call unless the contract explicitly transfers ownership. Errors in render SHOULD degrade to silence for a Source or passthrough for an Effect, be recorded through a realtime-safe diagnostic channel, and avoid destabilizing unrelated paths.

Implementations SHOULD avoid denormals/non-finite samples, make seeded randomness explicit, and document nondeterministic behavior. `deterministicOfflineRendering` is an optional reported capability, not baseline conformance. A provider claiming it MUST produce identical output for identical prepared state, resolved resources, events, timing, render configuration, and declared seed; it MUST disclose any external dependency that can affect the result. No hard CPU, memory, voice, bus, or latency limit is normative; hosts SHOULD expose soft limits during validation rather than fail unpredictably during render.
