# Selenium

This project includes several Selenium examples in both xUnit and Cucumber (SpecFlow). We
will also use it to practice a Tic Tac Toe exercise.

## Prerequisites

In order to run browser tests, Selenium will need to be able to drive a browser
installed to your system. By default, this repo is configured to launch Chrome
If you don't have Chrome available, you can also use Internet Explorer or Firefox.

To change the browser Selenium will launch, edit `BrowserName` in
`Selenium.Test/Support/Browser.cs` to any of "msie", "chrome", or "firefox".

## Examples

Here's a look at what the project contains:

```
.
└── Selenium.Test
    ├── Example
    │   └── GoogleTest.cs
    ├── Support
    │   └── Browser.cs
    ├── TicTacToe
    │   └── TicTacToeTest.cs
    └── ToDo
        ├── ToDo.feature
        ├── ToDo.feature.cs
        ├── ToDoSteps.cs
        ├── ToDoTest.cs
        └── ToDoUtil.cs
```

We'll break it down below.

### Support.Browser

`Browser` is a helper class created to ease some of the pain of configuring
Selenium to launch a browser and search for elements both expected to and not
expected to exist on the page.

To see how the class is used, look at the two included examples:

### Example.GoogleTest

`Example.GoogleTest` is a minimal xUnit test that uses Selenium to search Google
and verify—when searching for "Cheese!"—that "cheese curds" is one of the
auto-complete suggestions.

### ToDo*

The `ToDo` package contains lots of tests of [this todo
app](http://testdouble.github.io/todos/), both in xUnit and in Cucumber. It
defines a `ToDoUtil` helper class to make the tests a little easier to read,
removing some of the "selenese" from the story the tests are trying to tell.

### TicTacToe*

The primary exercise in this project is to attempt to write some tests against
a simple interface with non-deterministic behavior against this
[tic-tac-toe](http://tic-tac-toe-kb.herokuapp.com) game:

http://tic-tac-toe-kb.herokuapp.com

The interface is complex enough to warrant some helpers (perhaps organized as
[Page Objects](http://martinfowler.com/bliki/PageObject.html), but any tests will
need to be designed cleverly, in such a way as to react to the move of the site's
AI opponent. In effect, your test will need to be enough of an AI in its own
right to be confident that the tic-tac-toe app is up-and-running.

You may use either xUnit or Cucumber to drive the `TicTacToe.TicTacToeTest`. If
you're stuck, we recommend looking at the tests in the `ToDo` package for
reference.
