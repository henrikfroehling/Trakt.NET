![](https://raw.githubusercontent.com/henrikfroehling/Trakt.NET/develop/.github/trending_movies_shows.gif)
*<sup>Example output (rendered in console with [Spectre.Console](https://github.com/spectresystems/spectre.console))</sup>*

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
- Authentication Support (OAuth 2.0 and Device)
- Completely asynchronous
- API Environments (Production and Sandbox)
- Serialization Service
- Language Service

### Supported Platforms

- .NET >= 5
- .NET Core >= 2.0
- .NET Framework >= 4.6.1
- .NET MAUI
- Xamarin.iOS >= 10.14
- Xamarin.Mac >= 3.8
- Xamarin.Android >= 8.0
- Windows UWP >= 10.0.16299
- Mono >= 5.4

---

### Installation

Install the latest release by running the following NuGet command

```ps
PM> Install-Package Trakt.NET
```

or with the [NuGet Package Management](https://docs.nuget.org/consume/package-manager-dialog) in Visual Studio and search for "trakt".

Each release will also be published in [Releases](https://github.com/henrikfroehling/Trakt.NET/releases).

---

### Discussions and Issues
Do you have a question or suggestion? [Start a discussion](https://github.com/henrikfroehling/Trakt.NET/discussions)

Or do you want to report a bug? [Create an issue](https://github.com/henrikfroehling/Trakt.NET/issues/new/choose)

### Contributions are welcome
Do want to contribute? [See how you can contribute](https://github.com/henrikfroehling/Trakt.NET/blob/develop/CONTRIBUTING.md)

### [Documentation](https://github.com/henrikfroehling/Trakt.NET/tree/develop/docs/Library_API_Documentation#library-api-documentation)

---
### Examples
    
Examples can be found here: https://github.com/henrikfroehling/Trakt.NET/tree/develop/Examples

---
<details>
<summary>Basic Usage</summary>

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
</details>

---
### License

```text
The MIT License (MIT)

Copyright © 2016 - 2023 Henrik Fröhling et al.

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
