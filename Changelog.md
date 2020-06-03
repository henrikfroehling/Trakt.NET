Release notes
=============

Version 1.0.0
===

#### 1.0.0
(2020-06-03)

Breaking Changes:

- New response classes
  - `TraktNoContentResponse` replaces all `Task` return types in `Modules`
  - `TraktResponse<TContentType>` replaces all `Task<TItem>` return types in `Modules`
  - `TraktListResponse<TContentType>` replaces all `Task<IEnumerable<TItem>>` return types in `Modules`
  - `TraktPagedResponse<TContentType>` replaces all `Task<TraktPaginationListResult<TItem>>` return types in `Modules`
  - [More information](https://github.com/henrikfroehling/TraktApiSharp/wiki/00-Prereleases#v100-alpha1)

- .NET Standard 1.1 replaces PCL

Changes:
- Split up test project in multiple test projects (release) ([Issue 107](https://github.com/henrikfroehling/Trakt.NET/issues/107)
- Split up TraktNET.Objects.Tests in multiple test projects (release) ([Issue 117](https://github.com/henrikfroehling/TraktApiSharp/issues/117))

Added:
- Add support for new people methods ([Issue 125](https://github.com/henrikfroehling/Trakt.NET/issues/125)

Improved:

- Source Code Documentation ([Issue 28](https://github.com/henrikfroehling/Trakt.NET/issues/28)
- Improve / replace UriTemplate implementation (release) ([Issue 121](https://github.com/henrikfroehling/Trakt.NET/issues/121)
- Improve test coverage

#### 1.0.0-beta
(2019-03-30)

Breaking Changes:

- New response classes
  - `TraktNoContentResponse` replaces all `Task` return types in `Modules`
  - `TraktResponse<TContentType>` replaces all `Task<TItem>` return types in `Modules`
  - `TraktListResponse<TContentType>` replaces all `Task<IEnumerable<TItem>>` return types in `Modules`
  - `TraktPagedResponse<TContentType>` replaces all `Task<TraktPaginationListResult<TItem>>` return types in `Modules`
  - [More information](https://github.com/henrikfroehling/TraktApiSharp/wiki/00-Prereleases#v100-alpha1)

- .NET Standard 1.1 replaces PCL

Changes:

- Rename library / project / repository to "Trakt.NET" ([Issue 3](https://github.com/henrikfroehling/Trakt.NET/issues/3)
- Move all examples into their own repository ([Issue 57](https://github.com/henrikfroehling/TraktApiSharp/issues/57))

Added:

- Add missing "token" property in ITraktAccountSettings ([Issue 27](https://github.com/henrikfroehling/Trakt.NET/issues/27)
- Add missing filter support for text query search ([Issue 72](https://github.com/henrikfroehling/Trakt.NET/issues/72)

Fixed:

- Fix serialization service ([Issue 23](https://github.com/henrikfroehling/Trakt.NET/issues/23)
- post builder feature: add support for posting collected episodes without ids ([Issue 30](https://github.com/henrikfroehling/Trakt.NET/issues/30)
- Implement missing json object and array reader ([Issue 33](https://github.com/henrikfroehling/Trakt.NET/issues/33)
- Implement missing json object and array writer ([Issue 34](https://github.com/henrikfroehling/Trakt.NET/issues/34)
- Fix post builder for sync collection post ([Issue 35](https://github.com/henrikfroehling/Trakt.NET/issues/35)
- Refreshing authorization not working with expired or invalid access token ([Issue 36](https://github.com/henrikfroehling/Trakt.NET/issues/36)
- Revoking authorization not working with expired or invalid access token ([Issue 37](https://github.com/henrikfroehling/Trakt.NET/issues/37)
- Wrong type assignment for lists ([Issue 61](https://github.com/henrikfroehling/Trakt.NET/issues/61)
- Bad Request when adding items to a list ([Issue 62](https://github.com/henrikfroehling/Trakt.NET/issues/62)
- Exception when search text query is empty ([Issue 64](https://github.com/henrikfroehling/Trakt.NET/issues/64)
- Invalid implementation for Networks / List / Get networks ([Issue 65](https://github.com/henrikfroehling/Trakt.NET/issues/65)
- Redundant checks for ITraktMovie properties in TraktScrobbleModule ([Issue 94](https://github.com/henrikfroehling/Trakt.NET/issues/94)

Improved:

- Improve test coverage ([Issue 49](https://github.com/henrikfroehling/TraktApiSharp/issues/49))

---------

#### 1.0.0-alpha3
(2018-06-17)

Breaking Changes:

- New response classes
  - `TraktNoContentResponse` replaces all `Task` return types in `Modules`
  - `TraktResponse<TContentType>` replaces all `Task<TItem>` return types in `Modules`
  - `TraktListResponse<TContentType>` replaces all `Task<IEnumerable<TItem>>` return types in `Modules`
  - `TraktPagedResponse<TContentType>` replaces all `Task<TraktPaginationListResult<TItem>>` return types in `Modules`
  - [More information](https://github.com/henrikfroehling/TraktApiSharp/wiki/00-Prereleases#v100-alpha1)

- .NET Standard 1.1 replaces PCL

Added:

- support for "networks" GET request ([Issue 69](https://github.com/henrikfroehling/TraktApiSharp/issues/69))
- support for "certifications/{type}" GET request ([Issue 70](https://github.com/henrikfroehling/TraktApiSharp/issues/70))
- support for "users/hidden/{section}" POST request ([Issue 71](https://github.com/henrikfroehling/TraktApiSharp/issues/71))
- support for "users/hidden/{section}/remove" POST ([Issue 72](https://github.com/henrikfroehling/TraktApiSharp/issues/72))
- missing "network" property in ITraktSeason ([Issue 83](https://github.com/henrikfroehling/TraktApiSharp/issues/83))
- missing "last_episode" property in ITraktShowProgress ([Issue 88](https://github.com/henrikfroehling/TraktApiSharp/issues/88))
- "dolby_atmos" and "dts_x" in TraktMediaAudio ([Issue 89](https://github.com/henrikfroehling/TraktApiSharp/issues/89))
- support for X-Item-ID and X-Item-Type response headers ([Issue 106](https://github.com/henrikfroehling/TraktApiSharp/issues/106))
- support for "comments/{id}/item" GET request ([Issue 107](https://github.com/henrikfroehling/TraktApiSharp/issues/107))
- support for "comments/{id}/likes" GET request ([Issue 109](https://github.com/henrikfroehling/TraktApiSharp/issues/109))
- missing "country" property in ITraktMovie ([Issue 110](https://github.com/henrikfroehling/TraktApiSharp/issues/110))
- "comment_count" property in ITraktMovie, ITraktShow, ITraktSeason and ITraktEpisode ([Issue 111](https://github.com/henrikfroehling/TraktApiSharp/issues/111))
- support for "people/{id}/lists/{type}/{sort}" GET request ([Issue 116](https://github.com/henrikfroehling/TraktApiSharp/issues/116))
- support for "comments/trending/{comment_type}/{type}?{include_replies}" GET request ([Issue 117](https://github.com/henrikfroehling/TraktApiSharp/issues/117))
- support for "comments/recent/{comment_type}/{type}?{include_replies}" GET request ([Issue 118](https://github.com/henrikfroehling/TraktApiSharp/issues/118))
- support for "comments/updates/{comment_type}/{type}?{include_replies}" GET request ([Issue 119](https://github.com/henrikfroehling/TraktApiSharp/issues/119))
- support for "lists/trending" GET request ([Issue 120](https://github.com/henrikfroehling/TraktApiSharp/issues/120))
- support for "lists/popular" GET request ([Issue 121](https://github.com/henrikfroehling/TraktApiSharp/issues/121))
- support for "include_replies" parameter in "users/id/comments" GET request ([Issue 122](https://github.com/henrikfroehling/TraktApiSharp/issues/122))
- properties for "sort_by" and "sort_how" in `ITraktUserCustomListPost` ([Issue 123](https://github.com/henrikfroehling/TraktApiSharp/issues/123))
- "reset_at" property in ITraktShowWatchedProgress ([Issue 129](https://github.com/henrikfroehling/TraktApiSharp/issues/129))
- flag for "progress_watched_reset" section in TraktHiddenItemsSection ([Issue 130](https://github.com/henrikfroehling/TraktApiSharp/issues/130))

Fixed:

- serialization of Trakt objects to JSON ([Issue #77](https://github.com/henrikfroehling/TraktApiSharp/issues/77))
- serialization service ([Issue #23](https://github.com/henrikfroehling/Trakt.NET/issues/23))

Improved:

- http client handling ([Issue #21](https://github.com/henrikfroehling/TraktApiSharp/issues/21))
- serialization of Trakt objects to JSON ([Issue #75](https://github.com/henrikfroehling/TraktApiSharp/issues/75))
- json deserialization for authorization objects ([Issue #78](https://github.com/henrikfroehling/TraktApiSharp/issues/78))
- allow multiple types as filter in "users/{id}/lists/{list_id}/items/{type}" request ([Issue #124](https://github.com/henrikfroehling/TraktApiSharp/issues/124))

---------

#### 1.0.0-alpha2
(2017-08-11)

Breaking Changes:

- New response classes
  - `TraktNoContentResponse` replaces all `Task` return types in `Modules`
  - `TraktResponse<TContentType>` replaces all `Task<TItem>` return types in `Modules`
  - `TraktListResponse<TContentType>` replaces all `Task<IEnumerable<TItem>>` return types in `Modules`
  - `TraktPagedResponse<TContentType>` replaces all `Task<TraktPaginationListResult<TItem>>` return types in `Modules`
  - [More information](https://github.com/henrikfroehling/TraktApiSharp/wiki/00-Prereleases#v100-alpha1)

- .NET Standard 1.1 replaces PCL

Known issues:

- Serialization of JSON data is not working in post requests ([Issue #77](https://github.com/henrikfroehling/TraktApiSharp/issues/77))

Fixed:

- System.NullReferenceException when getting popular shows ([Issue #59](https://github.com/henrikfroehling/TraktApiSharp/issues/59))

Improved:

- Deserialization of JSON data ([Issue #20](https://github.com/henrikfroehling/TraktApiSharp/issues/20))
- Reduced indirection in object properties ([Issue #18](https://github.com/henrikfroehling/TraktApiSharp/issues/18))

Removed:

- `Images` option in `TraktExtendedInfo` ([Issue #43](https://github.com/henrikfroehling/TraktApiSharp/issues/43))

---------

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

 - TraktCertificationsModule ([Issue #62](https://github.com/henrikfroehling/TraktApiSharp/issues/62))
   - GetMovieCertificationsAsync()
   - GetShowCertificationsAsync()
 - TraktNetworksModule ([Issue #63](https://github.com/henrikfroehling/TraktApiSharp/issues/63))
   - GetNetworksAsync()
 - AddHiddenItemsAsync() in TraktUsersModule ([Issue #54](https://github.com/henrikfroehling/TraktApiSharp/issues/54))
 - RemoveHiddenItemsAsync() TraktUsersModule ([Issue #55](https://github.com/henrikfroehling/TraktApiSharp/issues/55))
 - "Title" property in TraktSeason ([Issue #53](https://github.com/henrikfroehling/TraktApiSharp/issues/53) (thanks to [Romans Pokrovskis](https://github.com/Amoenus)))

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
