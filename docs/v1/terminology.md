# Terminology

> **Status: Draft**

- **Performance**: A playable top-level configuration containing Parts.
- **Part**: A playable role within a Performance that refers to an Instrument.
- **Instrument**: A definition composed of one or more Layers.
- **Layer**: A constituent of an Instrument that refers to a Source.
- **Source**: A provider-created signal origin.
- **Effect**: A provider-created signal processor.
- **Channel**: A processor with one signal input.
- **Mixer**: A processor that combines multiple signals.
- **Bus**: An alternate or shared routing destination.
- **Submix bus**: A Bus used to combine signals before forwarding the result.
- **Send bus**: A Bus that receives a routed send from another signal path.
- **Provider**: An abstraction through which a host resolves or creates Sources or Effects.
- **`.star` package**: A Lodestar content package.

Terms not defined here retain their ordinary audio or software meaning and are not yet normative.
