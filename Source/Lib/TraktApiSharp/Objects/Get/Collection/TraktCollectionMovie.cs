namespace TraktApiSharp.Objects.Get.Collection
{
    using Basic;
    using Movies;
    using Newtonsoft.Json;
    using System;

    /// <summary>Contains information about a collected Trakt movie.</summary>
    public class TraktCollectionMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the movie was collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected Trakt movie. See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected movie. See also <seealso cref="TraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
