Changelog
=============

Version 1.3.0
===

#### 1.3.0
(2022-11-08)

Breaking Changes:

- Rename "CustomList(s)" requests to "PersonalList(s)" requests ([Issue 276](https://github.com/henrikfroehling/Trakt.NET/issues/276))
- Rename `ITraktSharing` to `ITraktConnections` ([Issue 303](https://github.com/henrikfroehling/Trakt.NET/issues/303))
- Rename `TraktUserCustomListPost` to `TraktUserPersonalListPost` ([Issue 349](https://github.com/henrikfroehling/Trakt.NET/issues/349))
- Move parameter types into namespace `TraktNet.Parameters` ([Issue 354](https://github.com/henrikfroehling/Trakt.NET/issues/354))
  - `TraktExtendedInfo`
  - `TraktPagedParameters`
  - `TraktIncludeReplies`
- Refactor filters ([Issue 289](https://github.com/henrikfroehling/Trakt.NET/issues/289))
  - Filters are now in the namespace `TraktNet.Parameters`
  - Filters are now immutable and cannot be changed after created
  - Filters are now only creatable with their builder methods
    - `ITraktCalendarFilter` => `TraktFilter.NewCalendarFilter().Build()`
    - `ITraktMovieFilter` => `TraktFilter.NewMovieFilter().Build()`
    - `ITraktShowFilter` => `TraktFilter.NewShowFilter().Build()`
    - `ITraktSearchFilter` => `TraktFilter.NewSearchFilter().Build()`
- Post builder refactoring ([Issue 319](https://github.com/henrikfroehling/Trakt.NET/issues/319))
  - Post builder methods have been completely refactored and unified
  - Post builder methods are now in the namespace `TraktNet.PostBuilder`
  - Posts can be created with the `TraktPost.New...Post().Build()` methods
  - There have been added new builders methods for creating comment-, checkin- and scrobble-posts ([Issue 346](https://github.com/henrikfroehling/Trakt.NET/issues/346))
  - Following post objects are now also creatable with the post builder methods
    - `ITraktSyncCollectionRemovePost`
    - `ITraktSyncRatingsRemovePost`
    - `ITraktSyncRecommendationsRemovePost`
    - `ITraktSyncWatchlistRemovePost`
    - `ITraktUserHiddenItemsRemovePost`
    - `ITraktUserPersonalListItemsRemovePost`
    - `ITraktMovieCommentPost`
    - `ITraktShowCommentPost`
    - `ITraktSeasonCommentPost`
    - `ITraktEpisodeCommentPost`
    - `ITraktListCommentPost`
    - `ITraktMovieCheckinPost`
    - `ITraktEpisodeCheckinPost`
    - `ITraktMovieScrobblePost`
    - `ITraktEpisodeScrobblePost`

Added:

- Add support for "limits" property in `ITraktUserSettings` ([Issue 272](https://github.com/henrikfroehling/Trakt.NET/issues/272))
- Add new exception type for HTTP Status Code 420 (user has exceeded their account limit) ([Issue 273](https://github.com/henrikfroehling/Trakt.NET/issues/273))
- Add support for "notes" (255 maximum characters) for watchlist and personal list items ([Issue 274](https://github.com/henrikfroehling/Trakt.NET/issues/274))
- Add value "recommendations" in `TraktListType` enumeration ([Issue 275](https://github.com/henrikfroehling/Trakt.NET/issues/275))
- Add support for "lists/{id}" GET request ([Issue 277](https://github.com/henrikfroehling/Trakt.NET/issues/277))
- Add support for "lists/{id}/likes" GET request ([Issue 278](https://github.com/henrikfroehling/Trakt.NET/issues/278))
- Add support for "lists/{id}/items/{type}" GET request ([Issue 279](https://github.com/henrikfroehling/Trakt.NET/issues/279))
- Add support for "lists/{id}/comments/{sort}" GET request ([Issue 280](https://github.com/henrikfroehling/Trakt.NET/issues/280))
- Add support for "users/{id}/lists/collaborations" GET request ([Issue 281](https://github.com/henrikfroehling/Trakt.NET/issues/281))
- Add support for "users/saved_filters" GET request ([Issue 282](https://github.com/henrikfroehling/Trakt.NET/issues/282))
- Add support for "facebook" and "apple" properties in `ITraktConnections` ([Issue 283](https://github.com/henrikfroehling/Trakt.NET/issues/283))
- Add support for "rated" property in `ITraktSharingText` ([Issue 284](https://github.com/henrikfroehling/Trakt.NET/issues/284))
- Add support for "vip_og", "vip_years" and "vip_cover_image" properties in `ITraktUser` ([Issue 285](https://github.com/henrikfroehling/Trakt.NET/issues/285))
- Add support for "movies/updates/id/{start_date}" GET request ([Issue 293](https://github.com/henrikfroehling/Trakt.NET/issues/293))
- Add support for "shows/updates/id/{start_date}" GET request ([Issue 294](https://github.com/henrikfroehling/Trakt.NET/issues/294))
- Add support for "id" and "rank" properties in `ITraktWatchlistItem` ([Issue 310](https://github.com/henrikfroehling/Trakt.NET/issues/310))
- New Post builder implementations ([Issue 346](https://github.com/henrikfroehling/Trakt.NET/issues/346))

Fixed:

- [Bug]: ValidateHistoryPost for RemoveWatchedHistoryItemsAsync ignores WithHistoryIds ([Issue 316](https://github.com/henrikfroehling/Trakt.NET/issues/316))

Improved:

- Return enum types for response headers with fixed values (e.g. SortBy, SortHow) ([Issue 288](https://github.com/henrikfroehling/Trakt.NET/issues/288))
- Improve request validations ([Issue 350](https://github.com/henrikfroehling/Trakt.NET/issues/350))

Changed:

- Rename "CustomList(s)" requests to "PersonalList(s)" requests ([Issue 276](https://github.com/henrikfroehling/Trakt.NET/issues/276))
- Rename `ITraktSharing` to `ITraktConnections` ([Issue 303](https://github.com/henrikfroehling/Trakt.NET/issues/303))
- Change type of "rank" property in `ITraktListItem` to `int` ([Issue 311](https://github.com/henrikfroehling/Trakt.NET/issues/311))
- Rename `TraktUserCustomListPost` to `TraktUserPersonalListPost` ([Issue 349](https://github.com/henrikfroehling/Trakt.NET/issues/349))
- Move parameter types into namespace `TraktNet.Parameters` ([Issue 354](https://github.com/henrikfroehling/Trakt.NET/issues/354))
  - `TraktExtendedInfo`
  - `TraktPagedParameters`
  - `TraktIncludeReplies`

---------

Version 1.2.0
===

#### 1.2.0
(2022-04-24)

Breaking Change:

- Update target framework to .NET Standard 2.0 ([Issue 247](https://github.com/henrikfroehling/Trakt.NET/issues/247))

Added:

- Add support for getting rate limit details ([Issue 193](https://github.com/henrikfroehling/Trakt.NET/issues/193))
- Add values "aired" and "watched" in `TraktLastActivity` enumeration ([Issue 198](https://github.com/henrikfroehling/Trakt.NET/issues/198))
- Add support for "users/requests/following" GET request ([Issue 199](https://github.com/henrikfroehling/Trakt.NET/issues/199))
- Add property for "recommended" counts in `ITraktStatistics` ([Issue 200](https://github.com/henrikfroehling/Trakt.NET/issues/200))
- Add support for "users/{id}/lists/{list_id}/likes" GET request ([Issue 201](https://github.com/henrikfroehling/Trakt.NET/issues/201))
- Add support for optional pagination in "sync/playback" GET request ([Issue 202](https://github.com/henrikfroehling/Trakt.NET/issues/202))
- Add support for date filtering in "sync/playback" GET request ([Issue 203](https://github.com/henrikfroehling/Trakt.NET/issues/203))
- Add support for "sync/recommendations" GET request ([Issue 204](https://github.com/henrikfroehling/Trakt.NET/issues/204))
- Add support for "sync/recommendations" POST request ([Issue 205](https://github.com/henrikfroehling/Trakt.NET/issues/205))
- Add support for "sync/recommendations/remove" POST request ([Issue 206](https://github.com/henrikfroehling/Trakt.NET/issues/206))
- Add support for "sync/recommendations/reorder" POST request ([Issue 232](https://github.com/henrikfroehling/Trakt.NET/issues/232))
- Add support for VIP only methods ([Issue 236](https://github.com/henrikfroehling/Trakt.NET/issues/236))
- Add support for "shows/{id}/progress/watched/reset" POST request ([Issue 237](https://github.com/henrikfroehling/Trakt.NET/issues/237))
- Add support for "shows/{id}/progress/watched/reset" DELETE request ([Issue 238](https://github.com/henrikfroehling/Trakt.NET/issues/238))
- Add support for "sync/watchlist/reorder" POST request ([Issue 239](https://github.com/henrikfroehling/Trakt.NET/issues/239))
- Add property "updated_at" in `ITraktSeason` ([Issue 242](https://github.com/henrikfroehling/Trakt.NET/issues/242))
- Update `ITraktSyncLastActivities` and add missing properties ([Issue 257](https://github.com/henrikfroehling/Trakt.NET/issues/257))
- Add support for comments (blocked users) in "users/hidden/{section}" and "users/hidden/{section}/remove" POST requests ([Issue 258](https://github.com/henrikfroehling/Trakt.NET/issues/258))
- Add values "continuing" and "pilot" in `TraktShowStatus` enumeration ([Issue 264](https://github.com/henrikfroehling/Trakt.NET/issues/264))
- Add support for "shows/{id}/seasons/{season}/translations/{language}" GET request ([Issue 265](https://github.com/henrikfroehling/Trakt.NET/issues/265))
- Add missing properties in `ITraktPerson` ([Issue 266](https://github.com/henrikfroehling/Trakt.NET/issues/266))

Fixed:

- `GetShowAsync` returns Status null when status is 'upcoming' ([Issue 208](https://github.com/henrikfroehling/Trakt.NET/issues/208))
- Calendar methods do not accept a value greater than 31 for days ([Issue 220](https://github.com/henrikfroehling/Trakt.NET/issues/220))
- `GetShowAsync` returns Status null when status is 'planned' ([Issue 221](https://github.com/henrikfroehling/Trakt.NET/issues/221))

Improved:

- Handle HTTP Status Code 423 for locked user accounts ([Issue 194](https://github.com/henrikfroehling/Trakt.NET/issues/194))
- Post Builder interfaces and implementations are not in the same namespace ([Issue 207](https://github.com/henrikfroehling/Trakt.NET/issues/207))

Changed:

- OAuth authorization for "users/{id}/lists/{list_id}/comments" should be optional ([Issue 197](https://github.com/henrikfroehling/Trakt.NET/issues/197))
- Rename methods in post builder ([Issue 251](https://github.com/henrikfroehling/Trakt.NET/issues/251))
- Change OAuth requirement to optional for "users/{id}/likes/{type}" GET request ([Issue 256](https://github.com/henrikfroehling/Trakt.NET/issues/256))

---------

Version 1.1.1
===

#### 1.1.1
(2021-03-16)

Fixed:

- GetShowAsync returns Status null when status is 'upcoming' ([Issue 208](https://github.com/henrikfroehling/Trakt.NET/issues/208))
- GetShowAsync returns Status null when status is 'planned' ([Issue 221](https://github.com/henrikfroehling/Trakt.NET/issues/221))
- Calendar methods do not accept a value greater than 31 for days ([Issue 220](https://github.com/henrikfroehling/Trakt.NET/issues/220))

---------

Version 1.1.0
===

#### 1.1.0
(2020-10-23)

Added:

- Add support for "users/{username}/lists/reorder" POST request ([Issue 59](https://github.com/henrikfroehling/Trakt.NET/issues/59))
- Add support for "users/{username}/lists/{list_id}/items/reorder" POST request ([Issue 66](https://github.com/henrikfroehling/Trakt.NET/issues/66))
- Add support for "date_format" property in ITraktAccountSettings ([Issue 67](https://github.com/henrikfroehling/Trakt.NET/issues/67))
- Add support for "last_updated_at" property in "ITraktWatchedShow" ([Issue 68](https://github.com/henrikfroehling/Trakt.NET/issues/68))
- Add support for "last_updated_at" property in "ITraktCollectionShow" ([Issue 69](https://github.com/henrikfroehling/Trakt.NET/issues/69))
- Add support for "countries/{type}" GET request ([Issue 76](https://github.com/henrikfroehling/Trakt.NET/issues/76))
- Add support for "languages/{type}" GET request ([Issue 77](https://github.com/henrikfroehling/Trakt.NET/issues/77))
- Add support for "updated_at" property in "ITraktCollectionMovie" ([Issue 78](https://github.com/henrikfroehling/Trakt.NET/issues/78))
- Add support for "last_updated_at" property in "ITraktWatchedMovie" ([Issue 79](https://github.com/henrikfroehling/Trakt.NET/issues/79))
- Add support for absolute episode numbers in "/checkin" POST request ([Issue 81](https://github.com/henrikfroehling/Trakt.NET/issues/81))
- Add support for absolute episode numbers in "/scrobble" POST request ([Issue 82](https://github.com/henrikfroehling/Trakt.NET/issues/82))
- Add support for "last_activity" flag in "shows/{id}/progress/collection" GET request ([Issue 83](https://github.com/henrikfroehling/Trakt.NET/issues/83))
- Add support for "last_activity" flag in "shows/{id}/progress/watched" GET request ([Issue 84](https://github.com/henrikfroehling/Trakt.NET/issues/84))
- Add support for "include_replies=only" flag in "users/{username}/comments" GET request ([Issue 85](https://github.com/henrikfroehling/Trakt.NET/issues/85))
- Add support for "ignore_collected" flag in "recommendations/movies" GET request ([Issue 104](https://github.com/henrikfroehling/Trakt.NET/issues/104))
- Add support for "ignore_collected" flag in "recommendations/shows" GET request ([Issue 105](https://github.com/henrikfroehling/Trakt.NET/issues/105))
- Add support for "reset_at" flag in "sync/watched/shows" GET request ([Issue 126](https://github.com/henrikfroehling/Trakt.NET/issues/126))
- Add support for "reset_at" flag in "users/{username}/watched/shows" GET request ([Issue 127](https://github.com/henrikfroehling/Trakt.NET/issues/127))
- Add support for pagination for "sync/ratings" GET request ([Issue 128](https://github.com/henrikfroehling/Trakt.NET/issues/128))
- Add support for pagination for "users/{username}/ratings" GET request ([Issue 129](https://github.com/henrikfroehling/Trakt.NET/issues/129))
- Add support for new response headers "X-Applied-Sort-By" and "X-Applied-Sort-How" ([Issue 136](https://github.com/henrikfroehling/Trakt.NET/issues/136))
- Add support for sorting in "sync/watchlist" GET request ([Issue 137](https://github.com/henrikfroehling/Trakt.NET/issues/137))
- Add support for sorting in "users/{username}/watchlist/" GET request ([Issue 138](https://github.com/henrikfroehling/Trakt.NET/issues/138))
- Add support for "uuid" property in ITraktUserIds ([Issue 162](https://github.com/henrikfroehling/Trakt.NET/issues/162))
- Add support for "users/{id}/recommendations/{type}/{sort}" GET request ([Issue 166](https://github.com/henrikfroehling/Trakt.NET/issues/166))
- Add support for "status" property in ITraktMovie ([Issue 175](https://github.com/henrikfroehling/Trakt.NET/issues/175))

Fixed:

- Merge GH-94: Redundant checks for ITraktMovie properties in TraktScrobbleModule ([Issue 95](https://github.com/henrikfroehling/Trakt.NET/issues/95))
- Missing properties in ITraktMetadata ([Issue 98](https://github.com/henrikfroehling/Trakt.NET/issues/98))
- Adding GuestStars as ExtendedInfo when calling GetEpisodePeopleAsync does not return the guest starts ([Issue 184](https://github.com/henrikfroehling/Trakt.NET/issues/184))
- Return same instance type for people requests in Episodes, Shows and Seasons module ([Issue 185](https://github.com/henrikfroehling/Trakt.NET/issues/185))

Improved:

- Improve post request builder ([Issue 5](https://github.com/henrikfroehling/Trakt.NET/issues/5))
- Improve / replace UriTemplate implementation ([Issue 58](https://github.com/henrikfroehling/Trakt.NET/issues/58))
- Improve implementation of filters ([Issue 74](https://github.com/henrikfroehling/Trakt.NET/issues/74))
- Improve JSON reader implementation ([Issue 143](https://github.com/henrikfroehling/Trakt.NET/issues/143))

Removed:

- Remove Facebook sharing ([Issue 55](https://github.com/henrikfroehling/Trakt.NET/issues/55))
- Remove prefix "X" from property names in ITraktResponseHeaders ([Issue 135](https://github.com/henrikfroehling/Trakt.NET/issues/135))
- Remove deprecated properties due to new people methods ([Issue 142](https://github.com/henrikfroehling/Trakt.NET/issues/142))

---------

Version 1.0.2
===

#### 1.0.2
(2020-08-18)

Fixed:

- Exception when $Object.Year is not valid when adding to a UserCustomList ([Issue 173](https://github.com/henrikfroehling/Trakt.NET/issues/173))

---------

Version 1.0.1
===

#### 1.0.1
(2020-07-09)

Fixed:

- Fix wrongly thrown exception, when authorization is optional ([Issue 154](https://github.com/henrikfroehling/Trakt.NET/issues/154))

---------

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
- Split up test project in multiple test projects (release) ([Issue 107](https://github.com/henrikfroehling/Trakt.NET/issues/107))
- Split up TraktNET.Objects.Tests in multiple test projects (release) ([Issue 117](https://github.com/henrikfroehling/TraktApiSharp/issues/117))

Added:
- Add support for new people methods ([Issue 125](https://github.com/henrikfroehling/Trakt.NET/issues/125))

Improved:

- Source Code Documentation ([Issue 28](https://github.com/henrikfroehling/Trakt.NET/issues/28))
- Improve / replace UriTemplate implementation (release) ([Issue 121](https://github.com/henrikfroehling/Trakt.NET/issues/121))
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

- Rename library / project / repository to "Trakt.NET" ([Issue 3](https://github.com/henrikfroehling/Trakt.NET/issues/3))
- Move all examples into their own repository ([Issue 57](https://github.com/henrikfroehling/TraktApiSharp/issues/57))

Added:

- Add missing "token" property in ITraktAccountSettings ([Issue 27](https://github.com/henrikfroehling/Trakt.NET/issues/27))
- Add missing filter support for text query search ([Issue 72](https://github.com/henrikfroehling/Trakt.NET/issues/72))

Fixed:

- Fix serialization service ([Issue 23](https://github.com/henrikfroehling/Trakt.NET/issues/23))
- post builder feature: add support for posting collected episodes without ids ([Issue 30](https://github.com/henrikfroehling/Trakt.NET/issues/30))
- Implement missing json object and array reader ([Issue 33](https://github.com/henrikfroehling/Trakt.NET/issues/33))
- Implement missing json object and array writer ([Issue 34](https://github.com/henrikfroehling/Trakt.NET/issues/34))
- Fix post builder for sync collection post ([Issue 35](https://github.com/henrikfroehling/Trakt.NET/issues/35))
- Refreshing authorization not working with expired or invalid access token ([Issue 36](https://github.com/henrikfroehling/Trakt.NET/issues/36))
- Revoking authorization not working with expired or invalid access token ([Issue 37](https://github.com/henrikfroehling/Trakt.NET/issues/37))
- Wrong type assignment for lists ([Issue 61](https://github.com/henrikfroehling/Trakt.NET/issues/61))
- Bad Request when adding items to a list ([Issue 62](https://github.com/henrikfroehling/Trakt.NET/issues/62))
- Exception when search text query is empty ([Issue 64](https://github.com/henrikfroehling/Trakt.NET/issues/64))
- Invalid implementation for Networks / List / Get networks ([Issue 65](https://github.com/henrikfroehling/Trakt.NET/issues/65))
- Redundant checks for ITraktMovie properties in TraktScrobbleModule ([Issue 94](https://github.com/henrikfroehling/Trakt.NET/issues/94))

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
