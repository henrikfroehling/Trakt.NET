namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Basic;

    /// <summary>Contains an episode number, optional metadata and an optional datetime, when it was collected</summary>
    public sealed class PostCollectionEpisode
    {
        /// <summary>Gets the number of this episode.</summary>
        public int Number { get; }

        /// <summary>Gets the metadata of this episode.</summary>
        public ITraktMetadata Metadata { get; }

        /// <summary>Gets the optional UTC datetime, when this episode was collected.</summary>
        public DateTime? CollectedAt { get; }

        /// <summary>Initializes a new instance of the <see cref="PostCollectionEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        public PostCollectionEpisode(int number) => Number = number;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="collectedAt">The UTC datetime, when this episode was collected.</param>
        public PostCollectionEpisode(int number, DateTime collectedAt)
            : this(number)
            => CollectedAt = collectedAt.ToUniversalTime();

        /// <summary>Initializes a new instance of the <see cref="PostCollectionEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="metadata">The metadata of this episode.</param>
        public PostCollectionEpisode(int number, ITraktMetadata metadata)
            : this(number)
            => Metadata = metadata;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="metadata">The metadata of this episode.</param>
        /// <param name="collectedAt">The UTC datetime, when this episode was collected.</param>
        public PostCollectionEpisode(int number, ITraktMetadata metadata, DateTime collectedAt)
            : this(number, metadata)
            => CollectedAt = collectedAt.ToUniversalTime();
    }
}
