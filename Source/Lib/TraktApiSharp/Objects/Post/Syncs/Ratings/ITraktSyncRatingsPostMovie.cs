namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Get.Movies;
    using System;

    public interface ITraktSyncRatingsPostMovie
    {
        DateTime? RatedAt { get; set; }

        int? Rating { get; set; }

        string Title { get; set; }

        int? Year { get; set; }

        ITraktMovieIds Ids { get; set; }
    }
}
