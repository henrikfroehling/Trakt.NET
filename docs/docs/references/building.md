# Build from Source

## Prerequisites

Install Visual Studio 2022 (Community or higher) or Visual Studio Code and make sure you have the latest updates.

## Build

To clone and build it locally run the following git commands:
```
> git clone https://github.com/henrikfroehling/Trakt.NET.git
> cd Trakt.NET
```

### Complete Solution (including tests)

Run following commands in the projects root directory to build the complete solution:
```
> dotnet restore Source/Trakt.NET.sln
> dotnet build Source/Trakt.NET.sln -c [Debug|Release] --no-restore /m /p:BuildInParallel=true
```

Running the tests:
```
> dotnet test Source/Trakt.NET.sln -c [Debug|Release] --no-build --no-restore
```

Alternatively you can also open the solution `<PROJECT_ROOT>/Source/Trakt.NET.sln` in Visual Studio or Visual Studio Code.

### Only Library itself (without any tests, etc.)

Run following commands in the projects root directory to build only the library itself:
```
> dotnet restore Source/Lib/Trakt.NET/Trakt.NET.csproj
> dotnet build Source/Lib/Trakt.NET/Trakt.NET.csproj -c [Debug|Release] --no-restore
```

Alternatively you can also open the solution filter `<PROJECT_ROOT>/Source/Trakt.NET_OnlyLibraryProject.slnf` in Visual Studio or Visual Studio Code.

Either way, after building the library, you can find the binaries in `<PROJECT_ROOT>/Build/Lib/[Debug|Release]/netstandard2.0`.
