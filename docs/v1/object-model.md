# Object Model

> **Status: Draft**

The settled Lodestar content hierarchy is:

```text
Performance -> Part -> Instrument -> Layer -> Source
```

A Performance contains Parts. A Part refers to an Instrument. An Instrument contains Layers. A Layer refers to a Source.

This hierarchy establishes composition only. Cardinality rules beyond the natural container relationships, object identity, ownership, sharing, mutability, inheritance, overrides, parameter binding, and lifecycle are not yet specified.
