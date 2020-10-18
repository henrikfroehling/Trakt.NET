Contributing Guidelines
===

### **First off, thank you for considering contributing to** [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET)**.**

[Trakt.NET](https://github.com/henrikfroehling/Trakt.NET) is an open source project and there are many ways to contribute, from writing new examples or improving existing ones, improving the documentation, submitting bug reports and feature requests or writing code which can be incorporated into [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET).

**Please do not use the issue tracker for support questions.** If you have questions regarding on how to use the library, there is a [chat room on Gitter](https://gitter.im/Trakt-NET/Lobby) for that.

**Working on your first Pull Request?** You can learn how from this *free* series [How to Contribute to an Open Source Project on GitHub](https://egghead.io/series/how-to-contribute-to-an-open-source-project-on-github)

---

### **Getting started**
1. Create your own fork of the repository
2. Do the changes in your fork
   - Create a branch for the change with a descriptive name.
3. If you like your change, send a pull request
   - Be sure you have followed the [FAQ](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#faq)
   - Be sure you have followed the [General Requirements](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md#general-requirements)

---

### **Build Requirements**
- at least Visual Studio 2017 with support for C# 7.2

---

### **FAQ**
1. Q: Which branch should I target?
   A: By default you should target the branch `develop`. If you're working on an issue, usually the issue would have a label "target-branch", which states the branch to target for that specific issue.
2. Q: How do I trigger a CI-Build for my pull request?
   A: To trigger a CI-Build for you Pull Request branch, you should name your branch in the following pattern: "issue/{target-branch-name}/{your-branch-name}", e.g. "issue/develop/GH-105".

---

### **General Requirements**
- Do not make big surprise pull requests with a lot of changes and without an associating issue.
  - First, please open an issue to open a discussion, whether your changes do make an actual improvement.
- Pull requests that do not merge easily with the tip of the develop-branch will be declined. The author will be asked to merge with the tip of the targeted branch and update the pull request.
- Submissions must follow the rules stated in the [Coding Guidelines](https://github.com/henrikfroehling/Trakt.NET/blob/develop/coding_style.md).
- New features must have accompanying with "good" code coverage.
- Changes to existing functionality needs to be checked that it does not break any existing unit tests.

---

### **Cross-platform compatibility**
- [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET) is built against .NET Standard 1.1
