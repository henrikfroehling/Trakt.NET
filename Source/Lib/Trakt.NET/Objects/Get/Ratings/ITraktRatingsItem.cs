namespace TraktNet.Objects.Get.Ratings
{
    using Enums;
    using Episodes;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    public interface ITraktRatingsItem
    {
        DateTime? RatedAt { get; set; }

        int? Rating { get; set; }

        TraktRatingsItemType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }

        ITraktEpisode Episode { get; set; }
    }
}
