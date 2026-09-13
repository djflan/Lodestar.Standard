# Routing

> **Status: Draft**

Lodestar distinguishes three routing roles:

- A **Channel** processes one signal.
- A **Mixer** combines multiple signals.
- A **Bus** is an alternate or shared routing destination.

The model supports both **submix buses** and **send buses**. A submix bus combines routed signals before forwarding its output. A send bus receives a send from another signal path, allowing shared processing or other parallel routing.

The draft does not yet define graph serialization, feedback rules, send level semantics, pre/post-fader placement, channel layouts, latency compensation, or cycle detection.
