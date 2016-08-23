namespace TraktApiSharp.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of season and episode numbers.
    /// <para>Can also contain watched datetimes for each season and episode number.</para>
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new PostHistorySeasons
    /// {
    ///     1,
    ///     { 2 },
    ///     { 3, DateTime.Now },
    ///     { 4, new PostHistoryEpisodes { 1 } },
    ///     { 5, DateTime.Now, new PostHistoryEpisodes { 2 } },
    ///     { 6, new PostHistoryEpisodes { 1, 2, 3 } },
    ///     { 7, DateTime.Now, new PostHistoryEpisodes { 1, 2, 3 } },
    ///     { 8, new PostHistoryEpisodes
    ///         {
    ///             { 1, DateTime.Now }
    ///         }
    ///     },
    ///     { 9, DateTime.Now, new PostHistoryEpisodes
    ///         {
    ///             { 2, DateTime.Now  }
    ///         }
    ///     },
    ///     { 10, new PostHistoryEpisodes
    ///         {
    ///             { 1, DateTime.Now },
    ///             2,
    ///             { 3, DateTime.Now }
    ///         }
    ///     },
    ///     { 11, DateTime.Now, new PostHistoryEpisodes
    ///         {
    ///             { 2, DateTime.Now  },
    ///             { 3 },
    ///             4
    ///         }
    ///     },
    /// };
    /// </code>
    /// </example>
    public sealed class PostHistorySeasons : IEnumerable<PostHistorySeason>
    {
        private readonly List<PostHistorySeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeasons" /> class.</summary>
        public PostHistorySeasons()
        {
            _seasons = new List<PostHistorySeason>();
        }

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        public void Add(int season) => _seasons.Add(new PostHistorySeason(season));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="watchedAt">An UTC datetime, when the season was watched.</param>
        public void Add(int season, DateTime watchedAt) => _seasons.Add(new PostHistorySeason(season, watchedAt));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="watchedAt">An UTC datetime, when the season was watched.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public void Add(int season, DateTime watchedAt, PostHistoryEpisodes episodes) => _seasons.Add(new PostHistorySeason(season, watchedAt, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public void Add(int season, PostHistoryEpisodes episodes) => _seasons.Add(new PostHistorySeason(season, null, episodes));

        public IEnumerator<PostHistorySeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

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

    /// <summary>
    /// A list of episode numbers.
    /// <para>Each episode number can have an optional datetime, when it was watched.</para>
    /// </summary>
    public sealed class PostHistoryEpisodes : IEnumerable<PostHistoryEpisode>
    {
        private readonly List<PostHistoryEpisode> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostHistoryEpisodes" /> class.</summary>
        public PostHistoryEpisodes()
        {
            _episodes = new List<PostHistoryEpisode>();
        }

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episode">The episode number, which will be added to the list.</param>
        /// <param name="watchedAt">An UTC datetime, when the episode was watched.</param>
        public void Add(int episode, DateTime? watchedAt = null) => Add(new PostHistoryEpisode(episode, watchedAt));

        /// <summary>Adds the given episode numbers to the list.</summary>
        /// <param name="episode">An episode number. See also <see cref="PostHistoryEpisode" />.</param>
        /// <param name="episodes">An optional list of episode numbers. See also <see cref="PostHistoryEpisode" />.</param>
        public void Add(PostHistoryEpisode episode, params PostHistoryEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostHistoryEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>Contains an episode number and an optional datetime, when it was watched.</summary>
    public sealed class PostHistoryEpisode
    {
        /// <summary>Initializes a new instance of the <see cref="PostHistoryEpisode" /> class.</summary>
        public PostHistoryEpisode() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostHistoryEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="watchedAt">The UTC datetime, when this episode was watched.</param>
        public PostHistoryEpisode(int number, DateTime? watchedAt = null)
        {
            Number = number;
            WatchedAt = watchedAt;
        }

        /// <summary>Gets or sets the number of this episode.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when this episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }
    }
}
