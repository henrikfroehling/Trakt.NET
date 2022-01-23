## Installation

The recommended way to install TraktApiSharp is to use NuGet, but you can also directly link to a **Trakt.NET.dll** file or build the library from source code.

### NuGet

Navigate to your project’s directory and install Trakt.NET with NuGet command line: `Install-Package Trakt.NET`. Or open your project / solution in Visual Studio and use the [Visual Studio Package Management](https://docs.nuget.org/consume/package-manager-dialog) and search for `trakt`.

### Build from Source

The library can be built inside of Visual Studio or Visual Studio Code. You need at least Visual Studio 2017 with C# 7 support. The ZIP Archive of any specific version contains the source code of the library or you clone the repository.

To actually build the library, open the `Trakt.NET.sln` in Visual Studio and build the project `Trakt.NET`. This solution `Trakt.NET.sln` also contains all test projects. If you just want to build the library, you can open the solution `Trakt.NET_WithoutTestProjects.slnf` alternavely, which only opens the library project itself. After the build was successful, you can find the library DLL in the directory `Build\Lib\[Debug|Release]`.
