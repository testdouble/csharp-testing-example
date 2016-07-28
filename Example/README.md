# Example project

This is a mostly-empty project placed here to be a sandbox for any one-off
source listings, exercises, or tests you might like to write. It's preconfigured
with xUnit, and Moq.

See `../ExampleCucumber` for an example project that's pre-configured to run
Cucumber tests.

## Example code

In the code that's included in this project, you'll see an example of a
collaborator test (for `FeedsWalrus`), and two regression tests (for `OpensCan`
and `Walrus`). They serve as examples of using xUnit and Moq.

```
.
Example
├── Example
│   ├── FeedsWalrus.cs
│   ├── IOpensCans.cs
│   ├── OpensCans.cs
│   └── Values
│       ├── CannedWalrusFood.cs
│       ├── Walrus.cs
│       └── WalrusFood.cs
└── Example.Test
    ├── FeedsWalrusTest.cs
    ├── OpensCansTest.cs
    └── Values
        └── WalrusTest.cs
```
