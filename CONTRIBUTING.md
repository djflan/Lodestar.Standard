# Contributing

Lodestar Standard v1 is a draft. Contributions are welcome, but proposed behavior should not be presented as settled specification text until it has been accepted.

## Making a change

1. Open an issue or add a proposal under `docs/proposals` for a material design change.
2. Keep normative language precise. Use **MUST**, **SHOULD**, and **MAY** only when defining conformance requirements.
3. Update documentation, schemas, contracts, examples, and tests together when they describe the same accepted behavior.
4. Avoid adding implementation policy to the standard unless portability requires it.
5. Run `dotnet test src/Lodestar.Standard.slnx` before submitting a change.

## Draft compatibility

Breaking changes are expected while v1 remains Draft. Record them in `CHANGELOG.md` and call them out clearly in proposals and pull requests.
