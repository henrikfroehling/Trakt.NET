namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Attributes;
    using Basic;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt collection post episode, containing the required episode ids,
    /// optional metadata and an optional datetime, when the episode was collected.
    /// </summary>
    public class TraktSyncCollectionPostEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }

        /// <summary>
        /// Gets or sets optional metadata about the Trakt episode. See also <seealso cref="TraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
