namespace TraktNet.Objects.Get.Seasons
{
    using Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktSeason
    {
        int? Number { get; set; }

        string Title { get; set; }

        ITraktSeasonIds Ids { get; set; }

        float? Rating { get; set; }

        int? Votes { get; set; }

        int? TotalEpisodesCount { get; set; }

        int? AiredEpisodesCount { get; set; }

        string Overview { get; set; }

        DateTime? FirstAired { get; set; }

        string Network { get; set; }

        IEnumerable<ITraktEpisode> Episodes { get; set; }

        int? CommentCount { get; set; }
    }
}
