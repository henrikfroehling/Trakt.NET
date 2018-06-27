namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of season and episode numbers.
    /// <para>Can also contain ratings and datetimes of the ratings for each season and episode number.</para>
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new PostRatingsSeasons
    /// {
    ///     1,
    ///     { 2 },
    ///     { 3, 8 },
    ///     { 3, 8, DateTime.Now },
    ///     { 4, new PostRatingsEpisodes { 1 } },
    ///     { 4, 7, new PostRatingsEpisodes { 1 } },
    ///     { 4, 7, DateTime.Now, new PostRatingsEpisodes { 1 } },
    ///     { 5, new PostRatingsEpisodes { 1, 2, 3 } },
    ///     { 5, 9, new PostRatingsEpisodes { 1, 2, 3 } },
    ///     { 5, 9, DateTime.Now, new PostRatingsEpisodes { 1, 2, 3 } },
    ///     { 6, new PostRatingsEpisodes
    ///         {
    ///             1,
    ///             { 2, 8 },
    ///             { 2, 8, DateTime.Now }
    ///         }
    ///     },
    ///     { 6, 10, new PostRatingsEpisodes
    ///         {
    ///             1,
    ///             { 2, 8 },
    ///             { 2, 8, DateTime.Now }
    ///         }
    ///     },
    ///     { 6, 10, DateTime.Now, new PostRatingsEpisodes
    ///         {
    ///             1,
    ///             { 2, 8 },
    ///             { 2, 8, DateTime.Now }
    ///         }
    ///     }
    /// };
    /// </code>
    /// </example>
    public sealed class PostRatingsSeasons : IEnumerable<PostRatingsSeason>
    {
        private readonly List<PostRatingsSeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeasons" /> class.</summary>
        public PostRatingsSeasons()
        {
            _seasons = new List<PostRatingsSeason>();
        }

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        public void Add(int season) => _seasons.Add(new PostRatingsSeason(season));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="rating">A rating for the season number.</param>
        /// <param name="ratedAt">An UTC datetime, when the season was rated.</param>
        public void Add(int season, int rating, DateTime? ratedAt = null) => _seasons.Add(new PostRatingsSeason(season, rating, ratedAt));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="rating">A rating for the season number.</param>
        /// <param name="ratedAt">An UTC datetime, when the season was rated.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</param>
        public void Add(int season, int rating, DateTime ratedAt, PostRatingsEpisodes episodes) => _seasons.Add(new PostRatingsSeason(season, rating, ratedAt, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</param>
        public void Add(int season, PostRatingsEpisodes episodes) => _seasons.Add(new PostRatingsSeason(season, null, null, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="rating">A rating for the season number.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</param>
        public void Add(int season, int rating, PostRatingsEpisodes episodes) => _seasons.Add(new PostRatingsSeason(season, rating, null, episodes));

        public IEnumerator<PostRatingsSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
