# Request Parameters

Many methods in the [modules](modules.md) accept [extended info](requestparameters.md#extended-info) specifications, [filters](requestparameters.md#filters) and / or collections with [multiple object ids](requestparameters.md#multiple-ids).

## Extended Info

A [`TraktExtendedInfo`](xref:TraktNet.Parameters.TraktExtendedInfo) instance can be created to specify, how much data should be retrieved for a request. It is possible to create just one instance of it and use it for each request or to create a new instance of it for every new request.

To create an instance of [`TraktExtendedInfo`](xref:TraktNet.Parameters.TraktExtendedInfo), there are basically two ways.

```csharp
using TraktNet.Parameters;

var extendedInfo = new TraktExtendedInfo
{
    Full = true
};

// or

var extendedInfo = new TraktExtendedInfo().SetFull();
```

[`TraktExtendedInfo`](xref:TraktNet.Parameters.TraktExtendedInfo) has several options you can set and also reset.

| Option | Set | Reset | Limitations |
|--------|-----|-------|-------------|
| Metadata | [`SetMetadata()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetMetadata) or [`Metadata = true`](xref:TraktNet.Parameters.TraktExtendedInfo.Metadata) | [`ResetMetadata()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetMetadata) or [`Metadata = false`](xref:TraktNet.Parameters.TraktExtendedInfo.Metadata) | Works only with [`TraktClient.Sync.GetCollectionMoviesAsync()`](xref:TraktNet.Modules.TraktSyncModule.GetCollectionMoviesAsync(TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)), [`TraktClient.Sync.GetCollectionShowsAsync()`](xref:TraktNet.Modules.TraktSyncModule.GetCollectionShowsAsync(TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)), [`TraktClient.Users.GetCollectionMoviesAsync()`](xref:TraktNet.Modules.TraktUsersModule.GetCollectionMoviesAsync(System.String,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)) and [`TraktClient.Users.GetCollectionShowsAsync()`](xref:TraktNet.Modules.TraktUsersModule.GetCollectionShowsAsync(System.String,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)). Will be ignored otherwise. |
| Full | [`SetFull()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetFull) or [`Full = true`](xref:TraktNet.Parameters.TraktExtendedInfo.Full) | [`ResetFull()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetFull) or [`Full = false`](xref:TraktNet.Parameters.TraktExtendedInfo.Full) | None |
| NoSeasons | [`SetNoSeasons()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetNoSeasons) or [`NoSeasons = true`](xref:TraktNet.Parameters.TraktExtendedInfo.NoSeasons) | [`ResetNoSeasons()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetNoSeasons) or [`NoSeasons = false`](xref:TraktNet.Parameters.TraktExtendedInfo.NoSeasons) | Works only with [`TraktClient.Sync.GetWatchedMoviesAsync()`](xref:TraktNet.Modules.TraktSyncModule.GetWatchedMoviesAsync(TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)) and [`TraktClient.Users.GetWatchedShowsAsync()`](xref:TraktNet.Modules.TraktSyncModule.GetWatchedShowsAsync(TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)). Will be ignored otherwise. |
| Episodes | [`SetEpisodes()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetEpisodes) or [`Episodes = true`](xref:TraktNet.Parameters.TraktExtendedInfo.Episodes) | [`ResetEpisodes()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetEpisodes) or [`Episodes = false`](xref:TraktNet.Parameters.TraktExtendedInfo.Episodes) | Works only with [`TraktClient.Seasons.GetAllSeasonsAsync()`](xref:TraktNet.Modules.TraktSeasonsModule.GetAllSeasonsAsync(System.String,TraktNet.Parameters.TraktExtendedInfo,System.String,System.Threading.CancellationToken)). Will be ignored otherwise. |
| GuestStars | [`SetGuestStars()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetGuestStars) or [`GuestStars = true`](xref:TraktNet.Parameters.TraktExtendedInfo.GuestStars) | [`ResetGuestStars()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetGuestStars) or [`GuestStars = false`](xref:TraktNet.Parameters.TraktExtendedInfo.GuestStars) | Works only with [`TraktNet.Modules.TraktMoviesModule.GetMoviePeopleAsync()`](xref:TraktNet.Modules.TraktMoviesModule.GetMoviePeopleAsync(System.String,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)), [`TraktClient.Shows.GetShowPeopleAsync()`](xref:TraktNet.Modules.TraktShowsModule.GetShowPeopleAsync(System.String,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)), [`TraktClient.Seasons.GetSeasonPeopleAsync()`](xref:TraktNet.Modules.TraktSeasonsModule.GetSeasonPeopleAsync(System.String,System.UInt32,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)) and [`TraktClient.Episodes.GetEpisodePeopleAsync()`](xref:TraktNet.Modules.TraktEpisodesModule.GetEpisodePeopleAsync(System.String,System.UInt32,System.UInt32,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)). Will be ignored otherwise. |
| Comments | [`SetComments()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetComments) or [`Comments = true`](xref:TraktNet.Parameters.TraktExtendedInfo.Comments) | [`ResetComments()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetComments) or [`Comments = false`](xref:TraktNet.Parameters.TraktExtendedInfo.Comments) | Works only with requests which might return comments. Will be ignored otherwise. |
| Vip | [`SetVip()`](xref:TraktNet.Parameters.TraktExtendedInfo.SetVip) or [`Vip = true`](xref:TraktNet.Parameters.TraktExtendedInfo.Vip) | [`ResetVip()`](xref:TraktNet.Parameters.TraktExtendedInfo.ResetVip) or [`Vip = false`](xref:TraktNet.Parameters.TraktExtendedInfo.Vip) | Works only with [`TraktNet.Modules.TraktUsersModule.GetUserProfileAsync()`](xref:TraktNet.Modules.TraktUsersModule.GetUserProfileAsync(System.String,TraktNet.Parameters.TraktExtendedInfo,System.Threading.CancellationToken)) and [`TraktNet.Modules.TraktUsersModule.GetLikesAsync()`](xref:TraktNet.Modules.TraktUsersModule.GetLikesAsync(System.String,TraktNet.Enums.TraktUserLikeType,TraktNet.Parameters.TraktPagedParameters,System.Threading.CancellationToken)). Will be ignored otherwise. |

With `Reset<Option>()` you can disable a single option and with [`Reset()`](xref:TraktNet.Parameters.TraktExtendedInfo.Reset) you can disable all options.

[`TraktExtendedInfo`](xref:TraktNet.Parameters.TraktExtendedInfo) has a fluent interface which allows you to chain its method calls like in the following example.

```csharp
using TraktNet.Parameters;

var extendedInfo = new TraktExtendedInfo().SetMetadata().SetFull().SetNoSeasons().SetEpisodes().Reset().SetNoSeasons().Reset();
```

## Filters

There are four different filters you can use.

- [`ITraktCalendarFilter`](xref:TraktNet.Parameters.ITraktCalendarFilter) for all methods in the [`TraktClient.Calendar`](xref:TraktNet.TraktClient.Calendar) module
- [`ITraktMovieFilter`](xref:TraktNet.Parameters.ITraktMovieFilter) for some methods in the [`TraktClient.Movies`](xref:TraktNet.TraktClient.Movies) module
- [`ITraktShowFilter`](xref:TraktNet.Parameters.ITraktShowFilter) for some methods in the [`TraktClient.Shows`](xref:TraktNet.TraktClient.Shows) module
- [`ITraktSearcFilter`](xref:TraktNet.Parameters.ITraktSearchFilter) for the [`GetTextQueryResultsAsync()`](xref:TraktNet.Modules.TraktSearchModule.GetTextQueryResultsAsync(TraktNet.Enums.TraktSearchResultType,System.String,TraktNet.Enums.TraktSearchField,TraktNet.Parameters.ITraktSearchFilter,TraktNet.Parameters.TraktExtendedInfo,TraktNet.Parameters.TraktPagedParameters,System.Threading.CancellationToken)) method in the [`TraktClient.Search`](xref:TraktNet.TraktClient.Search) module

For each filter exists a builder to create an instance of it.

| Filter | Builder | References |
|--------|---------|------------|
| [`ITraktCalendarFilter`](xref:TraktNet.Parameters.ITraktCalendarFilter) | `TraktFilter.NewCalendarFilter().Build()` | [`NewCalendarFilter()`](xref:TraktNet.Parameters.TraktFilter.NewCalendarFilter), [`.Build()`](xref:TraktNet.Parameters.ITraktFilterBuilder`2.Build) |
| [`ITraktMovieFilter`](xref:TraktNet.Parameters.ITraktMovieFilter) | `TraktFilter.NewMovieFilter().Build()` | [`NewMovieFilter()`](xref:TraktNet.Parameters.TraktFilter.NewMovieFilter), [`.Build()`](xref:TraktNet.Parameters.ITraktFilterBuilder`2.Build) |
| [`ITraktShowFilter`](xref:TraktNet.Parameters.ITraktShowFilter) | `TraktFilter.NewShowFilter().Build()` | [`NewShowFilter()`](xref:TraktNet.Parameters.TraktFilter.NewShowFilter), [`.Build()`](xref:TraktNet.Parameters.ITraktFilterBuilder`2.Build) |
| [`ITraktSearcFilter`](xref:TraktNet.Parameters.ITraktSearchFilter) | `TraktFilter.NewSearchFilter().Build()` | [`NewSearchFilter()`](xref:TraktNet.Parameters.TraktFilter.NewSearchFilter), [`.Build()`](xref:TraktNet.Parameters.ITraktFilterBuilder`2.Build) |

Each filter is immutable.

If you want to change one, just create a new instance.

Filters are only creatable through their builder methods.

In the following example, a [`ITraktCalendarFilter`](xref:TraktNet.Parameters.ITraktCalendarFilter) is created.

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

## Multiple Ids

The methods
- [`TraktClient.Movies.GetMoviesStreamAsync()`](xref:TraktNet.Modules.TraktMoviesModule.GetMoviesStreamAsync(TraktNet.Parameters.TraktMultipleObjectsQueryParams,System.Threading.CancellationToken))
- [`TraktClient.Shows.GetShowsStreamAsync()`](xref:TraktNet.Modules.TraktShowsModule.GetShowsStreamAsync(TraktNet.Parameters.TraktMultipleObjectsQueryParams,System.Threading.CancellationToken))
- [`TraktClient.Seasons.GetSeasonsStreamAsync()`](xref:TraktNet.Modules.TraktSeasonsModule.GetSeasonsStreamAsync(TraktNet.Parameters.TraktMultipleSeasonsQueryParams,System.Threading.CancellationToken))
- [`TraktClient.Episodes.GetEpisodesStreamAsync()`](xref:TraktNet.Modules.TraktEpisodesModule.GetEpisodesStreamAsync(TraktNet.Parameters.TraktMultipleEpisodesQueryParams,System.Threading.CancellationToken))
- [`TraktClient.People.GetPersonsStreamAsync()`](xref:TraktNet.Modules.TraktPeopleModule.GetPersonsStreamAsync(TraktNet.Parameters.TraktMultipleObjectsQueryParams,System.Threading.CancellationToken))
- [`TraktClient.Users.GetPersonalListsStreamAsync()`](xref:TraktNet.Modules.TraktUsersModule.GetPersonalListsStreamAsync(TraktNet.Parameters.TraktMultipleUserListsQueryParams,System.Threading.CancellationToken))
- [`TraktClient.Comments.GetCommentsStreamAsync()`](xref:TraktNet.Modules.TraktCommentsModule.GetCommentsStreamAsync(TraktNet.Parameters.TraktMultipleCommentsQueryParams,System.Threading.CancellationToken))
require each a collection of mutliple ids of objects, which you want to retrieve, as an argument.

| Method | Collection |
|--------|------------|
| [`TraktClient.Movies.GetMoviesStreamAsync()`](xref:TraktNet.Modules.TraktMoviesModule.GetMoviesStreamAsync(TraktNet.Parameters.TraktMultipleObjectsQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleObjectsQueryParams`](xref:TraktNet.Parameters.TraktMultipleObjectsQueryParams) |
| [`TraktClient.Shows.GetShowsStreamAsync()`](xref:TraktNet.Modules.TraktShowsModule.GetShowsStreamAsync(TraktNet.Parameters.TraktMultipleObjectsQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleObjectsQueryParams`](xref:TraktNet.Parameters.TraktMultipleObjectsQueryParams) |
| [`TraktClient.Seasons.GetSeasonsStreamAsync()`](xref:TraktNet.Modules.TraktSeasonsModule.GetSeasonsStreamAsync(TraktNet.Parameters.TraktMultipleSeasonsQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleSeasonsQueryParams`](xref:TraktNet.Parameters.TraktMultipleSeasonsQueryParams) |
| [`TraktClient.Episodes.GetEpisodesStreamAsync()`](xref:TraktNet.Modules.TraktEpisodesModule.GetEpisodesStreamAsync(TraktNet.Parameters.TraktMultipleEpisodesQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleEpisodesQueryParams`](xref:TraktNet.Parameters.TraktMultipleEpisodesQueryParams) |
| [`TraktClient.People.GetPersonsStreamAsync()`](xref:TraktNet.Modules.TraktPeopleModule.GetPersonsStreamAsync(TraktNet.Parameters.TraktMultipleObjectsQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleObjectsQueryParams`](xref:TraktNet.Parameters.TraktMultipleObjectsQueryParams) |
| [`TraktClient.Users.GetPersonalListsStreamAsync()`](xref:TraktNet.Modules.TraktUsersModule.GetPersonalListsStreamAsync(TraktNet.Parameters.TraktMultipleUserListsQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleUserListsQueryParams`](xref:TraktNet.Parameters.TraktMultipleUserListsQueryParams) |
| [`TraktClient.Comments.GetCommentsStreamAsync()`](xref:TraktNet.Modules.TraktCommentsModule.GetCommentsStreamAsync(TraktNet.Parameters.TraktMultipleCommentsQueryParams,System.Threading.CancellationToken)) | [`TraktMultipleCommentsQueryParams`](xref:TraktNet.Parameters.TraktMultipleCommentsQueryParams) |

### [`TraktMultipleObjectsQueryParams`](xref:TraktNet.Parameters.TraktMultipleObjectsQueryParams)

```csharp
using TraktNet.Modules;
using TraktNet.Parameters;

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

### [`TraktMultipleSeasonsQueryParams`](xref:TraktNet.Parameters.TraktMultipleSeasonsQueryParams)

```csharp
using TraktNet.Modules;
using TraktNet.Parameters;

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

### [`TraktMultipleEpisodesQueryParams`](xref:TraktNet.Parameters.TraktMultipleEpisodesQueryParams)

```csharp
using TraktNet.Modules;
using TraktNet.Parameters;

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

### [`TraktMultipleUserListsQueryParams`](xref:TraktNet.Parameters.TraktMultipleUserListsQueryParams)

```csharp
using TraktNet.Modules;
using TraktNet.Parameters;

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

### [`TraktMultipleCommentsQueryParams`](xref:TraktNet.Parameters.TraktMultipleCommentsQueryParams)

```csharp
using TraktNet.Modules;
using TraktNet.Parameters;

var queryParams = new TraktMultipleCommentsQueryParams
{
    // { comment-id[, extended info] }
    1,
    { 2, new TraktExtendedInfo { Full = true } },
    3
};

// or

var queryParams = new TraktMultipleCommentsQueryParams();

queryParams.Add(1);
queryParams.Add(2, new TraktExtendedInfo { Full = true });
queryParams.Add(3);
```

## Post Objects (Post Builder)

There are several methods which require a post object.
These are mostly required in the following modules:
- [`TraktClient.Checkins`](xref:TraktNet.TraktClient.Checkins)
- [`TraktClient.Comments`](xref:TraktNet.TraktClient.Comments)
- [`TraktClient.Scrobble`](xref:TraktNet.TraktClient.Scrobble)
- [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync)
- [`TraktClient.Users`](xref:TraktNet.TraktClient.Users)

Here is an overview of the post objects, its modules and its builder methods:

| Post Object | Module | Builder | Where |
|-------------|--------|---------|-------|
| [`ITraktSyncCollectionPost`](xref:TraktNet.Objects.Post.Syncs.Collection.ITraktSyncCollectionPost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncCollectionPostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncCollectionPostBuilder) | [`TraktPost.NewSyncCollectionPost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncCollectionPost) |
| [`ITraktSyncCollectionRemovePost`](xref:TraktNet.Objects.Post.Syncs.Collection.ITraktSyncCollectionRemovePost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncCollectionRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncCollectionRemovePostBuilder) | [`TraktPost.NewSyncCollectionRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncCollectionRemovePost) |
| [`ITraktSyncFavoritesPost`](xref:TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesPost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncFavoritesPostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncFavoritesPostBuilder) | [`TraktPost.NewSyncFavoritesPost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncFavoritesPost) |
| [`ITraktSyncFavoritesRemovePost`](xref:TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesRemovePost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncFavoritesRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncFavoritesRemovePostBuilder) | [`TraktPost.NewSyncFavoritesRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncFavoritesRemovePost) |
| [`ITraktSyncHistoryPost`](xref:TraktNet.Objects.Post.Syncs.History.ITraktSyncHistoryPost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncHistoryPostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncHistoryPostBuilder) | [`TraktPost.NewSyncHistoryPost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncHistoryPost) |
| [`ITraktSyncHistoryRemovePost`](xref:TraktNet.Objects.Post.Syncs.History.ITraktSyncHistoryRemovePost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncHistoryRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncHistoryRemovePostBuilder) | [`TraktPost.NewSyncHistoryRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncHistoryRemovePost) |
| [`ITraktSyncRatingsPost`](xref:TraktNet.Objects.Post.Syncs.Ratings.ITraktSyncRatingsPost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncRatingsPostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncRatingsPostBuilder) | [`TraktPost.NewSyncRatingsPost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncRatingsPost) |
| [`ITraktSyncRatingsRemovePost`](xref:TraktNet.Objects.Post.Syncs.Ratings.ITraktSyncRatingsRemovePost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncRatingsRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncRatingsRemovePostBuilder) | [`TraktPost.NewSyncRatingsRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncRatingsRemovePost) |
| [`ITraktSyncWatchlistPost`](xref:TraktNet.Objects.Post.Syncs.Watchlist.ITraktSyncWatchlistPost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncWatchlistPostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncWatchlistPostBuilder) | [`TraktPost.NewSyncWatchlistPost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncWatchlistPost) |
| [`ITraktSyncWatchlistRemovePost`](xref:TraktNet.Objects.Post.Syncs.Watchlist.ITraktSyncWatchlistRemovePost) | [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) | [`ITraktSyncWatchlistRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktSyncWatchlistRemovePostBuilder) | [`TraktPost.NewSyncWatchlistRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewSyncWatchlistRemovePost) |
| [`ITraktUserHiddenItemsPost`](xref:TraktNet.Objects.Post.Users.HiddenItems.ITraktUserHiddenItemsPost) | [`TraktClient.Users`](xref:TraktNet.TraktClient.Users) | [`ITraktUserHiddenItemsPostBuilder`](xref:TraktNet.PostBuilder.ITraktUserHiddenItemsPostBuilder) | [`TraktPost.NewUserHiddenItemsPost()`](xref:TraktNet.PostBuilder.TraktPost.NewUserHiddenItemsPost) |
| [`ITraktUserHiddenItemsRemovePost`](xref:TraktNet.Objects.Post.Users.HiddenItems.ITraktUserHiddenItemsRemovePost) | [`TraktClient.Users`](xref:TraktNet.TraktClient.Users) | [`ITraktUserHiddenItemsRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktUserHiddenItemsRemovePostBuilder) | [`TraktPost.NewUserHiddenItemsRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewUserHiddenItemsRemovePost) |
| [`ITraktUserPersonalListItemsPost`](xref:TraktNet.Objects.Post.Users.ITraktUserPersonalListPost) | [`TraktClient.Users`](xref:TraktNet.TraktClient.Users) | [`ITraktUserPersonalListItemsPostBuilder`](xref:TraktNet.PostBuilder.ITraktUserPersonalListItemsPostBuilder) | [`TraktPost.NewUserPersonalListItemsPost()`](xref:TraktNet.PostBuilder.TraktPost.NewUserPersonalListItemsPost) |
| [`ITraktUserPersonalListItemsRemovePost`](xref:TraktNet.Objects.Post.Users.PersonalListItems.ITraktUserPersonalListItemsRemovePost) | [`TraktClient.Users`](xref:TraktNet.TraktClient.Users) | [`ITraktUserPersonalListItemsRemovePostBuilder`](xref:TraktNet.PostBuilder.ITraktUserPersonalListItemsRemovePostBuilder) | [`TraktPost.NewUserPersonalListItemsRemovePost()`](xref:TraktNet.PostBuilder.TraktPost.NewUserPersonalListItemsRemovePost) |
| [`ITraktMovieCommentPost`](xref:TraktNet.Objects.Post.Comments.ITraktMovieCommentPost) | [`TraktClient.Comments`](xref:TraktNet.TraktClient.Comments) | [`ITraktMovieCommentPostBuilder`](xref:TraktNet.PostBuilder.ITraktMovieCommentPostBuilder) | [`TraktPost.NewMovieCommentPost()`](xref:TraktNet.PostBuilder.TraktPost.NewMovieCommentPost) |
| [`ITraktShowCommentPost`](xref:TraktNet.Objects.Post.Comments.ITraktShowCommentPost) | [`TraktClient.Comments`](xref:TraktNet.TraktClient.Comments) | [`ITraktShowCommentPostBuilder`](xref:TraktNet.PostBuilder.ITraktShowCommentPostBuilder) | [`TraktPost.NewShowCommentPost()`](xref:TraktNet.PostBuilder.TraktPost.NewShowCommentPost) |
| [`ITraktSeasonCommentPost`](xref:TraktNet.Objects.Post.Comments.ITraktSeasonCommentPost) | [`TraktClient.Comments`](xref:TraktNet.TraktClient.Comments) | [`ITraktSeasonCommentPostBuilder`](xref:TraktNet.PostBuilder.ITraktSeasonCommentPostBuilder) | [`TraktPost.NewSeasonCommentPost()`](xref:TraktNet.PostBuilder.TraktPost.NewSeasonCommentPost) |
| [`ITraktEpisodeCommentPost`](xref:TraktNet.Objects.Post.Comments.ITraktEpisodeCommentPost) | [`TraktClient.Comments`](xref:TraktNet.TraktClient.Comments) | [`ITraktEpisodeCommentPostBuilder`](xref:TraktNet.PostBuilder.ITraktEpisodeCommentPostBuilder) | [`TraktPost.NewEpisodeCommentPost()`](xref:TraktNet.PostBuilder.TraktPost.NewEpisodeCommentPost) |
| [`ITraktListCommentPost`](xref:TraktNet.Objects.Post.Comments.ITraktListCommentPost) | [`TraktClient.Comments`](xref:TraktNet.TraktClient.Comments) | [`ITraktListCommentPostBuilder`](xref:TraktNet.PostBuilder.ITraktListCommentPostBuilder) | [`TraktPost.NewListCommentPost()`](xref:TraktNet.PostBuilder.TraktPost.NewListCommentPost) |
| [`ITraktMovieCheckinPost`](xref:TraktNet.Objects.Post.Checkins.ITraktMovieCheckinPost) | [`TraktClient.Checkins`](xref:TraktNet.TraktClient.Checkins) | [`ITraktMovieCheckinPostBuilder`](xref:TraktNet.PostBuilder.ITraktMovieCheckinPostBuilder) | [`TraktPost.NewMovieCheckinPost()`](xref:TraktNet.PostBuilder.TraktPost.NewMovieCheckinPost) |
| [`ITraktEpisodeCheckinPost`](xref:TraktNet.Objects.Post.Checkins.ITraktEpisodeCheckinPost) | [`TraktClient.Checkins`](xref:TraktNet.TraktClient.Checkins) | [`ITraktEpisodeCheckinPostBuilder`](xref:TraktNet.PostBuilder.ITraktEpisodeCheckinPostBuilder) | [`TraktPost.NewEpisodeCheckinPost()`](xref:TraktNet.PostBuilder.TraktPost.NewEpisodeCheckinPost) |
| [`ITraktMovieScrobblePost`](xref:TraktNet.Objects.Post.Scrobbles.ITraktMovieScrobblePost) | [`TraktClient.Scrobble`](xref:TraktNet.TraktClient.Scrobble) | [`ITraktMovieScrobblePostBuilder`](xref:TraktNet.PostBuilder.ITraktMovieScrobblePostBuilder) | [`TraktPost.NewMovieScrobblePost()`](xref:TraktNet.PostBuilder.TraktPost.NewMovieScrobblePost) |
| [`ITraktEpisodeScrobblePost`](xref:TraktNet.Objects.Post.Scrobbles.ITraktEpisodeScrobblePost) | [`TraktClient.Scrobble`](xref:TraktNet.TraktClient.Scrobble) | [`ITraktEpisodeScrobblePostBuilder`](xref:TraktNet.PostBuilder.ITraktEpisodeScrobblePostBuilder) | [`TraktPost.NewEpisodeScrobblePost()`](xref:TraktNet.PostBuilder.TraktPost.NewEpisodeScrobblePost) |

You do not need to use the builder methods for creating instances of post objects.

It is also possible to just create an instance, like this:

```csharp
ITraktSyncFavoritesPost favoritesPost = new TraktSyncFavoritesPost();
```
But it is recommended to use the builder methods.

They check the added values for validity while creating an instance.

The following example creates an [`ITraktSyncFavoritesPost`](xref:TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesPost) instance which is required for the [`AddFavoriteItemsAsync()`](xref:TraktNet.Modules.TraktSyncModule.AddFavoriteItemsAsync(TraktNet.Objects.Post.Syncs.Favorites.ITraktSyncFavoritesPost,System.Threading.CancellationToken)) method in the [`TraktClient.Sync`](xref:TraktNet.TraktClient.Sync) module.

```csharp
// Get shows and movies for this example.
TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync();
TraktPagedResponse<ITraktTrendingShow> trendingShows = await client.Shows.GetTrendingShowsAsync();

// Create the post object with the queried shows and movies.
ITraktSyncFavoritesPost favoritesPost = TraktPost.NewSyncFavoritesPost()
                                            .WithMovies(trendingMovies)
                                            .WithShows(trendingShows)
                                            .Build();

// Use the post object.
TraktResponse<ITraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(favoritesPost);
```
