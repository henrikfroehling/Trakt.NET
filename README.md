Trakt.NET
===

[![NuGet Package](https://img.shields.io/badge/Latest%20Version%20on%20NuGet-v1.3.0-blue.svg?style=flat)](https://www.nuget.org/packages/Trakt.NET/1.3.0)

[![Project Status](https://img.shields.io/badge/Project%20Status-In%20Development-blue.svg?style=flat)](https://img.shields.io/badge/Project%20Status-In%20Development-green)
[![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT)
[![PRs Welcome](https://img.shields.io/badge/Pull%20Requests-Welcome-blue.svg?style=flat)](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md)

[![Development CI-Build](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/develop-CI.yml/badge.svg)](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/develop-CI.yml)
[![Release CI-Build](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/release-CI.yml/badge.svg)](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/release-CI.yml)

[![Code Scan](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/code-scan.yml/badge.svg)](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/code-scan.yml)
[![Static Analysis](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/sonarcloud.yml/badge.svg)](https://github.com/henrikfroehling/Trakt.NET/actions/workflows/sonarcloud.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=henrikfroehling_Trakt.NET&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=henrikfroehling_Trakt.NET)
[![codecov](https://codecov.io/gh/henrikfroehling/Trakt.NET/branch/develop/graph/badge.svg?token=U2B0KXA0QC)](https://codecov.io/gh/henrikfroehling/Trakt.NET)

### Overview

This is a .NET wrapper library with which developers can build .NET applications that integrate with the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#) and access its features and data.

Some examples that Trakt.NET can be used for include:
- Retrieve information about movies and TV shows, including details such as titles, descriptions, ratings and release dates
- Tracking what TV shows and movies a user is watching, has watched or wants to watch
- Providing recommendations for TV shows and movies based on a user's watch history
- Building custom TV show and movie lists

To use Trakt.NET, you will need to obtain an API key from Trakt and follow the guidelines for using the API.

### Features

- Full Trakt.tv API Coverage
- Authentication and Authorization Support (OAuth 2.0 and Device)
- Completely asynchronous
- API Environments (Production and Sandbox)
- Serialization Service

### Supported Platforms

|     |     |     |     |
|:---:|:---:|:---:|:---:|
| .NET >= 5 | .NET MAUI | .NET Framework >= 4.6.1 | .NET Core >= 2.0 |
| Xamarin.Android >= 8.0 | Xamarin.iOS >= 10.14 | Xamarin.Mac >= 3.8 |
| Windows UWP >= 10.0.16299 | Mono >= 5.4 |

### Quickstart

```
> dotnet add package Trakt.NET
```

```csharp
using System;
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;
using TraktNet.Services;

var client = new TraktClient("Your Trakt Client ID");

try
{
    TraktResponse<ITraktShow> showResponse = await client.Shows.GetShowAsync("the-last-of-us");
    ITraktShow show = showResponse.Value;
    
    Console.WriteLine($"Title: {show.Title}");
    Console.WriteLine($"Year: {show.Year}");
    Console.WriteLine();

    string json = await TraktSerializationService.SerializeAsync(show);
    Console.WriteLine(json);
}
catch (TraktException ex)
{
    Console.WriteLine(ex);
}
```

Output:
```
Title: The Last of Us
Year: 2023
```
```json
{"title":"The Last of Us","year":2023,"ids":{"trakt":158947,"slug":"the-last-of-us","tvdb":392256,"imdb":"tt3581920","tmdb":100088}}
```

### Documentation

https://henrikfroehling.github.io/Trakt.NET/docs/index.html

### Examples

https://henrikfroehling.github.io/Trakt.NET/examples/index.html

### Discussions and Issues
Do you have a question or suggestion? [Start a discussion](https://github.com/henrikfroehling/Trakt.NET/discussions)

Or do you want to report a bug? [Create an issue](https://github.com/henrikfroehling/Trakt.NET/issues/new/choose)

### Contributions are welcome
Do want to contribute? [See how you can contribute](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md)

### License

```text
The MIT License (MIT)

Copyright © 2016 - Current Henrik Fröhling et al.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
