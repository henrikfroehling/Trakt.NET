Contributing Guidelines
===

### **First off, thank you for considering contributing to** [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET)**.**

[Trakt.NET](https://github.com/henrikfroehling/Trakt.NET) is an open source project and there are many ways to contribute, from writing new examples or improving existing ones, improving the documentation, submitting bug reports and feature requests or writing code which can be incorporated into [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET).

**Please do not use the issue tracker for support questions.** If you have questions regarding on how to use the library, there is a [chat room on Gitter](https://gitter.im/Trakt-NET/Lobby) for that.

**Working on your first Pull Request?** You can learn how from this *free* series [How to Contribute to an Open Source Project on GitHub](https://egghead.io/series/how-to-contribute-to-an-open-source-project-on-github)

---

### **Currently, there are the following limits on submitting pull requests**
- Contributions must be discussed with the maintainer first by opening an issue, or they will likely be declined.
- Only contributions against the [develop](https://github.com/henrikfroehling/Trakt.NET/tree/develop)-branch will be accepted. Authors submitting pull requests that target experimental feature branches or the [master](https://github.com/henrikfroehling/Trakt.NET/tree/master)-branch will likely be asked to target their pull request against the develop-branch.
- Pull requests that do not merge easily with the tip of the develop-branch will be declined. The author will be asked to merge with the tip of the targeted branch and update the pull request.
- Submissions must meet funtional expectations, including scenarios for which the maintainer does not yet have open source tests. This means you may be asked to fix and resubmit your pull request against a new open test case if it fails one of these tests.
- Submissions must follow the rules stated in the [Coding Guidelines](https://github.com/henrikfroehling/Trakt.NET/blob/develop/coding_style.md).
- Contributions must follow the [additional requirements](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#additional-requirements-for-pull-requests).

---

### **Additional requirements for pull requests**
- Ensure [cross-platform compatibility](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#cross-platform-compatibility) for new features.
- New features must have accompanying [unit tests](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#unit-tests) with "good" code coverage.
- Changes to existing functionality needs to be checked that it does not break any existing [unit tests](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#unit-tests).

---

### **Coding conventions**
- Use the coding style outlined in the [Coding Guidelines](https://github.com/henrikfroehling/Trakt.NET/blob/develop/coding_style.md).
- Use plain code to validate arguments at public boundaries. Do not use contracts or magic helpers.
```csharp
if (argument == null)
    throw new ArgumentNullException(nameof(argument), "optional message");
```
- Use `Debug.Assert()` for checks not needed in release builds. Always include a "message" string in your assert to identify failure conditions.

---

### **Getting started**
1. Create your own fork of the repository
2. Do the changes in your fork
   - Create a branch for the change with a descriptive name.
3. If you like the change:
   - Be sure you have followed the [Coding Guidelines](https://github.com/henrikfroehling/Trakt.NET/blob/develop/coding_style.md).
   - Be sure you have followed the [additional requirements](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#additional-requirements-for-pull-requests).
   - Send a pull request

---

### **Build requirements**
- at least Visual Studio 2017 with support for C# 7.2

---

### **Cross-platform compatibility**
- [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET) is built against .NET Standard 1.1

---

### **Unit Tests**
- all new tests need to be added to the project `Trakt.NET.Tests`
  - the test framework is XUnit
