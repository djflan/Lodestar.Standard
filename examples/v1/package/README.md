# Example `.star` package

```text
ExampleFactory.star
├── manifest.json
├── instruments/minimal-synth.json
├── performances/stage.json
└── resources/soundfonts/factory.sf2
```

The paths locate embedded entries; assets refer to `org.example.factory:instrument:minimal-synth` and `org.example.factory:resource:factory-piano-sf2` by logical ID. The manifest version `1.2.0` is the package release, not Lodestar Standard `1-draft`.
