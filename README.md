TraktApiSharp
===
##### This is a C# wrapper library for the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#).

## Status

The library **is not yet ready for production use**.

There are still some features missing and already implemented features are not yet completely tested.
The goal is a feature-complete library in terms of API coverage.

**Future releases will be available as NuGet packages.**


## Basic Usage

**Create a new TraktApiSharp Client.**
```csharp
var client = new TraktClient("Your Client ID");  // Client ID is sufficient for usage without OAuth
var client = new TraktClient("Your Client ID", "Your Client Secret");  // Both parameters are required,
                                                                       // if you want to use OAuth required features
```

**Configure the client.**
```csharp
client.ClientId = "Your Client ID";
client.ClientSecret = "Your Client Secret";

client.Configuration.ApiVersion = 2; // Set by default
client.Configuration.AuthenticationMode = TraktAuthenticationMode.Device; // OAuth- or Device-Authentication
                                                                          // Default is Device-Authentication
```

**Get the Top 10 trending shows.**
```csharp
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(TraktExtendedOption.FullAndImages, null, 10);
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(TraktExtendedOption.FullAndImages, 1, 10);
```

**Get the Top 10 trending movies.**
```csharp
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(TraktExtendedOption.FullAndImages, null, 10);
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(TraktExtendedOption.FullAndImages, 1, 10);
```

**All data retrieving methods are asynchronous.**

---
**TraktApiSharp is open source and licensed under the [MIT License](https://opensource.org/licenses/MIT).**

**Copyright (c) 2016 Henrik Fröhling**
