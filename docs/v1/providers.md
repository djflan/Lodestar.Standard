# Providers

> **Status: Draft**

Sources and Effects use provider abstractions. A host interacts with provider contracts rather than depending on a particular synthesis, sampling, processing, or plug-in implementation.

The v1 .NET contracts currently establish separate `ISourceProvider` and `IEffectProvider` roles. Provider identity, discovery, capabilities, version negotiation, creation requests, state exchange, error reporting, and lifetime management remain open.
