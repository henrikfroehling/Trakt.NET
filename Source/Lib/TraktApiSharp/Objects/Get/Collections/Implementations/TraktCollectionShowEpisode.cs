namespace TraktApiSharp.Objects.Get.Collections
{
    using Basic;
    using System;

    /// <summary>Contains information about a collected Trakt episode.</summary>
    public class TraktCollectionShowEpisode : ITraktCollectionShowEpisode
    {
        /// <summary>Gets or sets the number of the collected episode.</summary>
        public int? Number { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected episode. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMetadata Metadata { get; set; }
    }
}
