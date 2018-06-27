namespace TraktNet.Objects.Post
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
}
