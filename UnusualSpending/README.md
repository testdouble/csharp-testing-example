# UnusualSpending

This project is for implementing the [Unusual Spending
Kata](https://github.com/testdouble/contributing-tests/wiki/Unusual-Spending-Kata).
It is preconfigured with Xunit, and Moq for testing. It is also
set up to import the third-party dependencies needed by the kata and defined in
[UnusualSpendingVendor](../UnusualSpendingVendor).

```
.
├── README.md
├── UnusualSpending
│   └── TriggersUnusualSpendingEmail.cs
├── UnusualSpending.Test
│   └── TriggersUnusualSpendingEmailTest.cs
```

To get started, write a Collaboration test for
`UnusualSpending.TriggersUnusualSpendingEmail` that breaks the problem down into two,
three, or four parts.
