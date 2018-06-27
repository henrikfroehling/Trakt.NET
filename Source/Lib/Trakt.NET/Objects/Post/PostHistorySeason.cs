namespace TraktNet.Objects.Post
{
    using System;

    /// <summary>
    /// Contains a season number and an optional datetime, when it was watched.
    /// <para>Can also contain an optional list of episodes numbers.</para>
    /// </summary>
    public sealed class PostHistorySeason
    {
        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        public PostHistorySeason() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostHistorySeason(int number) : this(number, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="watchedAt">An UTC datetime, when this season was watched.</param>
        public PostHistorySeason(int number, DateTime? watchedAt) : this(number, watchedAt, new PostHistoryEpisodes()) { }

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="watchedAt">An UTC datetime, when this season was watched.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public PostHistorySeason(int number, DateTime? watchedAt, PostHistoryEpisodes episodes)
        {
            Number = number;
            WatchedAt = watchedAt;
            Episodes = episodes;
        }

        /// <summary>Gets or sets the number of this season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when this season was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets a list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</summary>
        public PostHistoryEpisodes Episodes { get; set; }
    }
}
