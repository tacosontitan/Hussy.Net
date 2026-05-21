# Copilot Instructions for Hussy.Net

## Project Overview
- Hussy.Net is an esoteric .NET dialect for C# code golf.
- Solution root: `Hussy.Net.sln`.
- Primary library: `src/Hussy.Net`.
- Roslyn analyzers: `src/Hussy.Net.Analyzers`.
- Console playground: `src/Hussy.Net.Terminal`.
- Unit tests: `test/Hussy.Net.Tests` and `test/Hussy.Net.Analyzers.Tests`.

## Platform and Language
- Target framework is `.NET 10` (`net10.0`).
- C# language version is `preview`.
- Nullable reference types are enabled.
- Implicit usings are enabled.

## Build and Test Expectations
- Build from repo root with `dotnet build`.
- Run full tests from repo root with `dotnet test`.
- For changes to analyzers, ensure analyzer tests are updated and passing.
- For behavior changes in the library, add or update tests in `test/Hussy.Net.Tests`.

## Coding Guidance
- Keep changes small, focused, and compatible with existing APIs unless explicitly requested.
- Favor concise implementations, but preserve readability and maintainability.
- Follow existing naming and folder conventions in each module area (`Logic`, `Math`, `Linq`, `Modules`, etc.).
- Reuse existing abstractions before introducing new ones.
- Avoid introducing unnecessary dependencies.

## Analyzer and Packaging Notes
- `Directory.Build.props` applies shared settings and global usings.
- Do not create direct project-reference cycles between `Hussy.Net` and `Hussy.Net.Analyzers`.
- Analyzer packaging is expected to ship `Hussy.Net.Analyzers.dll` with `Hussy.Net` package under `analyzers/dotnet/cs`.

## Pull Request Quality Bar

- Tests are included for code changes.
- Analyzers and code fixes are added for all new features (and bugs where applicable).
- Version updates are made:
  - Follow semantic versioning principles.
  - For bug fixes, increment patch version (e.g., `1.0.0` to `1.0.1`).
  - For new features, increment minor version (e.g., `1.0.0` to `1.1.0`).
  - For breaking changes, increment major version (e.g., `1.0.0` to `2.0.0`), but avoid these unless necessary.
  - Version number must be updated in `Directory.Build.props` and `RELEASE_NOTES.md`.
- Keep public API changes intentional and documented.
- Prefer deterministic behavior and avoid hidden side effects.