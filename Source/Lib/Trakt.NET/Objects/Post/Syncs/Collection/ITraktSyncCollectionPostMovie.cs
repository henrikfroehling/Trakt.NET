namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Movies;
    using System;

    /// <summary>
    /// A Trakt collection post movie, containing the required movie ids,
    /// optional metadata and an optional datetime, when the movie was collected.
    /// </summary>
    public interface ITraktSyncCollectionPostMovie : ITraktMetadata
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was collected.</summary>
        DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
