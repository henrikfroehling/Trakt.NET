Release notes
=============
---
---

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
