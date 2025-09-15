# Playground

Welcome to the playground! This area is the proving grounds for Hussy.Net and drives the primary development through solving classical programming problems and ensuring that shortcuts in the dialect are meaningful.

## Getting Started

The playground is broken down into what we refer to as "pit". The primary components of a pit are the overview, dry run, golf run, hussy run, and the test suite.

<sub>Any of the easy Leetcode pits are a good resource to reference when creating a new pit.</sub>

### Overview

The overview file in each pit contains a link to the problem on the web, the relevant details of the problem (just in case the link drops at some point), links to any relevant reference materials (such as Wikipedia), and the delegate defining the signature of the test function.

### Tests

The test suite is broken into two distinct areas of concern - the setup file, and each test case. The setup file defines a collection of test functions and the core test function that all test cases should use to validate with xUnit.

### Dry Run

A dry run is simply an initial attempt at solving the problem with native C# and is intended to be a clear, clean, and concise solution. The idea here isn't to be clever yet, it's to understand the problem and propose a basic solution that a general audience can understand - documentation is our friend.

### Golf Run

A golf run is where being clever comes in; abandon maintainability, your goal is to condense your dry run as much as possible - remember, in code golf, the fewer the number of bytes in your solution, the more likely you are to win. Be sure to add XML documentation describing how the golfed solution ties back to the dry run so that the general audience can learn to follow along.

### Hussy Run

This is where the magic happens. The Hussy run is where we condense the golf run as much as possible using the pre-defined extensions and global static functions that compose the full Hussy.Net dialect of C#. New features are often proposed by finding shortcomings in the dialect during this phase, so be sure to propose them as an [issue](https://github.com/tacosontitan/Hussy.Net/issues)!