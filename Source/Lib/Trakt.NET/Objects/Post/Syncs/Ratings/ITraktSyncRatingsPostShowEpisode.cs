namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using System;

    public interface ITraktSyncRatingsPostShowEpisode
    {
        DateTime? RatedAt { get; set; }

        int? Rating { get; set; }

        int Number { get; set; }
    }
}
