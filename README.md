TraktApiSharp
===
##### This is a C# wrapper library for the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#).

## Status

The current library version is a release candidate.

All library versions are available as NuGet packages under the [Release](https://github.com/henrikfroehling/TraktApiSharp/releases) tab or at [Nuget.org](https://www.nuget.org/packages/TraktApiSharp).


## NuGet
```
Install-Package TraktApiSharp -Pre
```


## Basic Usage

**Create a new TraktApiSharp Client.**
```csharp
// Client ID is sufficient for usage without OAuth
var client = new TraktClient("Your Trakt Client ID");

// Both Client ID and Client Secret are required, if you need to authenticate your application
var client = new TraktClient("Your Trakt Client ID", "Your Trakt Client Secret");

// Both Client ID and Access Token are required, if you want to use requests, that require authorization
var client = new TraktClient("Your Trakt Client ID") { AccessToken = "Your Trakt Access Token" };
```

**Configure the client.**
```csharp
client.ClientId = "Your Trakt Client ID";
client.ClientSecret = "Your Trakt Client Secret";
client.AccessToken = "Your Trakt Access Token";

client.Configuration.ApiVersion = 2; // Set by default

// Set this to true, to use Trakt API staging environment
// Set to false by default
client.Configuration.UseStagingUrl = true;
```

**Get the Top 10 trending shows.**
```csharp
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedOption().SetFull().SetImages(), null, 10);
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedOption() { Full = true, Images = true }, 1, 10);

foreach (var trendingShow in trendingShowsTop10.Items)
{
    var show = trendingShow.Show;
    Console.WriteLine($"Show: {show.Title} / Watchers: {trendingShow.Watchers}");
}
```

**Get the Top 10 trending movies.**
```csharp
var extendedOption = new TraktExtendedOption() { Full = true, Images = true };
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedOption, null, 10);
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedOption, 1, 10);

foreach (var trendingMovie in trendingMoviesTop10.Items)
{
    var movie = trendingMovie.Show;
    Console.WriteLine($"Movie: {movie.Title} / Watchers: {trendingMovie.Watchers}");
}
```

**All data retrieving methods are asynchronous.**

---
**TraktApiSharp is open source and licensed under the [MIT License](https://opensource.org/licenses/MIT).**

**Copyright (c) 2016 Henrik Fröhling**
