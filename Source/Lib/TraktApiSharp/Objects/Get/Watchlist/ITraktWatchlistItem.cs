namespace TraktApiSharp.Objects.Get.Watchlist
{
    using Enums;
    using Episodes;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    public interface ITraktWatchlistItem
    {
        DateTime? ListedAt { get; set; }

        TraktSyncItemType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }

        ITraktEpisode Episode { get; set; }
    }
}
