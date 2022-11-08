namespace TraktNet.PostBuilder
{
    using System;

    /// <summary>
    /// Contains a season number and an optional datetime, when it was watched.
    /// <para>Can also contain an optional list of episodes numbers.</para>
    /// </summary>
    public sealed class PostHistorySeason
    {
        /// <summary>Gets the number of this season.</summary>
        public int Number { get; }

        /// <summary>Gets the optional UTC datetime, when this season was watched.</summary>
        public DateTime? WatchedAt { get; }

        /// <summary>Gets a list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</summary>
        public PostHistoryEpisodes Episodes { get; }

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostHistorySeason(int number) => Number = number;

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public PostHistorySeason(int number, PostHistoryEpisodes episodes)
            : this(number)
            => Episodes = episodes;

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="watchedAt">An UTC datetime, when this season was watched.</param>
        public PostHistorySeason(int number, DateTime watchedAt)
            : this(number)
            => WatchedAt = watchedAt.ToUniversalTime();

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="watchedAt">An UTC datetime, when this season was watched.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public PostHistorySeason(int number, DateTime watchedAt, PostHistoryEpisodes episodes)
            : this(number)
        {
            WatchedAt = watchedAt.ToUniversalTime();
            Episodes = episodes;
        }
    }
}
