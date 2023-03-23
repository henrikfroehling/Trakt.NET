# Trakt.NET

[![NuGet Package](https://img.shields.io/badge/Latest%20Version%20on%20NuGet-v1.3.0-blue.svg?style=flat)](https://www.nuget.org/packages/Trakt.NET/1.3.0) [![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT) 

[![GitHub Repo stars](https://img.shields.io/github/stars/henrikfroehling/Trakt.NET?style=social)](https://github.com/henrikfroehling/Trakt.NET) [![GitHub issues](https://img.shields.io/github/issues/henrikfroehling/Trakt.NET)](https://github.com/henrikfroehling/Trakt.NET/issues) [![GitHub Discussions](https://img.shields.io/github/discussions/henrikfroehling/Trakt.NET)](https://github.com/henrikfroehling/Trakt.NET/discussions)

#### Overview

This is a .NET wrapper library with which developers can build .NET applications that integrate with the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#) and access its features and data.

Some examples that Trakt.NET can be used for include:
- Retrieve information about movies and TV shows, including details such as titles, descriptions, ratings and release dates
- Tracking what TV shows and movies a user is watching, has watched or wants to watch
- Providing recommendations for TV shows and movies based on a user's watch history
- Building custom TV show and movie lists

To use Trakt.NET, you will need to obtain an API key from Trakt and follow the guidelines for using the API.

#### Features
- Full Trakt.tv API Coverage
- Authentication and Authorization Support (OAuth 2.0 and Device)
- Completely asynchronous
- API Environments (Production and Sandbox)
- Serialization Service
- Language Service

#### Supported Platforms
- .NET >= 5
- .NET Core >= 2.0
- .NET Framework >= 4.6.1
- .NET MAUI
- Xamarin.iOS >= 10.14
- Xamarin.Mac >= 3.8
- Xamarin.Android >= 8.0
- Windows UWP >= 10.0.16299
- Mono >= 5.4

#### Quickstart

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

{"title":"The Last of Us","year":2023,"ids":{"trakt":158947,"slug":"the-last-of-us","tvdb":392256,"imdb":"tt3581920","tmdb":100088}}
```
