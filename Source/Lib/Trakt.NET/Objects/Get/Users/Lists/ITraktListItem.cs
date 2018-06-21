namespace TraktNet.Objects.Get.Users.Lists
{
    using Enums;
    using Episodes;
    using Movies;
    using People;
    using Seasons;
    using Shows;
    using System;

    public interface ITraktListItem
    {
        string Rank { get; set; }

        DateTime? ListedAt { get; set; }

        TraktListItemType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }

        ITraktEpisode Episode { get; set; }

        ITraktPerson Person { get; set; }
    }
}
