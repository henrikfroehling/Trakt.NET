# Build from Source

## Prerequisites

Install Visual Studio 2022 (Community or higher) or Visual Studio Code and make sure you have the latest updates.

## Clone

To clone and build it locally run the following git commands:
```
> git clone https://github.com/henrikfroehling/Trakt.NET.git
> cd Trakt.NET
```

## Build

Run following commands in the projects root directory to build the complete solution:
```ps
dotnet build Source/Trakt.NET.sln -c [Debug|Release]
```

Running the tests:
```ps
dotnet test Source/Trakt.NET.sln -c [Debug|Release] --no-build --no-restore
```

Alternatively you can also open the solution `<PROJECT_ROOT>/Source/Trakt.NET.sln` in Visual Studio.
