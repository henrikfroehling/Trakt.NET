Release notes
=============

Version 1.0.0
===

#### 1.0.0-alpha1
(2017-02-07)

Breaking Changes:

- New response classes
  - `TraktNoContentResponse` replaces all `Task` return types in `Modules`
  - `TraktResponse<TContentType>` replaces all `Task<TItem>` return types in `Modules`
  - `TraktListResponse<TContentType>` replaces all `Task<IEnumerable<TItem>>` return types in `Modules`
  - `TraktPagedResponse<TContentType>` replaces all `Task<TraktPaginationListResult<TItem>>` return types in `Modules`
  - [More information](https://github.com/henrikfroehling/TraktApiSharp/wiki/00-Prereleases#v100-alpha1)

- .NET Standard 1.2 replaces PCL

Added:

- `bool ThrowResponseExceptions` in `TraktConfiguration`

Removed:

- support for .NET Framework 4.5 (minimum is 4.5.1 now)
- support for Windows 8 (minimum is Windows 8.1 now)
- Attributes

Renamed:

- namespace Requests.Params (-> Requests.Parameters)

Version 0.10.0
===

#### 0.10.0
*(2017-05-13)*

Added:

 - TraktCertificationsModule #62
   - GetMovieCertificationsAsync()
   - GetShowCertificationsAsync()
 - TraktNetworksModule #63
   - GetNetworksAsync()
 - AddHiddenItemsAsync() in TraktUsersModule #54
 - RemoveHiddenItemsAsync() TraktUsersModule #55
 - "Title" property in TraktSeason #53 (thanks to @Amoenus)

Version 0.9.0
===

#### 0.9.0
*(2017-01-24)*

Fixed:

- GetMovieReleasesAsync() in TraktMoviesModule
- GetMovieTranslationsAsync() in TraktMoviesModule
- GetShowTranslationsAsync() in TraktShowsModule

Added:

- GetEpisodeListsAsync() in TraktEpisodesModule
- GetEpisodeTranslationsAsync() in TraktEpisodesModule
- GetMovieListsAsync() in TraktMoviesModule
- GetSeasonListsAsync() in TraktSeasonsModule
- GetShowListsAsync() in TraktShowsModule
- "Runtime" property in TraktEpisode
- "Translations" property in TraktEpisode
- support for episode translations in GetAllSeasonsAsync() in TraktSeasonsModule
- support for episode translations in GetSeasonAsync() in TraktSeasonsModule

Removed:

- GetMovieSingleReleaseAsync() in TraktMoviesModule (use GetMovieReleasesAsync() instead)
- GetMovieSingleTranslationAsync() in TraktMoviesModule (use GetMovieTranslationsAsync() instead)
- GetShowSingleTranslationAsync() in TraktShowsModule (use GetShowTranslationsAsync() instead
- deprecated version of GetTextQueryResultsAsync() in TraktSearchModule
- deprecated version of GetIdLookupResultsAsync() in TraktSearchModule

Version 0.8.0
===

#### 0.8.0
*(2016-12-11)*

Added:

- range support for years parameter in filters
- AddMovies(IEnumerable< TraktMovie >) in TraktSyncCollectionPostBuilder
- AddShows(IEnumerable< TraktShow >) in TraktSyncCollectionPostBuilder
- AddEpisodes(IEnumerable< TraktEpisode >) in TraktSyncCollectionPostBuilder
- more overloads for AddShow() in TraktSyncCollectionPostBuilder
- AddMovies(IEnumerable< TraktMovie >) in TraktSyncRatingsPostBuilder
- AddShows(IEnumerable< TraktShow >) in TraktSyncRatingsPostBuilder
- AddEpisodes(IEnumerable< TraktEpisode >) in TraktSyncRatingsPostBuilder
- more overloads for AddShow() and AddShowWithRating() in TraktSyncRatingsPostBuilder
- AddMovies(IEnumerable< TraktMovie >) in TraktSyncWatchlistPostBuilder
- AddShows(IEnumerable< TraktShow >) in TraktSyncWatchlistPostBuilder
- AddEpisodes(IEnumerable< TraktEpisode >) in TraktSyncWatchlistPostBuilder
- more overloads for AddShow() in TraktSyncWatchlistPostBuilder
- AddMovies(IEnumerable< TraktMovie >) in TraktSyncHistoryPostBuilder
- AddShows(IEnumerable< TraktShow >) in TraktSyncHistoryPostBuilder
- AddEpisodes(IEnumerable< TraktEpisode >) in TraktSyncHistoryPostBuilder
- more overloads for AddShow() in TraktSyncHistoryPostBuilder
- AddMovies(IEnumerable< TraktMovie >) in TraktSyncHistoryRemovePostBuilder
- AddShows(IEnumerable< TraktShow >) in TraktSyncHistoryRemovePostBuilder
- AddEpisodes(IEnumerable< TraktEpisode >) in TraktSyncHistoryRemovePostBuilder
- more overloads for AddShow() and AddHistoryIds() in TraktSyncHistoryRemovePostBuilder
- AddMovies(IEnumerable< TraktMovie >) in TraktUserCustomListItemsPostBuilder
- AddShows(IEnumerable< TraktShow >) in TraktUserCustomListItemsPostBuilder
- AddPersons(IEnumerable< TraktPerson >) in TraktUserCustomListItemsPostBuilder
- more overloads for AddShow() in TraktUserCustomListItemsPostBuilder

Improved:

- performance of Serialize(TraktAuthorization) in TraktSerializationService
- performance of DeserializeAuthorization() in TraktSerializationService

Version 0.7.0
===

#### 0.7.0
*(2016-11-13)*

Added:

- support for "calendars/all/dvd" request (TraktCalendarModule.GetAllDVDMoviesAsync())
- support for "calendars/my/dvd" request (TraktCalendarModule.GetUserDVDMoviesAsync())
- Clear*ParameterName*() method for each parameter in TraktCalendarFilter, TraktMovieFilter, TraktShowFilter and TraktSearchFilter

Renamed:

- UseStagingUrl (-> UseSandboxEnvironment) in TraktConfiguration

Changed:

- return type of Clear() method in TraktCalendarFilter to TraktCalendarFilter
- return type of Clear() method in TraktMovieFilter to TraktMovieFilter
- return type of Clear() method in TraktShowFilter to TraktShowFilter
- return type of Clear() method in TraktSearchFilter to TraktSearchFilter

Removed:

- Serialize(TraktDevice) in TraktSerializationService
- DeserializeDevice() in TraktSerializationService

Version 0.6.0
===

#### 0.6.0
*(2016-10-23)*

Added:

- "HiddenAt" properties in response of TraktSyncModule.GetLastActivitiesAsync()
- "Id" property (history id) in response of TraktCheckinsModule.CheckInto[Movie|Episode|EpisodeWithShow]Async()
- "Id" property (history id) in response of TraktScrobbleModule.Start[Movie|Episode|EpisodeWithShow]Async()
- "Id" property (history id) in response of TraktScrobbleModule.Pause[Movie|Episode|EpisodeWithShow]Async()
- "Id" property (history id) in response of TraktScrobbleModule.Stop[Movie|Episode|EpisodeWithShow]Async()
- support for "shows/id/next_episode" request (TraktShowsModule.GetShowNextEpisodeAsync())
- support for "shows/id/last_episode" request (TraktShowsModule.GetShowLastEpisodeAsync())

Fixed:

- thrown exception for episode requests with season number 0

Version 0.5.0
===

#### 0.5.1
*(2016-10-07)*

Added:
- new method overload for "CreateWith" in TraktAuthorization

Fixed:
- wrong OAuth authorization URL, when staging environment is enabled
- TraktClient.Authorization is not reset after successful call of RevokeAuthorizationAsync()

---------

#### 0.5.0
*(2016-10-05)*

Added:
- method "CreateWith" in TraktAuthorization for simpler creation of TraktAuthorization from existing access tokens
- method "CheckIfAuthorizationIsExpiredOrWasRevokedAsync" in TraktAuthentication for checking, whether authorization was revoked by user
- method "CheckIfAccessTokenWasRevokedOrIsNotValidAsync" in TraktAuthentication for checking, whether access token was revoked by user

Removed:
- AccessToken property in TraktClient

Renamed:
- TraktExtendedOption -> TraktExtendedInfo

Fixed:
- item id parameter of GetWatchedHistoryAsync in TraktSyncModule
- item id parameter of GetWatchedHistoryAsync in TraktUsersModule

Version 0.4.0
===

#### 0.4.0
*(2016-09-14)*

Added:
- Support for new search fields

Version 0.3.0
===

#### 0.3.2
*(2016-09-07)*

Fixed:
- Missing default startDate value in calendar methods

---------

#### 0.3.1
*(2016-08-30)*

Fixed:
- NullReferenceException in TraktSerializationService
- IsExpired calculation of TraktAuthorization

---------

#### 0.3.0
*(2016-08-24)*

Added:
- missing source documentation
- user ids (slug)
- count-specials parameter for show-collection- and show-watched-progress-request
- pagination support for sync-get-watchlist- and users-get-watchlist-request
- support for sorting headers (X-Sort-By, X-Sort-How)
- IsValid and IsRefreshPossible properties in TraktAuthorization
- serialization service for TraktDevice and TraktAuthorization
- display names for Trakt enums (-> Trakt[EnumName].DisplayName)

Removed:
- slug from episode ids

Improved:
- parameter names in modules
- minor performance improvements

Changed:
- type of "Release" property in "TraktCalendarMovie" from string to DateTime
- object ids are now unsigned
- TraktHistoryItem id is now unsigned long

Fixed:
- revoking of access token
- IsExpired calculation of TraktAuthorization

Version 0.2.0
===

#### 0.2.0
*(2016-07-29)*

Added:
- source documentation
- fillter support for movies, shows, calendars and search
- new search methods
- query methods for multiple seasons, episodes and user lists
- extended option for sync-watched-history-request
- extended option for users-follow-requests-, users-profile-, users-followers-, users-following-, users-friends- and users-watched-history-request
- builder for user-list-items-post, sync-collection-post, sync-history-post, sync-history-remove-post, sync-ratings-post, sync-watchlist-post

Improved:
- query methods for multiple movies, shows, persons and comments

Removed:
- extended option from checkin-, scrobble-requests and sync-playback-progress-request

Simplified:
- usage of list results

-------------------

#### 0.2.0-beta2
*(2016-07-21)*

Added:
- fillter support for movies, shows, calendars and search
- new search methods
- query methods for multiple seasons, episodes and user lists
- extended option for sync-watched-history-request
- extended option for users-follow-requests-, users-profile-, users-followers-, users-following-, users-friends- and users-watched-history-request
- builder for user-list-items-post, sync-collection-post, sync-history-post, sync-history-remove-post, sync-ratings-post, sync-watchlist-post

Improved:
- query methods for multiple movies, shows, persons and comments

Removed:
- extended option from checkin-, scrobble-requests and sync-playback-progress-request

Simplified:
- usage of list results

-------------------

#### 0.2.0-beta1
*(2016-07-11)*

Added:
- fillter support for movies, shows and search
- new search methods
- query methods for multiple seasons, episodes and user lists
- extended option for sync-watched-history-request
- extended option for users-follow-requests-, users-profile-, users-followers-, users-following-, users-friends- and users-watched-history-request

Improved:
- query methods for multiple movies, shows, persons and comments

Removed:
- extended option from checkin-, scrobble-requests and sync-playback-progress-request

Simplified:
- usage of list results

Version 0.1.0
===

#### 0.1.1
*(2016-07-09)*

Fixed:
- missing content type for authentication request bodies
- unhandled optional authorization for user requests
- unhandled exception when parsing null values => each property should be treated as nullable

Updated:
- Trakt API base URL

---------

#### 0.1.0
*(2016-06-27)*

- First stable release
