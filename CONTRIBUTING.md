Contributing Guidelines
===

### **First off, thank you for considering contributing to TraktApiSharp.**

TraktApiSharp is an open source project and there are many ways to contribute, from writing new examples or improving existing ones, improving the documentation, submitting bug reports and feature requests or writing code which can be incorporated into TraktApiSharp.

**Please do not use the issue tracker for support questions.** If you have questions regarding on how to use the library, there is a [chat room on Gitter](https://gitter.im/traktapisharp/Lobby) for that.

**Working on your first Pull Request?** You can learn how from this *free* series [How to Contribute to an Open Source Project on GitHub](https://egghead.io/series/how-to-contribute-to-an-open-source-project-on-github)

---

### **Currently, there are the following limits on submitting pull requests**
- Contributions must be discussed with the maintainer first by opening an issue, or they will likely be declined.
- Only contributions against the [dev](https://github.com/henrikfroehling/TraktApiSharp/tree/dev)- and the [next-version](https://github.com/henrikfroehling/TraktApiSharp/tree/next-version)-branch will be accepted. Authors submitting pull requests that target experimental feature branches or the [master](https://github.com/henrikfroehling/TraktApiSharp/tree/master)-branch will likely be asked to target their pull request against the dev- or next-version-branch. **Please also read the guideline below on how to choose the right branch to target for your pull request.**
- Pull requests that do not merge easily with the tip of the dev- or next-version-branch will be declined. The author will be asked to merge with the tip of the targeted branch and update the pull request.
- Submissions must meet funtional expectations, including scenarios for which the maintainer does not yet have open source tests. This means you may be asked to fix and resubmit your pull request against a new open test case if it fails one of these tests.
- Submissions must follow the rules stated in the [Coding Guidelines](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/coding_style.md).
- Contributions must follow the [additional requirements](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/CONTRIBUTING.md#additional-requirements-for-pull-requests).

---

### **Additional requirements for pull requests**
- Ensure [cross-platform compatibility](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/CONTRIBUTING.md#cross-platform-compatibility) for new features.
- New features must have accompanying [unit tests](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/CONTRIBUTING.md#unit-tests) with "good" code coverage.
- Changes to existing functionality needs to be checked that it does not break any existing [unit tests](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/CONTRIBUTING.md#unit-tests).
- If you use Visual Studio 2017, please make sure you are not using any language features only available in C# 7.

---

### **Guideline on how to choose the right branch for your pull request**

There are currently two branches you can choose to target for your pull request:
- **dev**: This branch tracks the current development of all **versions below 1.0.0**
- **next-version**: This branch tracks the current development of the next major **(1.0.0) version**

If you want to implement a new feature (e.g. a new Trakt API endpoint), you have to target the dev-branch. All bug fixes targeting TraktApiSharp **versions below 1.0.0** go into the **dev**-branch.

Bug fixes targeting TraktApiSharp **version 1.0.0** go into the **next-version**-branch.
New features, which are meant to be released in the next major version (1.0.0), go into the next-version-branch.

**All changes made in the dev-branch have to be incorporated into the next-version-branch. [You can find more information on this topic here.](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/CONTRIBUTING.md#differences-between-the-branches-dev-and-next-version)**

---

### **Coding conventions**
- Use the coding style outlined in the [Coding Guidelines](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/coding_style.md).
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
   - Be sure you have followed the [Coding Guidelines](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/coding_style.md).
   - Be sure you have followed the [additional requirements](https://github.com/henrikfroehling/TraktApiSharp/blob/dev/CONTRIBUTING.md#additional-requirements-for-pull-requests).
   - Send a pull request

---

### **Build requirements**
- at least Visual Studio 2015 with support for C# 6

---

### **Cross-platform compatibility**
- TraktApiSharp is built against the PCL Profile 111 on the *dev*-branch
- on branch *next-version*, the library is built against .NET Standard 1.2

---

### **Unit Tests**
- on branch *dev*, all new tests need to be added to the project `TraktApiSharp.PreNextVersion.Tests`
  - the test framework is MSTest
- on branch *next-version*, all new tests need to be added to the project `TraktApiSharp.Tests`
  - the test framework is XUnit
- all existing tests on branch *dev* will be moved from `TraktApiSharp.PreNextVersion.Tests` to `TraktApiSharp.Tests` on branch *next-version* and converted to XUnit

---

### **Differences between the branches dev and next-version**
The next major release (version 1.0.0, tracked by the branch *next-version*) introduces a new request and response system, which is not compatible to the old system used in the versions below 1.0.0 (tracked by the branch *dev*). Therefore all existing and newly added requests and responses on the branch *dev* need to be converted to the new system on the branch *next-version*. There is a first preview of the new system, which you can find [here](https://github.com/henrikfroehling/TraktApiSharp/wiki/00-Prereleases). The first alpha release is available [here](https://github.com/henrikfroehling/TraktApiSharp/releases/tag/v1.0.0-alpha1).
