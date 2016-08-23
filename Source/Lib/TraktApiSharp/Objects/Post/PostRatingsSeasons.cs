namespace TraktApiSharp.Objects.Post
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

    /// <summary>
    /// Contains a season number and an optional rating and an optional datetime, when it was rated.
    /// <para>Can also contain an optional list of episodes numbers.</para>
    /// </summary>
    public sealed class PostRatingsSeason
    {
        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        public PostRatingsSeason() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostRatingsSeason(int number) : this(number, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="rating">A rating for the season.</param>
        public PostRatingsSeason(int number, int? rating) : this(number, rating, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="rating">A rating for the season.</param>
        /// <param name="ratedAt">An UTC datetime, when this season was rated.</param>
        public PostRatingsSeason(int number, int? rating, DateTime? ratedAt) : this(number, rating, ratedAt, new PostRatingsEpisodes()) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="rating">A rating for the season.</param>
        /// <param name="ratedAt">An UTC datetime, when this season was rated.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</param>
        public PostRatingsSeason(int number, int? rating, DateTime? ratedAt, PostRatingsEpisodes episodes)
        {
            Number = number;
            Rating = rating;
            RatedAt = ratedAt;
            Episodes = episodes;
        }

        /// <summary>Gets or sets the number of this season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the optional rating of this season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when this season was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets a list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</summary>
        public PostRatingsEpisodes Episodes { get; set; }
    }

    /// <summary>
    /// A list of episode numbers.
    /// <para>Each episode number can have an optional rating and an optional datetime, when it was rated.</para>
    /// </summary>
    public sealed class PostRatingsEpisodes : IEnumerable<PostRatingsEpisode>
    {
        private readonly List<PostRatingsEpisode> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisodes" /> class.</summary>
        public PostRatingsEpisodes()
        {
            _episodes = new List<PostRatingsEpisode>();
        }

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episode">The episode number, which will be added to the list.</param>
        public void Add(int episode) => _episodes.Add(new PostRatingsEpisode(episode));

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episode">The episode number, which will be added to the list.</param>
        /// <param name="rating">A rating for the episode.</param>
        /// <param name="ratedAt">An UTC datetime, when the episode was rated.</param>
        public void Add(int episode, int rating, DateTime? ratedAt = null) => _episodes.Add(new PostRatingsEpisode(episode, rating, ratedAt));

        public void Add(PostRatingsEpisode episode, params PostRatingsEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostRatingsEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>Contains an episode number and an optional rating and an optional datetime, when it was rated.</summary>
    public sealed class PostRatingsEpisode
    {
        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisode" /> class.</summary>
        public PostRatingsEpisode() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        public PostRatingsEpisode(int number) : this(number, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="rating">The rating for this episode.</param>
        public PostRatingsEpisode(int number, int? rating) : this(number, rating, null) { }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="rating">The rating for this episode.</param>
        /// <param name="ratedAt">The UTC datetime, when this episode was rated.</param>
        public PostRatingsEpisode(int number, int? rating, DateTime? ratedAt)
        {
            Number = number;
            Rating = rating;
            RatedAt = ratedAt;
        }

        /// <summary>Gets or sets the number of this episode.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the optional rating of this episode.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when this episode was rated.</summary>
        public DateTime? RatedAt { get; set; }
    }
}
