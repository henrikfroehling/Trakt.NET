namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using System;

    public interface ITraktSyncHistoryPostMovie
    {
        DateTime? WatchedAt { get; set; }

        string Title { get; set; }

        int? Year { get; set; }

        ITraktMovieIds Ids { get; set; }
    }
}
