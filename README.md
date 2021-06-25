![](https://raw.githubusercontent.com/henrikfroehling/Trakt.NET/develop/.github/trending_movies_shows.gif)
*<sup>Example output (rendered in console with [Spectre.Console](https://github.com/spectresystems/spectre.console))</sup>*

[Trakt.NET](https://github.com/henrikfroehling/Trakt.NET)
[![Twitter URL](https://img.shields.io/twitter/url?style=social&url=https%3A%2F%2Fgithub.com%2Fhenrikfroehling%2FTrakt.NET)](https://twitter.com/intent/tweet?url=https%3A%2F%2Fgithub.com%2Fhenrikfroehling%2FTrakt.NET&hashtags=Trakt,Nuget,CSharp)
[![Twitter Follow](https://img.shields.io/twitter/follow/henrikfroehling?style=social)](https://twitter.com/henrikfroehling)
===

_**Formerly known as [TraktApiSharp](https://github.com/henrikfroehling/TraktApiSharp).**_

**This is a .NET wrapper library for the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#).**

[![Project Status](https://img.shields.io/badge/Project%20Status-In%20Development-green)](https://img.shields.io/badge/Project%20Status-In%20Development-green)
[![NuGet Package](https://img.shields.io/badge/NuGet-v1.1.1-green.svg?style=flat)](https://www.nuget.org/packages/Trakt.NET/1.1.1)
[![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=henrikfroehling_Trakt.NET&metric=alert_status)](https://sonarcloud.io/dashboard?id=henrikfroehling_Trakt.NET)

### Installation

Install the latest release by running the following NuGet command

```ps
PM> Install-Package Trakt.NET
```

or with the [NuGet Package Management](https://docs.nuget.org/consume/package-manager-dialog) in Visual Studio and search for "trakt".

Each release will also be published in [Releases](https://github.com/henrikfroehling/Trakt.NET/releases).

### Features

Full Trakt.tv API Coverage // Authentication Support (OAuth 2.0 and Device) // Completely asynchronous // API Environments (Production and Sandbox) // Serialization Service // Language Service

### Supported Platforms

.Net Core >= 1.0 // .Net Framework >= 4.5 // .NET >= 5 // Mono >= 4.6 // Xamarin.iOS >= 10.0 // Xamarin.Mac >= 3.0 // Xamarin.Android >= 7.0 // Windows UWP >= 10.0 // Windows >= 8.0 // Windows Phone >= 8.1

---
### Discussions and Issues
Do you have a question or suggestion? [Start a discussion](https://github.com/henrikfroehling/Trakt.NET/discussions)

Or do you want to report a bug? [Create an issue](https://github.com/henrikfroehling/Trakt.NET/issues/new/choose)

### Contributions are welcome
Do want to contribute? [See how you can contribute](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md)

### [Documentation](https://github.com/henrikfroehling/Trakt.NET/wiki)

### Build Status

| Branch | Status | Description | Packages |
|---|---|---|---|
| [develop](https://github.com/henrikfroehling/Trakt.NET/tree/develop) | [![Build status](https://dev.azure.com/henrikfroehling/Trakt.NET/_apis/build/status/Trakt.NET-CI-Developer-Preview)](https://dev.azure.com/henrikfroehling/Trakt.NET/_build/latest?definitionId=5) | This branch tracks the current and possibly unstable development. | https://github.com/henrikfroehling/Trakt.NET/packages |

---

### Basic Usage

**Create a new [Trakt.NET](https://github.com/henrikfroehling/Trakt.NET) Client**

```csharp
// Client ID is sufficient for usage without OAuth
var client = new TraktClient("Your Trakt Client ID");

// Both Client ID and Client Secret are required, if you need to authenticate your application
var client = new TraktClient("Your Trakt Client ID", "Your Trakt Client Secret");

// Both Client ID and Access Token are required, if you want to use requests, that require authorization
var client = new TraktClient("Your Trakt Client ID")
{
    Authorization = TraktAuthorization.CreateWith("Trakt Access Token")
};
```

**Use your existing tokens**

```csharp
var client = new TraktClient("Your Trakt Client ID");

// Only access token
client.Authorization = TraktAuthorization.CreateWith("Your Access Token");

// Access Token and Refresh Token
client.Authorization = TraktAuthorization.CreateWith("Your Access Token", "Your Refresh Token");
```

**Serialize and deserialize authorization information**

```csharp
ITraktAuthorization authorization = client.Authorization;

// Get JSON string from current authorization
string json = await TraktSerializationService.SerializeAsync(authorization);

// Get TraktAuthorization from JSON string
ITraktAuthorization deserializedAuthorization = await TraktSerializationService.DeserializeAsync(json);

client.Authorization = deserializedAuthorization;

// authorization == deserializedAuthorization
```

**Configure the client**

```csharp
client.ClientId = "Your Trakt Client ID";
client.ClientSecret = "Your Trakt Client Secret";

client.Configuration.ApiVersion = 2; // Set by default

// Set this to true, to use Trakt API staging environment
// This is disabled by default
client.Configuration.UseSandboxEnvironment = true;

// Force authorization for requests, where authorization is optional
// This is disabled by default
client.Configuration.ForceAuthorization = true;
```

**Get the top 10 trending shows including full information**

```csharp
TraktPagedResponse<ITraktTrendingShow> trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo().SetFull(), null, 10);
// or
TraktPagedResponse<ITraktTrendingShow> trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo() { Full = true }, 1, 10);

if (trendingShowsTop10)
{
    foreach (ITraktTrendingShow trendingShow in trendingShowsTop10)
    {
        Console.WriteLine($"Show: {trendingShow.Title} / Watchers: {trendingShow.Watchers}");
    }
}
```
![](https://raw.githubusercontent.com/henrikfroehling/Trakt.NET/develop/.github/trakt_trending_shows.png)
*<sup>Example output (rendered in console with [Spectre.Console](https://github.com/spectresystems/spectre.console))</sup>*

---
**Get the top 10 trending movies including full information**

```csharp
var extendedInfo = new TraktExtendedInfo() { Full = true };

TraktPagedResponse<ITraktTrendingMovie> trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedInfo, null, 10);
// or
TraktPagedResponse<ITraktTrendingMovie> trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedInfo, 1, 10);

if (trendingMoviesTop10)
{
    foreach (ITraktTrendingMovie trendingMovie in trendingMoviesTop10)
    {
        Console.WriteLine($"Movie: {trendingMovie.Title} / Watchers: {trendingMovie.Watchers}");
    }
}
```
![](https://raw.githubusercontent.com/henrikfroehling/Trakt.NET/develop/.github/trakt_trending_movies.png)
*<sup>Example output (rendered in console with [Spectre.Console](https://github.com/spectresystems/spectre.console))</sup>*

---
**Get the show 'Game of Thrones'**

```csharp
TraktResponse<ITraktShow> gameOfThrones = await client.Shows.GetShowAsync("game-of-thrones", new TraktExtendedInfo().SetFull());

if (gameOfThrones)
{
    ITraktShow show = gameOfThrones.Value;
    Console.WriteLine($"Title: {show.Title} / Year: {show.Year}");
    Console.WriteLine(show.Overview);
}
```

**Get the movie 'The Martian'**

```csharp
TraktResponse<ITraktMovie> theMartian = await client.Movies.GetMovieAsync("the-martian-2015", new TraktExtendedInfo().SetFull());

if (theMartian)
{
    ITraktMovie movie = theMartian.Value;
    Console.WriteLine($"Title: {movie.Title} / Year: {movie.Year}");
    Console.WriteLine(show.Overview);
}
```

---
### License

```text
The MIT License (MIT)

Copyright © 2016 - 2021 Henrik Fröhling et al.

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
