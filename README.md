TraktApiSharp
===
##### This is a C# wrapper library for the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#).

## Status

The library **has currently beta status**.

The library is feature-complete in terms of API coverage, but there are features, that are not completely tested.

Following modules are not completely tested and can contain bugs:
- Authentication Module
- Comments Module
- People Module
- Recommendations Module
- Scrobble Module
- Search Module
- Sync Module
- Users Module

Alpha and beta versions are available as NuGet packages under the [Release](https://github.com/henrikfroehling/TraktApiSharp/releases) tab.


## NuGet
```
Install-Package TraktApiSharp -Pre
```


## Basic Usage

**Create a new TraktApiSharp Client.**
```csharp
var client = new TraktClient("Your Trakt Client ID");  // Client ID is sufficient for usage without OAuth
var client = new TraktClient("Your Trakt Client ID", "Your Trakt Client Secret");  // Both parameters are required,
                                                                                   // if you want to use OAuth required features
```

**Configure the client.**
```csharp
client.ClientId = "Your Trakt Client ID";
client.ClientSecret = "Your Trakt Client Secret";

client.Configuration.ApiVersion = 2; // Set by default
client.Configuration.AuthenticationMode = TraktAuthenticationMode.Device; // OAuth- or Device-Authentication
                                                                          // Default is Device-Authentication
```

**Get the Top 10 trending shows.**
```csharp
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedOption().SetFull().SetImages(), null, 10);
var trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedOption() { Full = true, Images = true }, 1, 10);
```

**Get the Top 10 trending movies.**
```csharp
var extendedOption = new TraktExtendedOption() { Full = true, Images = true };
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedOption, null, 10);
var trendingMoviesTop10 = await client.Movies.GetTrendingMoviesAsync(extendedOption, 1, 10);
```

**All data retrieving methods are asynchronous.**

---
**TraktApiSharp is open source and licensed under the [MIT License](https://opensource.org/licenses/MIT).**

**Copyright (c) 2016 Henrik Fröhling**
