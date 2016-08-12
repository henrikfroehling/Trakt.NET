namespace TraktApiSharp.Objects.Get.Collection
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;
    using System;

    /// <summary>Contains information about a collected Trakt episode.</summary>
    public class TraktCollectionShowEpisode
    {
        /// <summary>Gets or sets the number of the collected episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected episode. See also <seealso cref="TraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
