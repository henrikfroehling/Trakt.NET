namespace TraktNet.PostBuilder
{
    using Objects.Basic;
    using System;

    /// <summary>Contains an episode number, optional metadata about the episode and an optional datetime.</summary>
    public sealed class PostEpisodeOld
    {
        /// <summary>Initializes a new instance of the <see cref="PostEpisodeOld" /> class.</summary>
        public PostEpisodeOld() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostEpisodeOld" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        public PostEpisodeOld(int number) : this(number, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostEpisodeOld" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="metadata">Metadata about the episode.</param>
        public PostEpisodeOld(int number, ITraktMetadata metadata) : this(number, metadata, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostEpisodeOld" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="metadata">Metadata about the episode.</param>
        /// <param name="at">An UTC datetime.</param>
        public PostEpisodeOld(int number, ITraktMetadata metadata, DateTime? at)
        {
            Number = number;
            Metadata = metadata;
            At = at;
        }

        /// <summary>Gets or sets the number of this episode.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the metadata of this episode.</summary>
        public ITraktMetadata Metadata { get; set; }

        /// <summary>Gets or sets a UTC datetime of this episode.</summary>
        public DateTime? At { get; set; }
    }
}
