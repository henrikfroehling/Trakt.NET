namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Movies;
    using System;

    public interface ITraktSyncCollectionPostMovie : ITraktMetadata
    {
        DateTime? CollectedAt { get; set; }

        string Title { get; set; }

        int? Year { get; set; }

        ITraktMovieIds Ids { get; set; }
    }
}
