namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Attributes;
    using Basic;
    using Get.Movies;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt collection post movie, containing the required movie ids,
    /// optional metadata and an optional datetime, when the movie was collected.
    /// </summary>
    public class TraktSyncCollectionPostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }

        /// <summary>
        /// Gets or sets optional metadata about the Trakt movie. See also <seealso cref="TraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
