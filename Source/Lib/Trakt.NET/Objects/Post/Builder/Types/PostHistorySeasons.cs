namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of season and episode numbers.
    /// <para>Can also contain watched datetimes for each season and episode number.</para>
    /// </summary>
    public sealed class PostHistorySeasons : IEnumerable<PostHistorySeason>
    {
        private readonly List<PostHistorySeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostHistorySeasons" /> class.</summary>
        public PostHistorySeasons() => _seasons = new List<PostHistorySeason>();

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        public void Add(int season)
            => Add(new PostHistorySeason(season));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public void Add(int season, PostHistoryEpisodes episodes)
            => Add(new PostHistorySeason(season, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="watchedAt">An UTC datetime, when the season was watched.</param>
        public void Add(int season, DateTime watchedAt)
            => Add(new PostHistorySeason(season, watchedAt));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="watchedAt">An UTC datetime, when the season was watched.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostHistoryEpisodes" />.</param>
        public void Add(int season, DateTime watchedAt, PostHistoryEpisodes episodes)
            => Add(new PostHistorySeason(season, watchedAt, episodes));

        /// <summary>Adds the given season numbers to the list.</summary>
        /// <param name="season">An season number. See also <see cref="PostHistorySeason" />.</param>
        /// <param name="seasons">An optional list of season numbers. See also <see cref="PostHistorySeason" />.</param>
        public void Add(PostHistorySeason season, params PostHistorySeason[] seasons)
        {
            _seasons.Add(season);

            if (seasons?.Length > 0)
                _seasons.AddRange(seasons);
        }

        public IEnumerator<PostHistorySeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
