namespace TraktNet.Objects.Post
{
    using System;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    public abstract class RatingsEntry<T>
    {
        public T Object { get; }

        public TraktPostRating Rating { get; }

        protected RatingsEntry(T obj, TraktPostRating rating)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Rating = rating;
        }
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with rating.</summary>
    public class RatingsMovie : RatingsEntry<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsMovie" /> class.</summary>
        /// <param name="movie">A <see cref="ITraktMovie"/>.</param>
        /// <param name="rating">The rating for the <paramref name="movie"/>.</param>
        public RatingsMovie(ITraktMovie movie, TraktPostRating rating)
            : base(movie, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with rating.</summary>
    public class RatingsMovieIds : RatingsEntry<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsMovieIds" /> class.</summary>
        /// <param name="movieIds">A <see cref="ITraktMovieIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="movieIds"/>.</param>
        public RatingsMovieIds(ITraktMovieIds movieIds, TraktPostRating rating)
            : base(movieIds, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with rating.</summary>
    public class RatingsShow : RatingsEntry<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsShow" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="rating">The rating for the <paramref name="show"/>.</param>
        public RatingsShow(ITraktShow show, TraktPostRating rating)
            : base(show, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with rating.</summary>
    public class RatingsShowIds : RatingsEntry<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsShowIds" /> class.</summary>
        /// <param name="showIds">A <see cref="ITraktShowIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="showIds"/>.</param>
        public RatingsShowIds(ITraktShowIds showIds, TraktPostRating rating)
            : base(showIds, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with rating.</summary>
    public class RatingsSeason : RatingsEntry<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsSeason" /> class.</summary>
        /// <param name="season">A <see cref="ITraktSeason"/>.</param>
        /// <param name="rating">The rating for the <paramref name="season"/>.</param>
        public RatingsSeason(ITraktSeason season, TraktPostRating rating)
            : base(season, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with rating.</summary>
    public class RatingsSeasonIds : RatingsEntry<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsSeasonIds" /> class.</summary>
        /// <param name="seasonIds">A <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="seasonIds"/>.</param>
        public RatingsSeasonIds(ITraktSeasonIds seasonIds, TraktPostRating rating)
            : base(seasonIds, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with rating.</summary>
    public class RatingsEpisode : RatingsEntry<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsEpisode" /> class.</summary>
        /// <param name="episode">A <see cref="ITraktEpisode"/>.</param>
        /// <param name="rating">The rating for the <paramref name="episode"/>.</param>
        public RatingsEpisode(ITraktEpisode episode, TraktPostRating rating)
            : base(episode, rating)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with rating.</summary>
    public class RatingsEpisodeIds : RatingsEntry<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsEpisodeIds" /> class.</summary>
        /// <param name="episodeIds">A <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="episodeIds"/>.</param>
        public RatingsEpisodeIds(ITraktEpisodeIds episodeIds, TraktPostRating rating)
            : base(episodeIds, rating)
        { }
    }

    public abstract class RatingsEntryRatedAt<T> : RatingsEntry<T>
    {
        public DateTime RatedAt { get; }

        protected RatingsEntryRatedAt(T obj, TraktPostRating rating, DateTime ratedAt) : base(obj, rating)
            => RatedAt = ratedAt.ToUniversalTime();
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsMovieRatedAt : RatingsEntryRatedAt<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsMovieRatedAt" /> class.</summary>
        /// <param name="movie">A rated <see cref="ITraktMovie"/>.</param>
        /// <param name="rating">The rating for the <paramref name="movie"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="movie"/> was rated.</param>
        public RatingsMovieRatedAt(ITraktMovie movie, TraktPostRating rating, DateTime ratedAt)
            : base(movie, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsMovieIdsRatedAt : RatingsEntryRatedAt<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsMovieIdsRatedAt" /> class.</summary>
        /// <param name="movieIds">A rated <see cref="ITraktMovieIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="movieIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="movieIds"/> was rated.</param>
        public RatingsMovieIdsRatedAt(ITraktMovieIds movieIds, TraktPostRating rating, DateTime ratedAt)
            : base(movieIds, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsShowRatedAt : RatingsEntryRatedAt<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsShowRatedAt" /> class.</summary>
        /// <param name="show">A rated <see cref="ITraktShow"/>.</param>
        /// <param name="rating">The rating for the <paramref name="show"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="show"/> was rated.</param>
        public RatingsShowRatedAt(ITraktShow show, TraktPostRating rating, DateTime ratedAt)
            : base(show, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsShowIdsRatedAt : RatingsEntryRatedAt<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsShowIdsRatedAt" /> class.</summary>
        /// <param name="showIds">A rated <see cref="ITraktShowIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="showIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="showIds"/> was rated.</param>
        public RatingsShowIdsRatedAt(ITraktShowIds showIds, TraktPostRating rating, DateTime ratedAt)
            : base(showIds, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsSeasonRatedAt : RatingsEntryRatedAt<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsSeasonRatedAt" /> class.</summary>
        /// <param name="season">A rated <see cref="ITraktSeason"/>.</param>
        /// <param name="rating">The rating for the <paramref name="season"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="season"/> was rated.</param>
        public RatingsSeasonRatedAt(ITraktSeason season, TraktPostRating rating, DateTime ratedAt)
            : base(season, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsSeasonIdsRatedAt : RatingsEntryRatedAt<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsSeasonIdsRatedAt" /> class.</summary>
        /// <param name="seasonIds">A rated <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="seasonIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="seasonIds"/> was rated.</param>
        public RatingsSeasonIdsRatedAt(ITraktSeasonIds seasonIds, TraktPostRating rating, DateTime ratedAt)
            : base(seasonIds, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsEpisodeRatedAt : RatingsEntryRatedAt<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsEpisodeRatedAt" /> class.</summary>
        /// <param name="episode">A rated <see cref="ITraktEpisode"/>.</param>
        /// <param name="rating">The rating for the <paramref name="episode"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="episode"/> was rated.</param>
        public RatingsEpisodeRatedAt(ITraktEpisode episode, TraktPostRating rating, DateTime ratedAt)
            : base(episode, rating, ratedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with a UTC datetime, when it was rated.</summary>
    public sealed class RatingsEpisodeIdsRatedAt : RatingsEntryRatedAt<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsEpisodeIdsRatedAt" /> class.</summary>
        /// <param name="episodeIds">A rated <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="rating">The rating for the <paramref name="episodeIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="episodeIds"/> was rated.</param>
        public RatingsEpisodeIdsRatedAt(ITraktEpisodeIds episodeIds, TraktPostRating rating, DateTime ratedAt)
            : base(episodeIds, rating, ratedAt)
        { }
    }

    public abstract class RatingsAndSeasons<T>
    {
        public T Object { get; }

        public PostRatingsSeasons Seasons { get; }

        protected RatingsAndSeasons(T obj, PostRatingsSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShow"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostRatingsSeasons"/>.
    /// </summary>
    public sealed class RatingsShowAndSeasons : RatingsAndSeasons<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsShowAndSeasons" /> class.</summary>
        /// <param name="show">A rated <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="show"/>.
        /// See also <seealso cref="PostRatingsSeasons"/>.
        /// </param>
        public RatingsShowAndSeasons(ITraktShow show, PostRatingsSeasons seasons)
            : base(show, seasons)
        { }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShowIds"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostRatingsSeasons"/>.
    /// </summary>
    public sealed class RatingsShowIdsAndSeasons : RatingsAndSeasons<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="RatingsShowIdsAndSeasons" /> class.</summary>
        /// <param name="showIds">A rated <see cref="ITraktShowIds"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="showIds"/>.
        /// See also <seealso cref="PostRatingsSeasons"/>.
        /// </param>
        public RatingsShowIdsAndSeasons(ITraktShowIds showIds, PostRatingsSeasons seasons)
            : base(showIds, seasons)
        { }
    }
}
