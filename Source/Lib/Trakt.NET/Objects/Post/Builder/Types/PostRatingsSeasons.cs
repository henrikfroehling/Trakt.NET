namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection of season and episode numbers.
    /// <para>Contains ratings and datetimes of the ratings for each season and episode number.</para>
    /// </summary>
    public sealed class PostRatingsSeasons : IEnumerable<PostRatingsSeason>
    {
        private readonly List<PostRatingsSeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeasons" /> class.</summary>
        public PostRatingsSeasons() => _seasons = new List<PostRatingsSeason>();

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="rating">A rating for the season number.</param>
        public void Add(int seasonNumber, TraktPostRating rating)
            => Add(new PostRatingsSeason(seasonNumber, rating));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</param>
        public void Add(int seasonNumber, PostRatingsEpisodes episodes)
            => Add(new PostRatingsSeason(seasonNumber, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="rating">A rating for the season number.</param>
        /// <param name="ratedAt">An UTC datetime, when the season was rated.</param>
        public void Add(int seasonNumber, TraktPostRating rating, DateTime ratedAt)
            => Add(new PostRatingsSeason(seasonNumber, rating, ratedAt));

        /// <summary>Adds the given season numbers to the list.</summary>
        /// <param name="season">An season number. See also <see cref="PostRatingsSeason" />.</param>
        /// <param name="seasons">An optional list of season numbers. See also <see cref="PostRatingsSeason" />.</param>
        public void Add(PostRatingsSeason season, params PostRatingsSeason[] seasons)
        {
            _seasons.Add(season);

            if (seasons?.Length > 0)
                _seasons.AddRange(seasons);
        }

        public IEnumerator<PostRatingsSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
