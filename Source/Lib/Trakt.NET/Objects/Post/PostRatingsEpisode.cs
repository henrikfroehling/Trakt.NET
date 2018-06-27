namespace TraktNet.Objects.Post
{
    using System;

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
