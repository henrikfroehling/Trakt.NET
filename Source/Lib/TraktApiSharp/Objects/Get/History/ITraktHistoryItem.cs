namespace TraktApiSharp.Objects.Get.History
{
    using Enums;
    using Episodes;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    public interface ITraktHistoryItem
    {
        ulong Id { get; set; }

        DateTime? WatchedAt { get; set; }

        TraktHistoryActionType Action { get; set; }

        TraktSyncItemType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }

        ITraktEpisode Episode { get; set; }
    }
}
