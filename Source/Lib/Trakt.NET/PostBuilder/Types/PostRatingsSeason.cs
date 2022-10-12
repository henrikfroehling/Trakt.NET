namespace TraktNet.PostBuilder
{
    using System;

    /// <summary>
    /// Contains a season number and rating and an optional datetime, when it was rated.
    /// <para>Can also contain an optional list of episodes numbers.</para>
    /// </summary>
    public sealed class PostRatingsSeason
    {
        /// <summary>Gets the number of this season.</summary>
        public int Number { get; }

        /// <summary>Gets the rating of this season.</summary>
        public TraktPostRating? Rating { get; }

        /// <summary>Gets the optional UTC datetime, when this season was rated.</summary>
        public DateTime? RatedAt { get; }

        /// <summary>Gets a list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</summary>
        public PostRatingsEpisodes Episodes { get; }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="rating">A rating for the season.</param>
        public PostRatingsSeason(int number, TraktPostRating rating)
        {
            Number = number;
            Rating = rating;
        }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="episodes">>A list of episode numbers. See also <see cref="PostRatingsEpisodes" />.</param>
        public PostRatingsSeason(int number, PostRatingsEpisodes episodes)
        {
            Number = number;
            Episodes = episodes;
        }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="rating">A rating for the season.</param>
        /// <param name="ratedAt">An UTC datetime, when this season was rated.</param>
        public PostRatingsSeason(int number, TraktPostRating rating, DateTime ratedAt)
            : this(number, rating)
            => RatedAt = ratedAt.ToUniversalTime();
    }
}
