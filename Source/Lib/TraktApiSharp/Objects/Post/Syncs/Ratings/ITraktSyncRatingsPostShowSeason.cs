namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using System;
    using System.Collections.Generic;

    public interface ITraktSyncRatingsPostShowSeason
    {
        DateTime? RatedAt { get; set; }

        int? Rating { get; set; }

        int Number { get; set; }

        IEnumerable<ITraktSyncRatingsPostShowEpisode> Episodes { get; set; }
    }
}
