# 💃 Hussy.Net

Hussy.Net is an esoteric programming language designed for and by C# developers with code golf in mind. It is a minified adaptation of the C# programming language leveraging modern features for clean and concise code.

![License](https://img.shields.io/github/license/tacosontitan/Hussy.Net?logo=github&style=for-the-badge)

> [!IMPORTANT]
> Hussy.Net is not designed to compete with other golfing languages, but rather to allow C# developers to participate in golfing challenges with a leg to stand on.

## 🤦🏻‍♀️ 2.0.0

This release is a minor improvement upon the initial release in support of automated future releases. The following new features have also been added:

- Code analyzer and fix for using `Ts` over `ToString`.

## 🚀 Initial Release

The initial release (version `1.0.0`) includes the baseline offerings of Hussy.Net:

- Condensed static API surface exposed through the `Hussy` class for golf-friendly C# snippets.
- Core math helpers for concise arithmetic and numeric transformations.
- Logic helpers for common predicates such as parity, divisibility, null checks, and reversal-based comparisons.
- Sequence and LINQ-style helpers for batching, filtering, de-duplication, and string joining.
- Output helpers for streamlined console writing, separators, and simple header formatting.
- Input helpers for typed console prompts using `IParsable<T>`.
- Iteration helpers for repeat and loop-style workflows with minimal syntax overhead.
- Included challenge-oriented modules and samples such as Hello World, FizzBuzz, and palindrome checks.