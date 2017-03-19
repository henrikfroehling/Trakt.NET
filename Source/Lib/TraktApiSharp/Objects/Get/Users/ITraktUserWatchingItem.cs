namespace TraktApiSharp.Objects.Get.Users
{
    using Enums;
    using Episodes;
    using Movies;
    using Shows;
    using System;

    public interface ITraktUserWatchingItem
    {
        DateTime? StartedAt { get; set; }

        DateTime? ExpiresAt { get; set; }

        TraktHistoryActionType Action { get; set; }

        TraktSyncType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktEpisode Episode { get; set; }
    }
}
