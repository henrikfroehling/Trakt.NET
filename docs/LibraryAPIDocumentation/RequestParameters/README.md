## Request Parameters

Many methods in the [modules](https://github.com/henrikfroehling/Trakt.NET/wiki/10-Modules) accept [extended info](https://github.com/henrikfroehling/Trakt.NET/wiki/11-Request-Parameters#extended-info) specifications, [filters](https://github.com/henrikfroehling/Trakt.NET/wiki/11-Request-Parameters#filters) and / or collections with [multiple object ids](https://github.com/henrikfroehling/Trakt.NET/wiki/11-Request-Parameters#multiple-ids).

### Extended Info

A `TraktExtendedInfo` instance can be created to specify, how much data should be retrieved for a request. It is possible to create just one instance of it and use it for each request or to create a new instance of it for every new request.

To create an instance of `TraktExtendedInfo`, there are basically two ways.

```csharp
using TraktNet.Requests.Parameters;

var extendedInfo = new TraktExtendedInfo
{
    Full = true
};

// or

var extendedInfo = new TraktExtendedInfo().SetFull();
```

`TraktExtendedInfo` has several options you can set and also reset.

| Option | Set | Reset | Limitations |
|--------|-----|-------|-------------|
| Metadata | `SetMetadata()` or `Metadata = true` | `ResetMetadata()` or `Metadata = false` | Works only with `TraktClient.Sync.GetCollectionMoviesAsync()`, `TraktClient.Sync.GetCollectionShowsAsync()`, `TraktClient.Users.GetCollectionMoviesAsync()` and `TraktClient.Users.GetCollectionShowsAsync()`. Will be ignored otherwise. |
| Full | `SetFull()` or `Full = true` | `ResetFull()` or `Full = false` | None |
| NoSeasons | `SetNoSeasons()` or `NoSeasons = true` | `ResetNoSeasons()` or `NoSeasons = false` | Works only with `TraktClient.Sync.GetWatchedShowsAsync()` and `TraktClient.Users.GetWatchedShowsAsync()`. Will be ignored otherwise. |
| Episodes | `SetEpisodes()` or `Episodes = true` | `ResetEpisodes()` or `Episodes = false` | Works only with `TraktClient.Seasons.GetAllSeasonsAsync()`. Will be ignored otherwise. |
| GuestStars | `SetGuestStars()` or `GuestStars = true` | `ResetGuestStars()` or `GuestStars = false` | Works only with `TraktClient.Shows.GetShowPeopleAsync()`, `TraktClient.Seasons.GetSeasonPeopleAsync()` and `TraktClient.Episodes.GetEpisodePeopleAsync()`. Will be ignored otherwise. |

With `Reset[Option]()` you can disable a single option and with `Reset()` you can disable all options.

`TraktExtendedInfo` has a fluent interface which allows you to chain its method calls like in the following example.

```csharp
using TraktNet.Requests.Parameters;

var extendedInfo = new TraktExtendedInfo().SetMetadata().SetFull().SetNoSeasons().SetEpisodes().Reset().SetNoSeasons().Reset();
```

### Filters

There are four different filters you can use.

- `TraktCalendarFilter` for all methods in the `TraktClient.Calendars`
- `TraktMovieFilter` for some methods in the `TraktClient.Movies`
- `TraktShowFilter` for some methods in the `TraktClient.Shows`
- `TraktSearchModule` for the `GetTextQueryResultsAsync()` method in the `TraktClient.Search`

Each filter has a fluent interface which allows you to chain its method calls. For example, create a `TraktCalendarFilter` instance like this.

```csharp
using TraktNet.Requests.Parameters.Filter;

var filter = new TraktCalendarFilter().WithQuery("calendar movie")
                                      .WithYears(2016)
                                      .WithGenres("drama", "fantasy")
                                      .WithLanguages("en", "de")
                                      .WithCountries("us")
                                      .WithRuntimes(30, 60)
                                      .WithRatings(80, 95);
```

And edit it like this.

```csharp
filter.AddGenres("action", "science-fiction")
      .AddLanguages("fr");
```

All methods, which begin with `With...` will overwrite existing values. If you want to add values, you must use a method, which begins with `Add...`. With `Clear()` you can remove all current values in a filter.

### Multiple Ids

The methods `TraktClient.Movies.GetMultipleMoviesAsync()`, `TraktClient.Shows.GetMultipleShowsAsync()`, `TraktClient.Seasons.GetMultipleSeasonsAsync()`, `TraktClient.Episodes.GetMultipleEpisodesAsync()`, `TraktClient.People.GetMultiplePersonsAsync()` and `TraktClient.Users.GetMultipleCustomListsAsync()` require each a collection of mutliple ids of objects, which you want to retrieve, as an argument.

| Method | Collection |
|--------|------------|
| `TraktClient.Movies.GetMultipleMoviesAsync()` | `TraktMultipleObjectsQueryParams` |
| `TraktClient.Shows.GetMultipleShowsAsync()` | `TraktMultipleObjectsQueryParams` |
| `TraktClient.Seasons.GetMultipleSeasonsAsync()` | `TraktMultipleSeasonsQueryParams` |
| `TraktClient.Episodes.GetMultipleEpisodesAsync()` | `TraktMultipleEpisodesQueryParams` |
| `TraktClient.People.GetMultiplePersonsAsync()` | `TraktMultipleObjectsQueryParams` |
| `TraktClient.Users.GetMultipleCustomListsAsync()` | `TraktMultipleUserListsQueryParams` |

#### `TraktMultipleObjectsQueryParams`

```csharp
using TraktNet.Modules;

var queryParams = new TraktMultipleObjectsQueryParams
{
    // { id[, extended info] }
    "id-1",
    { "id-2", new TraktExtendedInfo { Full = true } },
    "id-3"
};

// or

var queryParams = new TraktMultipleObjectsQueryParams();

queryParams.Add("id-1");
queryParams.Add("id-2", new TraktExtendedInfo { Full = true });
queryParams.Add("id-3");
```

#### `TraktMultipleSeasonsQueryParams`

```csharp
using TraktNet.Modules;

var queryParams = new TraktMultipleSeasonsQueryParams
{
    // { show-id, seasonnumber[, extended info] }
    { "show-id-1", 1 },
    { "show-id-2", 3, new TraktExtendedInfo { Full = true } },
    { "show-id-3", 2 }
};

// or

var queryParams = new TraktMultipleSeasonsQueryParams();

queryParams.Add("show-id-1", 1);
queryParams.Add("show-id-2", 3, new TraktExtendedInfo { Full = true });
queryParams.Add("show-id-3", 2);
```

#### `TraktMultipleEpisodesQueryParams`

```csharp
using TraktNet.Modules;

var queryParams = new TraktMultipleEpisodesQueryParams
{
    // { show-id, seasonnumber, episodenumber[, extended info] }
    { "show-id-1", 1, 1 },
    { "show-id-2", 3, 5, new TraktExtendedInfo { Full = true } },
    { "show-id-3", 2, 1 }
};

// or

var queryParams = new TraktMultipleEpisodesQueryParams();

queryParams.Add("show-id-1", 1, 1);
queryParams.Add("show-id-2", 3, 5, new TraktExtendedInfo { Full = true });
queryParams.Add("show-id-3", 2, 1);
```

#### `TraktMultipleUserListsQueryParams`

```csharp
using TraktNet.Modules;

var queryParams = new TraktMultipleUserListsQueryParams
{
    // { username, list-id }
    { "username-1", "list-id-1" },
    { "username-2", "list-id-3" },
    { "username-3", "list-id-5" }
};

// or

var queryParams = new TraktMultipleUserListsQueryParams();

queryParams.Add("username-1", "list-id-1");
queryParams.Add("username-2", "list-id-3");
queryParams.Add("username-3", "list-id-5");
```

### Post Objects (Post Builder)

TODO
