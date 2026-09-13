# Buses

Every Bus belongs to exactly one Instrument or Performance Mixer scope. It owns a Bus/Return Channel that sums all incoming edges, processes ordered inserts, applies gain/pan, emits sends, and routes one output. A bus has a stable local ID and kind: `submix` or `send`.

A submix bus receives primary outputs and therefore groups signals serially. A send bus receives parallel send taps; its output is the Return Channel. The return routes to the scope output or a valid downstream submix bus. A bus MAY have inserts, sends, gain/pan, mute/solo where relevant, and an output route.

Inputs are summed frame-aligned before bus inserts. Incoming send amounts apply before summing. The send bus effect's own wet/dry behavior does not redefine the parallel routing topology; authors commonly use fully wet effects, but v1 does not force that provider setting.

Instrument buses accept Layer Channel/bus routes and remain inside the Instrument Mixer. Performance buses accept Part Channel/bus routes and remain inside the Performance Mixer. Instrument buses cannot target Performance buses directly; only the Instrument output crosses to its Part.

Example: route Layer A and B to submix `body`, route Layer C directly, put compression on `body`, and send all desired Layer/bus signals to send bus `room`. At Performance scope, Parts can similarly feed a `band` submix and `reverb` send. All combined edges MUST be acyclic. See [routing](routing.md).
