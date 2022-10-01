namespace TraktNet.Objects.Post
{
    using System;
    using TraktNet.Objects.Basic;

    /// <summary>
    /// Contains a season number, optional metadata and an optional datetime, when it was collected.
    /// <para>Can also contain an optional list of episodes numbers.</para>
    /// </summary>
    public sealed class PostCollectionSeason
    {
        /// <summary>Gets the number of this season.</summary>
        public int Number { get; }

        /// <summary>Gets the metadata of this season.</summary>
        public ITraktMetadata Metadata { get; }

        /// <summary>Gets the optional UTC datetime, when this season was collected.</summary>
        public DateTime? CollectedAt { get; }

        /// <summary>Gets a list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</summary>
        public PostCollectionEpisodes Episodes { get; }

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostCollectionSeason(int number) => Number = number;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public PostCollectionSeason(int number, PostCollectionEpisodes episodes)
            : this(number)
            => Episodes = episodes;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="collectedAt">An UTC datetime, when this season was collected.</param>
        public PostCollectionSeason(int number, DateTime collectedAt)
            : this(number)
            => CollectedAt = collectedAt.ToUniversalTime();

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="collectedAt">An UTC datetime, when this season was collected.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public PostCollectionSeason(int number, DateTime collectedAt, PostCollectionEpisodes episodes)
            : this(number, collectedAt)
            => Episodes = episodes;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="metadata">The metadata of this season.</param>
        public PostCollectionSeason(int number, ITraktMetadata metadata)
            : this(number)
            => Metadata = metadata;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="metadata">The metadata of this season.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public PostCollectionSeason(int number, ITraktMetadata metadata, PostCollectionEpisodes episodes)
            : this(number, metadata)
            => Episodes = episodes;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="metadata">The metadata of this season.</param>
        /// <param name="collectedAt">An UTC datetime, when this season was collected.</param>
        public PostCollectionSeason(int number, ITraktMetadata metadata, DateTime collectedAt)
            : this(number, metadata)
            => CollectedAt = collectedAt.ToUniversalTime();

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="metadata">The metadata of this season.</param>
        /// <param name="collectedAt">An UTC datetime, when this season was collected.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public PostCollectionSeason(int number, ITraktMetadata metadata, DateTime collectedAt, PostCollectionEpisodes episodes)
            : this(number, metadata, collectedAt)
            => Episodes = episodes;
    }
}
