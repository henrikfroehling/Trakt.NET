namespace TraktNet.Objects.Post
{
    using System;

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
}
