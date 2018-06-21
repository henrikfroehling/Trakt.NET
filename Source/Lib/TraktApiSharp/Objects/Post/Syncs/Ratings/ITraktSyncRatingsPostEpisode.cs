namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Episodes;
    using System;

    public interface ITraktSyncRatingsPostEpisode
    {
        DateTime? RatedAt { get; set; }

        int? Rating { get; set; }

        ITraktEpisodeIds Ids { get; set; }
    }
}
