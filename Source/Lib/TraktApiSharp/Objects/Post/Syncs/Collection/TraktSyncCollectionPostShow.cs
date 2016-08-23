namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Attributes;
    using Basic;
    using Get.Shows;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt collection post show, containing the required show ids,
    /// optional metadata and an optional datetime, when the show was collected.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktSyncCollectionPostShow
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt show was collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the collection.
        /// Otherwise, only the specified seasons and / or episodes will be added to the collection.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncCollectionPostShowSeason> Seasons { get; set; }

        /// <summary>
        /// Gets or sets optional metadata about the Trakt show. See also <seealso cref="TraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
