namespace TraktNet.Objects.Get.Collections
{
    using Basic;
    using System;

    /// <summary>Contains information about a collected Trakt episode.</summary>
    public interface ITraktCollectionShowEpisode
    {
        /// <summary>Gets or sets the number of the collected episode.</summary>
        int? Number { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        DateTime? CollectedAt { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected episode. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMetadata Metadata { get; set; }
    }
}
