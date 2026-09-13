# Missing optional provider

The manifest declares `org.example.effect.shimmer` with `required: false` and `fallback: bypass`. If it is absent, a conforming host preserves the unknown effect data, bypasses the optional slot, reports that the Performance is degraded, and continues. It does not silently select another reverb. A missing required source provider instead makes the affected Instrument unavailable before activation.
