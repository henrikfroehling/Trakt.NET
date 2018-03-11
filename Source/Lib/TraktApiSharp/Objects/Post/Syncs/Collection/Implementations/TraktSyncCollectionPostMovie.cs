namespace TraktApiSharp.Objects.Post.Syncs.Collection.Implementations
{
    using Basic;
    using Get.Movies;
    using System;

    /// <summary>
    /// A Trakt collection post movie, containing the required movie ids,
    /// optional metadata and an optional datetime, when the movie was collected.
    /// </summary>
    public class TraktSyncCollectionPostMovie : ITraktSyncCollectionPostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }

        /// <summary>
        /// Gets or sets optional metadata about the Trakt movie. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMetadata Metadata { get; set; }
    }
}
