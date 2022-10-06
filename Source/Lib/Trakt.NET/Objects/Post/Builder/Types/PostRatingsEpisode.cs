namespace TraktNet.Objects.Post
{
    using System;

    /// <summary>Contains an episode number and rating and an optional datetime, when it was rated.</summary>
    public sealed class PostRatingsEpisode
    {
        /// <summary>Gets the number of this episode.</summary>
        public int Number { get; }

        /// <summary>Gets the rating of this episode.</summary>
        public TraktPostRating Rating { get; }

        /// <summary>Gets the optional UTC datetime, when this episode was rated.</summary>
        public DateTime? RatedAt { get; }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="rating">The rating for this episode.</param>
        public PostRatingsEpisode(int number, TraktPostRating rating)
        {
            Number = number;
            Rating = rating;
        }

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        /// <param name="rating">The rating for this episode.</param>
        /// <param name="ratedAt">The UTC datetime, when this episode was rated.</param>
        public PostRatingsEpisode(int number, TraktPostRating rating, DateTime ratedAt)
            : this(number, rating)
            => RatedAt = ratedAt.ToUniversalTime();
    }
}
