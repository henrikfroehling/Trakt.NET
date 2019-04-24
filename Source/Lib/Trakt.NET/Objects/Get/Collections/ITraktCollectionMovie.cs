namespace TraktNet.Objects.Get.Collections
{
    using Basic;
    using Movies;
    using System;

    /// <summary>Contains information about a collected Trakt movie.</summary>
    public interface ITraktCollectionMovie : ITraktMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the movie was collected.</summary>
        DateTime? CollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected Trakt movie. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected movie. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMetadata Metadata { get; set; }
    }
}
