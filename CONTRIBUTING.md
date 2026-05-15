# Contributing to Hussy.Net

We follow standard C# conventions for defining features and driving the primary components of the dialect and address any concerns as part of the pull request process.

## New Features

Feature development is driven by the [project board](https://github.com/users/tacosontitan/projects/10/views/11) and the lifecycle begins with [opening an issue in the repository](https://github.com/tacosontitan/Hussy.Net/issues) for review. New features must include a link to a problem the feature is trying to be introduced to assist with, details on how the feature should ideally function, and justification for the feature's addition to the dialect (to include potential alternatives that already exist and why they don't quite solve the problem). Once a feature is approved and ready for work, contributors can drive development of the feature in the playground by following the established patterns for creating a problem pit (see the [playground README](./samples/Hussy.Net.Playground/README.md) for more details).

## Automated Releases

Releases are automated by [`.github/workflows/release.yml`](./.github/workflows/release.yml) whenever commits are merged into `main`. The workflow:

- Restores and builds the primary package project (`src/Hussy.Net/Hussy.Net.csproj`).
- Packs and publishes `Hussy.Net` to NuGet.
- Verifies the NuGet package contains analyzer and code-fix assets (`analyzers/dotnet/cs/Hussy.Net.Analyzers.dll`).
- Creates and pushes a git tag for the release.
- Creates a GitHub Release and uploads the generated NuGet package asset.

### Required Repository Secret

Configure the following repository secret before enabling release publishing:

- `NUGET_API_KEY`: API key with permission to publish `Hussy.Net` to NuGet.org.

### Versioning Strategy

The release workflow determines the version from git tags and the primary project metadata:

1. If a `v<major>.<minor>.<patch>` tag already exists, the next release increments the patch number.
2. If no release tag exists yet, the workflow uses the `Version` value in `src/Hussy.Net/Hussy.Net.csproj` (`1.0.0`).

To ship a non-patch release (for example `2.0.0`), create and merge a PR that updates `<Version>` in `src/Hussy.Net/Hussy.Net.csproj` before the next merge to `main`.
