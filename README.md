TraktApiSharp
===
##### This is a C# wrapper library for the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#).
---
[![NuGet Package](https://img.shields.io/badge/NuGet-v0.4.0-brightgreen.svg?style=flat)](https://www.nuget.org/packages/TraktApiSharp)
[![License](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT)
[![Build status branch master](https://ci.appveyor.com/api/projects/status/03n3og01n67yef7n/branch/master?svg=true&passingText=master%20-%20passing&pendingText=master%20-%20pending&failingText=master%20-%20failing)](https://ci.appveyor.com/project/henrikfroehling/traktapisharp/branch/master)
[![Build status branch dev](https://ci.appveyor.com/api/projects/status/03n3og01n67yef7n/branch/dev?svg=true&passingText=dev%20-%20passing&pendingText=dev%20-%20pending&failingText=dev%20-%20failing)](https://ci.appveyor.com/project/henrikfroehling/traktapisharp/branch/dev)
[![Zenhub Support](https://raw.githubusercontent.com/ZenHubIO/support/master/zenhub-badge.png)](https://www.zenhub.com/)

[![Gitter](https://badges.gitter.im/traktapisharp/Lobby.svg)](https://gitter.im/traktapisharp/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

![Platforms](https://img.shields.io/badge/Platforms-%20.Net%20%3E=%204.5%20%7C%20ASP.Net%20Core%201.0%20%7C%20Win%208%20%7C%20Win%208.1%20%7C%20Win%2010%20%7C%20Win%2010%20UWP%20%7C%20Win%20Phone%208.1%20%7C%20Xamarin%20Android%20%7C%20Xamarin%20iOS%20-orange.svg)

### Features
- Full Trakt.tv API Coverage
- OAuth Authentication Support
- Device Authentication Support
- Completely asynchronous

### Supported Platforms
- .Net Framework 4.5
- ASP.NET Core 1.0
- Windows 8 / 8.1 / 10 UWP
- Windows Phone 8.1
- Xamarin Android
- Xamarin iOS

---
#### [Report a bug](https://github.com/henrikfroehling/TraktApiSharp/issues)
#### [Ask a question](https://gitter.im/traktapisharp/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

---
### Where to get
- Available on [Nuget.org](https://www.nuget.org/packages/TraktApiSharp)
- Each release will also be published [here](https://github.com/henrikfroehling/TraktApiSharp/releases).
```
PM> Install-Package TraktApiSharp
```

---
### Build Requirements
- Visual Studio with C# 6 compliant compiler
- .Net Framework 4.5

---
### Basic Usage
**Create a new TraktApiSharp Client.**
```csharp
// Client ID is sufficient for usage without OAuth
var client = new TraktClient("Your Trakt Client ID");

// Both Client ID and Client Secret are required, if you need to authenticate your application
var client = new TraktClient("Your Trakt Client ID", "Your Trakt Client Secret");

// Both Client ID and Access Token are required, if you want to use requests, that require authorization
var client = new TraktClient("Your Trakt Client ID") { AccessToken = "Trakt Access Token" };
```

**Configure the client.**
```csharp
client.ClientId = "Your Trakt Client ID";
client.ClientSecret = "Your Trakt Client Secret";
client.AccessToken = "Trakt Access Token";

client.Configuration.ApiVersion = 2; // Set by default

// Set this to true, to use Trakt API staging environment
// This is disabled by default
client.Configuration.UseStagingUrl = true;

// Force authorization for requests, where authorization is optional
// This is disabled by default
client.Configuration.ForceAuthorization = true;
```

**Get the top 10 trending shows including full information and images.**
```csharp
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedOption().SetFull().SetImages(), null, 10);
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedOption() { Full = true, Images = true }, 1, 10);

foreach (var trendingShow in trendingShowsTop10)
{
    var show = trendingShow.Show;
    Console.WriteLine($"Show: {show.Title} / Watchers: {trendingShow.Watchers}");
}
```

**Get the top 10 trending movies including full information and images.**
```csharp
var extendedOption = new TraktExtendedOption() { Full = true, Images = true };
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedOption, null, 10);
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedOption, 1, 10);

foreach (var trendingMovie in trendingMoviesTop10)
{
    var movie = trendingMovie.Show;
    Console.WriteLine($"Movie: {movie.Title} / Watchers: {trendingMovie.Watchers}");
}
```

**Get the show 'Game of Thrones'**
```csharp
var gameOfThrones = await client.Shows.GetShowAsync("game-of-thrones", new TraktExtendedOption().SetFull().SetImages());

Console.WriteLine($"Title: {gameOfThrones.Title} / Year: {gameOfThrones.Year}");
Console.WriteLine(gameOfThrones.Overview);

// Get the path to the poster image in full resolution
var imagePath = gameOfThrones.Images.Poster.Full;
```

**Get the movie 'The Martian'**
```csharp
var theMartian = await client.Movies.GetMovieAsync("the-martian-2015", new TraktExtendedOption().SetFull().SetImages());

Console.WriteLine($"Title: {theMartian.Title} / Year: {theMartian.Year}");
Console.WriteLine(theMartian.Overview);

// Get the path to the poster image in full resolution
var imagePath = theMartian.Images.Poster.Full;
```

---
### License
```
The MIT License (MIT)

Copyright (c) 2016 Henrik Fröhling

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

**Copyright (c) 2016 [Henrik Fröhling](mailto:support@traktapisharp.net)**
