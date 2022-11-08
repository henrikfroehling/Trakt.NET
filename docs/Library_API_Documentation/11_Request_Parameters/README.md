## Request Parameters

Many methods in the [modules](https://github.com/henrikfroehling/Trakt.NET/wiki/10-Modules) accept [extended info](https://github.com/henrikfroehling/Trakt.NET/wiki/11-Request-Parameters#extended-info) specifications, [filters](https://github.com/henrikfroehling/Trakt.NET/wiki/11-Request-Parameters#filters) and / or collections with [multiple object ids](https://github.com/henrikfroehling/Trakt.NET/wiki/11-Request-Parameters#multiple-ids).

### Extended Info

A `TraktExtendedInfo` instance can be created to specify, how much data should be retrieved for a request. It is possible to create just one instance of it and use it for each request or to create a new instance of it for every new request.

To create an instance of `TraktExtendedInfo`, there are basically two ways.

```csharp
using TraktNet.Parameters;

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
using TraktNet.Parameters;

var extendedInfo = new TraktExtendedInfo().SetMetadata().SetFull().SetNoSeasons().SetEpisodes().Reset().SetNoSeasons().Reset();
```

### Filters

There are four different filters you can use.

- `ITraktCalendarFilter` for all methods in the `TraktClient.Calendars` module
- `ITraktMovieFilter` for some methods in the `TraktClient.Movies` module
- `ITraktShowFilter` for some methods in the `TraktClient.Shows` module
- `ITraktSearcFilter` for the `GetTextQueryResultsAsync()` method in the `TraktClient.Search` module

For each filter exists a builder to create an instance of it.

| Filter | Builder |
|--------|---------|
| `ITraktCalendarFilter` | `TraktFilter.NewCalendarFilter().Build()` |
| `ITraktMovieFilter` | `TraktFilter.NewMovieFilter().Build()` |
| `ITraktShowFilter` | `TraktFilter.NewShowFilter().Build()` |
| `ITraktSearchFilter` | `TraktFilter.NewSearchFilter().Build()` |

Each filter is immutable.

If you want to change one, just create a new instance.

Filters are only creatable through their builder methods.

In the following example, a `ITraktCalendarFilter` is created.

```csharp
using TraktNet.Parameters;

ITraktCalendarFilter calendarFilter = TraktFilter.NewCalenderFilter()
                                          .WithQuery("calendar movie")
                                          .WithYears(2020, 2022)
                                          .WithGenres("drama", "fantasy")
                                          .WithLanguages("en", "de")
                                          .WithCountries("us")
                                          .WithRuntimes(30, 60)
                                          .WithRatings(80, 95)
                                          .Build();
```

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

There are several methods which require a post object.
These are mostly required in the following modules:
- `TraktClient.Checkins` module
- `TraktClient.Comments` module
- `TraktClient.Scrobble` module
- `TraktClient.Sync` module
- `TraktClient.Users` module

Here is an overview of the post objects, its modules and its builder methods:
| Post Object | Module | Builder |
|-------------|--------|---------|
| `ITraktSyncCollectionPost` | `TraktClient.Sync` | `TraktPost.NewSyncCollectionPost().Build()` |
| `ITraktSyncCollectionRemovePost` | `TraktClient.Sync` | `TraktPost.NewSyncCollectionRemovePost().Build()` |
| `ITraktSyncHistoryPost` | `TraktClient.Sync` | `TraktPost.NewSyncHistoryPost().Build()` |
| `ITraktSyncHistoryRemovePost` | `TraktClient.Sync` | `TraktPost.NewSyncHistoryRemovePost().Build()` |
| `ITraktSyncRatingsPost` | `TraktClient.Sync` | `TraktPost.NewSyncRatingsPost().Build()` |
| `ITraktSyncRatingsRemovePost` | `TraktClient.Sync` | `TraktPost.NewSyncRatingsRemovePost().Build()` |
| `ITraktSyncRecommendationsPost` | `TraktClient.Sync` | `TraktPost.NewSyncRecommendationsPost().Build()` |
| `ITraktSyncRecommendationsRemovePost` | `TraktClient.Sync` | `TraktPost.NewSyncRecommendationsRemovePost().Build()` |
| `ITraktSyncWatchlistPost` | `TraktClient.Sync` | `TraktPost.NewSyncWatchlistPost().Build()` |
| `ITraktSyncWatchlistRemovePost` | `TraktClient.Sync` | `TraktPost.NewSyncWatchlistRemovePost().Build()` |
| `ITraktUserHiddenItemsPost` | `TraktClient.Users` | `TraktPost.NewUserHiddenItemsPost().Build()` |
| `ITraktUserHiddenItemsRemovePost` | `TraktClient.Users` | `TraktPost.NewUserHiddenItemsRemovePost().Build()` |
| `ITraktUserPersonalListItemsPost` | `TraktClient.Users` | `TraktPost.NewUserPersonalListItemsPost().Build()` |
| `ITraktUserPersonalListItemsRemovePost` | `TraktClient.Users` | `TraktPost.NewUserPersonalListItemsRemovePost().Build()` |
| `ITraktMovieCommentPost` | `TraktClient.Comments` | `TraktPost.NewMovieCommentPost().Build()` |
| `ITraktShowCommentPost` | `TraktClient.Comments` | `TraktPost.NewShowCommentPost().Build()` |
| `ITraktSeasonCommentPost` | `TraktClient.Comments` | `TraktPost.NewSeasonCommentPost().Build()` |
| `ITraktEpisodeCommentPost` | `TraktClient.Comments` | `TraktPost.NewEpisodeCommentPost().Build()` |
| `ITraktListCommentPost` | `TraktClient.Comments` | `TraktPost.NewListCommentPost().Build()` |
| `ITraktMovieCheckinPost` | `TraktClient.Checkins` | `TraktPost.NewMovieCheckinPost().Build()` |
| `ITraktEpisodeCheckinPost` | `TraktClient.Checkins` | `TraktPost.NewEpisodeCheckinPost().Build()` |
| `ITraktMovieScrobblePost` | `TraktClient.Scrobble` | `TraktPost.NewMovieScrobblePost().Build()` |
| `ITraktEpisodeScrobblePost` | `TraktClient.Scrobble` | `TraktPost.NewEpisodeScrobblePost().Build()` |

You do not need to use the builder methods for creating instances of post objects.

It is also possible to just create an instance, like this:
```csharp
ITraktSyncRecommendationsPost recommendationsPost = new TraktSyncRecommendationsPost();
```
But it is recommended to use the builder methods.

They check the added values for validity while creating an instance.

The following example creates an `ITraktSyncRecommendationsPost` instance which is required for the `AddPersonalRecommendationsAsync()` method in the `TraktClient.Sync` module.

```csharp
// Get shows and movies for this example.
TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync();
TraktPagedResponse<ITraktTrendingShow> trendingShows = await client.Shows.GetTrendingShowsAsync();

// Create the post object with the queried shows and movies.
ITraktSyncRecommendationsPost recommendationsPost = TraktPost.NewSyncRecommendationsPost()
                                                        .WithMovies(trendingMovies)
                                                        .WithShows(trendingShows)
                                                        .Build();

// Use the post object.
TraktResponse<ITraktSyncRecommendationsPostResponse> response = await client.Sync.AddPersonalRecommendationsAsync(recommendationsPost);
```
