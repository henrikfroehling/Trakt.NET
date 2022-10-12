namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    public abstract class WatchedEntry<T>
    {
        public T Object { get; }

        public DateTime WatchedAt { get; }

        protected WatchedEntry(T obj, DateTime watchedAt)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            WatchedAt = watchedAt.ToUniversalTime();
        }
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedMovie : WatchedEntry<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedMovie" /> class.</summary>
        /// <param name="movie">A watched <see cref="ITraktMovie"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="movie"/> was watched.</param>
        public WatchedMovie(ITraktMovie movie, DateTime watchedAt)
            : base(movie, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedMovieIds : WatchedEntry<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedMovieIds" /> class.</summary>
        /// <param name="movieIds">A watched <see cref="ITraktMovieIds"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="movieIds"/> was watched.</param>
        public WatchedMovieIds(ITraktMovieIds movieIds, DateTime watchedAt)
            : base(movieIds, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedShow : WatchedEntry<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedShow" /> class.</summary>
        /// <param name="show">A watched <see cref="ITraktShow"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="show"/> was watched.</param>
        public WatchedShow(ITraktShow show, DateTime watchedAt)
            : base(show, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedShowIds : WatchedEntry<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedShowIds" /> class.</summary>
        /// <param name="showIds">A watched <see cref="ITraktShowIds"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="showIds"/> was watched.</param>
        public WatchedShowIds(ITraktShowIds showIds, DateTime watchedAt)
            : base(showIds, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedSeason : WatchedEntry<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedSeason" /> class.</summary>
        /// <param name="season">A watched <see cref="ITraktSeason"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="season"/> was watched.</param>
        public WatchedSeason(ITraktSeason season, DateTime watchedAt)
            : base(season, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedSeasonIds : WatchedEntry<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedSeasonIds" /> class.</summary>
        /// <param name="seasonIds">A watched <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="seasonIds"/> was watched.</param>
        public WatchedSeasonIds(ITraktSeasonIds seasonIds, DateTime watchedAt)
            : base(seasonIds, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedEpisode : WatchedEntry<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedEpisode" /> class.</summary>
        /// <param name="episode">A watched <see cref="ITraktEpisode"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="episode"/> was watched.</param>
        public WatchedEpisode(ITraktEpisode episode, DateTime watchedAt)
            : base(episode, watchedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with a UTC datetime, when it was watched.</summary>
    public sealed class WatchedEpisodeIds : WatchedEntry<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedEpisodeIds" /> class.</summary>
        /// <param name="episodeIds">A watched <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="episodeIds"/> was watched.</param>
        public WatchedEpisodeIds(ITraktEpisodeIds episodeIds, DateTime watchedAt)
            : base(episodeIds, watchedAt)
        { }
    }

    public abstract class HistoryAndSeasons<T>
    {
        public T Object { get; }

        public PostHistorySeasons Seasons { get; }

        protected HistoryAndSeasons(T obj, PostHistorySeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShow"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostHistorySeasons"/>.
    /// </summary>
    public sealed class WatchedShowAndSeasons : HistoryAndSeasons<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedShowAndSeasons" /> class.</summary>
        /// <param name="show">A watched <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="show"/>.
        /// See also <seealso cref="PostHistorySeasons"/>.
        /// </param>
        public WatchedShowAndSeasons(ITraktShow show, PostHistorySeasons seasons)
            : base(show, seasons)
        { }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShowIds"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostHistorySeasons"/>.
    /// </summary>
    public sealed class WatchedShowIdsAndSeasons : HistoryAndSeasons<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="WatchedShowIdsAndSeasons" /> class.</summary>
        /// <param name="showIds">A watched <see cref="ITraktShowIds"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="showIds"/>.
        /// See also <seealso cref="PostHistorySeasons"/>.
        /// </param>
        public WatchedShowIdsAndSeasons(ITraktShowIds showIds, PostHistorySeasons seasons)
            : base(showIds, seasons)
        { }
    }
}
