# Namespaces

This is an overview of all namespaces in the **Trakt.NET** library.

| Namespace | Contents |
| ---------- | -------- |
| [`TraktNet`](xref:TraktNet) | Global namespace containing the [`TraktClient`](xref:TraktNet.TraktClient) .|
| [`TraktNet.Enums`](xref:TraktNet.Enums) | Contains all enumerations.|
| [`TraktNet.Exceptions`](xref:TraktNet.Exceptions) | Contains all exceptions.|
| [`TraktNet.Extensions`](xref:TraktNet.Extensions) | Contains extension methods for [`DateTime`](https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-7.0) and [`string`](https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-7.0).|
| [`TraktNet.Modules`](xref:TraktNet.Modules) | Contains all library modules for accessing the Trakt API endpoints.|
| [`TraktNet.Objects.Authentication`](xref:TraktNet.Objects.Authentication) | Contains all classes, which represent JSON objects, that are mainly used by for authentication and authorization.|
| [`TraktNet.Objects.Basic`](xref:TraktNet.Objects.Basic) | Contains all classes, which represent JSON objects, that are commonly used.|
| [`TraktNet.Objects.Get.Calendars`](xref:TraktNet.Objects.Get.Calendars) | Contains all classes, which represent JSON objects, that are related to calendar methods.|
| [`TraktNet.Objects.Get.Collections`](xref:TraktNet.Objects.Get.Collections) | Contains all classes, which represent JSON objects, that are related to collections.|
| [`TraktNet.Objects.Get.Episodes`](xref:TraktNet.Objects.Get.Episodes) | Contains all classes, which represent JSON objects, that are related to episodes.|
| [`TraktNet.Objects.Get.History`](xref:TraktNet.Objects.Get.History) | Contains all classes, which represent JSON objects, that are related to history methods.|
| [`TraktNet.Objects.Get.Lists`](xref:TraktNet.Objects.Get.Lists) | Contains all classes, which represent JSON objects, that are related to lists.|
| [`TraktNet.Objects.Get.Movies`](xref:TraktNet.Objects.Get.Movies) | Contains all classes, which represent JSON objects, that are related to movies.|
| [`TraktNet.Objects.Get.People`](xref:TraktNet.Objects.Get.People) | Contains all classes, which represent JSON objects, that are related to people.|
| [`TraktNet.Objects.Get.Ratings`](xref:TraktNet.Objects.Get.Ratings) | Contains all classes, which represent JSON objects, that are related to ratings.|
| [`TraktNet.Objects.Get.Seasons`](xref:TraktNet.Objects.Get.Seasons) | Contains all classes, which represent JSON objects, that are related to seasons.|
| [`TraktNet.Objects.Get.Shows`](xref:TraktNet.Objects.Get.Shows) | Contains all classes, which represent JSON objects, that are returned by the Trakt API.|
| [`TraktNet.Objects.Get.Activities`](xref:TraktNet.Objects.Get.Syncs.Activities) and [`TraktNet.Objects.Get.Playback`](xref:TraktNet.Objects.Get.Syncs.Playback) | Contains all classes, which represent JSON objects, that are related to activities and playback in the sync module.|
| [`TraktNet.Objects.Get.Users`](xref:TraktNet.Objects.Get.Users) | Contains all classes, which represent JSON objects, that are related to users.|
| [`TraktNet.Objects.Get.Watched`](xref:TraktNet.Objects.Get.Watched) | Contains all classes, which represent JSON objects, that are related to watched shows and movies.|
| [`TraktNet.Objects.Get.Watchlist`](xref:TraktNet.Objects.Get.Watchlist) | Contains all classes, which represent JSON objects, that are related to watchlist methods.|
| [`TraktNet.Objects.Post.Basic`](xref:TraktNet.Objects.Post.Basic) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are commonly used. |
| [`TraktNet.Objects.Post.Checkins`](xref:TraktNet.Objects.Post.Checkins) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are related to checkin requests. |
| [`TraktNet.Objects.Post.Comments`](xref:TraktNet.Objects.Post.Comments) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are related to comment requests. |
| [`TraktNet.Objects.Post.Responses`](xref:TraktNet.Objects.Post.Responses) | Contains commonly used response objects used by post requests. |
| [`TraktNet.Objects.Post.Scrobbles`](xref:TraktNet.Objects.Post.Scrobbles) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are related to scrobble requests. |
| [`TraktNet.Objects.Post.Shows`](xref:TraktNet.Objects.Post.Shows) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are related to show watched requests. |
| [`TraktNet.Objects.Post.Syncs.Collection`](xref:TraktNet.Objects.Post.Syncs.Collection), [`TraktNet.Objects.Post.Syncs.History`](xref:TraktNet.Objects.Post.Syncs.History), [`TraktNet.Objects.Post.Syncs.Ratings`](xref:TraktNet.Objects.Post.Syncs.Ratings), [`TraktNet.Objects.Post.Syncs.Recommendations`](xref:TraktNet.Objects.Post.Syncs.Recommendations), [`TraktNet.Objects.Post.Syncs.Responses`](xref:TraktNet.Objects.Post.Syncs.Responses) and [`TraktNet.Objects.Post.Syncs.Watchlist`](xref:TraktNet.Objects.Post.Syncs.Watchlist) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are related to sync requests. |
| [`TraktNet.Objects.Post.Users`](xref:TraktNet.Objects.Post.Users) | Contains all classes, which represent JSON objects, that can be sent to the Trakt API, that are related to user requests. |
| [`TraktNet.Parameters`](xref:TraktNet.Parameters) | Contains request parameters like [`TraktExtendedInfo`](xref:TraktNet.Parameters.TraktExtendedInfo), [`TraktPagedParameters`](xref:TraktNet.Parameters.TraktPagedParameters) and filters. |
| [`TraktNet.PostBuilder`](xref:TraktNet.PostBuilder) | Contains helper classes for building post objects, which are mainly used in the sync and the users module. |
| [`TraktNet.Responses`](xref:TraktNet.Responses) | Contains response classes like [`TraktResponse`](xref:TraktNet.Responses.TraktResponse`1), [`TraktListResponse`](xref:TraktNet.Responses.TraktListResponse`1) and [`TraktPagedResponse`](xref:TraktNet.Responses.TraktPagedResponse`1). |
| [`TraktNet.Services`](xref:TraktNet.Services) | Contains Serialization- and Language-Service. |
| [`TraktNet.Utils`](xref:TraktNet.Utils) | Contains the utility classes [`Pair`](xref:TraktNet.Utils.Pair`2) and [`Range`](xref:TraktNet.Utils.Range`1).|
