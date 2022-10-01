namespace TraktNet.Objects.Post
{
    using System;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    public abstract class CollectionEntry<T>
    {
        public T Object { get; }

        protected CollectionEntry(T obj)
            => Object = obj ?? throw new ArgumentNullException(nameof(obj));
    }

    public abstract class CollectedEntry<T> : CollectionEntry<T>
    {
        public DateTime CollectedAt { get; }

        protected CollectedEntry(T obj, DateTime collectedAt) : base(obj)
            => CollectedAt = collectedAt.ToUniversalTime();
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedMovie : CollectedEntry<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedMovie" /> class.</summary>
        /// <param name="movie">A collected <see cref="ITraktMovie"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movie"/> was collected.</param>
        public CollectedMovie(ITraktMovie movie, DateTime collectedAt)
            : base(movie, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedMovieIds : CollectedEntry<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedMovieIds" /> class.</summary>
        /// <param name="movieIds">A collected <see cref="ITraktMovieIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movieIds"/> was collected.</param>
        public CollectedMovieIds(ITraktMovieIds movieIds, DateTime collectedAt)
            : base(movieIds, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedShow : CollectedEntry<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedShow" /> class.</summary>
        /// <param name="show">A collected <see cref="ITraktShow"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="show"/> was collected.</param>
        public CollectedShow(ITraktShow show, DateTime collectedAt)
            : base(show, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedShowIds : CollectedEntry<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedShowIds" /> class.</summary>
        /// <param name="showIds">A collected <see cref="ITraktShowIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="showIds"/> was collected.</param>
        public CollectedShowIds(ITraktShowIds showIds, DateTime collectedAt)
            : base(showIds, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedSeason : CollectedEntry<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedSeason" /> class.</summary>
        /// <param name="season">A collected <see cref="ITraktSeason"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="season"/> was collected.</param>
        public CollectedSeason(ITraktSeason season, DateTime collectedAt)
            : base(season, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedSeasonIds : CollectedEntry<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedSeasonIds" /> class.</summary>
        /// <param name="seasonIds">A collected <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="seasonIds"/> was collected.</param>
        public CollectedSeasonIds(ITraktSeasonIds seasonIds, DateTime collectedAt)
            : base(seasonIds, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedEpisode : CollectedEntry<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedEpisode" /> class.</summary>
        /// <param name="episode">A collected <see cref="ITraktEpisode"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episode"/> was collected.</param>
        public CollectedEpisode(ITraktEpisode episode, DateTime collectedAt)
            : base(episode, collectedAt) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with a UTC datetime, when it was collected.</summary>
    public sealed class CollectedEpisodeIds : CollectedEntry<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedEpisodeIds" /> class.</summary>
        /// <param name="episodeIds">A collected <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episodeIds"/> was collected.</param>
        public CollectedEpisodeIds(ITraktEpisodeIds episodeIds, DateTime collectedAt)
            : base(episodeIds, collectedAt) 
        { }
    }

    public abstract class EntryWithMetadata<T> : CollectionEntry<T>
    {
        public ITraktMetadata Metadata { get; }

        protected EntryWithMetadata(T obj, ITraktMetadata metadata) : base(obj)
            => Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class MovieWithMetadata : EntryWithMetadata<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="MovieWithMetadata" /> class.</summary>
        /// <param name="movie">A <see cref="ITraktMovie"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="movie"/>.</param>
        public MovieWithMetadata(ITraktMovie movie, ITraktMetadata metadata)
            : base(movie, metadata) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class MovieIdsWithMetadata : EntryWithMetadata<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="MovieIdsWithMetadata" /> class.</summary>
        /// <param name="movieIds">A <see cref="ITraktMovieIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="movieIds"/>.</param>
        public MovieIdsWithMetadata(ITraktMovieIds movieIds, ITraktMetadata metadata)
            : base(movieIds, metadata) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class ShowWithMetadata : EntryWithMetadata<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowWithMetadata" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="show"/>.</param>
        public ShowWithMetadata(ITraktShow show, ITraktMetadata metadata)
            : base(show, metadata) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class ShowIdsWithMetadata : EntryWithMetadata<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="ShowIdsWithMetadata" /> class.</summary>
        /// <param name="showIds">A <see cref="ITraktShowIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="showIds"/>.</param>
        public ShowIdsWithMetadata(ITraktShowIds showIds, ITraktMetadata metadata)
            : base(showIds, metadata)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class SeasonWithMetadata : EntryWithMetadata<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="SeasonWithMetadata" /> class.</summary>
        /// <param name="season">A <see cref="ITraktSeason"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="season"/>.</param>
        public SeasonWithMetadata(ITraktSeason season, ITraktMetadata metadata)
            : base(season, metadata) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class SeasonIdsWithMetadata : EntryWithMetadata<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="SeasonIdsWithMetadata" /> class.</summary>
        /// <param name="seasonIds">A <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="seasonIds"/>.</param>
        public SeasonIdsWithMetadata(ITraktSeasonIds seasonIds, ITraktMetadata metadata)
            : base(seasonIds, metadata) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class EpisodeWithMetadata : EntryWithMetadata<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="EpisodeWithMetadata" /> class.</summary>
        /// <param name="episode">A <see cref="ITraktEpisode"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="episode"/>.</param>
        public EpisodeWithMetadata(ITraktEpisode episode, ITraktMetadata metadata)
            : base(episode, metadata) 
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with <see cref="ITraktMetadata"/>.</summary>
    public sealed class EpisodeIdsWithMetadata : EntryWithMetadata<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="EpisodeIdsWithMetadata" /> class.</summary>
        /// <param name="episodeIds">A <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="episodeIds"/>.</param>
        public EpisodeIdsWithMetadata(ITraktEpisodeIds episodeIds, ITraktMetadata metadata)
            : base(episodeIds, metadata)
        { }
    }

    public abstract class CollectedEntryWithMetadata<T> : EntryWithMetadata<T>
    {
        public DateTime CollectedAt { get; }

        protected CollectedEntryWithMetadata(T obj, ITraktMetadata metadata, DateTime collectedAt)
            : base(obj, metadata)
            => CollectedAt = collectedAt.ToUniversalTime();
    }

    /// <summary>Represents a <see cref="ITraktMovie"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedMovieWithMetadata : CollectedEntryWithMetadata<ITraktMovie>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedMovieWithMetadata" /> class.</summary>
        /// <param name="movie">A collected <see cref="ITraktMovie"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="movie"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movie"/> was collected.</param>
        public CollectedMovieWithMetadata(ITraktMovie movie, ITraktMetadata metadata, DateTime collectedAt)
            : base(movie, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktMovieIds"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedMovieIdsWithMetadata : CollectedEntryWithMetadata<ITraktMovieIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedMovieIdsWithMetadata" /> class.</summary>
        /// <param name="movieIds">A collected <see cref="ITraktMovieIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="movieIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movieIds"/> was collected.</param>
        public CollectedMovieIdsWithMetadata(ITraktMovieIds movieIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(movieIds, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedShowWithMetadata : CollectedEntryWithMetadata<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedShowWithMetadata" /> class.</summary>
        /// <param name="show">A collected <see cref="ITraktShow"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="show"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="show"/> was collected.</param>
        public CollectedShowWithMetadata(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt)
            : base(show, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedShowIdsWithMetadata : CollectedEntryWithMetadata<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedShowIdsWithMetadata" /> class.</summary>
        /// <param name="showIds">A collected <see cref="ITraktShowIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="showIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="showIds"/> was collected.</param>
        public CollectedShowIdsWithMetadata(ITraktShowIds showIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(showIds, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeason"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedSeasonWithMetadata : CollectedEntryWithMetadata<ITraktSeason>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedSeasonWithMetadata" /> class.</summary>
        /// <param name="season">A collected <see cref="ITraktSeason"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="season"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="season"/> was collected.</param>
        public CollectedSeasonWithMetadata(ITraktSeason season, ITraktMetadata metadata, DateTime collectedAt)
            : base(season, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktSeasonIds"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedSeasonIdsWithMetadata : CollectedEntryWithMetadata<ITraktSeasonIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedSeasonIdsWithMetadata" /> class.</summary>
        /// <param name="seasonIds">A collected <see cref="ITraktSeasonIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="seasonIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="seasonIds"/> was collected.</param>
        public CollectedSeasonIdsWithMetadata(ITraktSeasonIds seasonIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(seasonIds, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisode"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedEpisodeWithMetadata : CollectedEntryWithMetadata<ITraktEpisode>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedEpisodeWithMetadata" /> class.</summary>
        /// <param name="episode">A collected <see cref="ITraktEpisode"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="episode"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episode"/> was collected.</param>
        public CollectedEpisodeWithMetadata(ITraktEpisode episode, ITraktMetadata metadata, DateTime collectedAt)
            : base(episode, metadata, collectedAt)
        { }
    }

    /// <summary>Represents a <see cref="ITraktEpisodeIds"/> with <see cref="ITraktMetadata"/> and a UTC datetime, when it was collected.</summary>
    public sealed class CollectedEpisodeIdsWithMetadata : CollectedEntryWithMetadata<ITraktEpisodeIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectedEpisodeIdsWithMetadata" /> class.</summary>
        /// <param name="episodeIds">A collected <see cref="ITraktEpisodeIds"/>.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the <paramref name="episodeIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episodeIds"/> was collected.</param>
        public CollectedEpisodeIdsWithMetadata(ITraktEpisodeIds episodeIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(episodeIds, metadata, collectedAt)
        { }
    }

    public abstract class CollectionAndSeasons<T>
    {
        public T Object { get; }

        public PostCollectionSeasons Seasons { get; }

        protected CollectionAndSeasons(T obj, PostCollectionSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShow"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostCollectionSeasons"/>.
    /// </summary>
    public sealed class CollectionShowAndSeasons : CollectionAndSeasons<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectionShowAndSeasons" /> class.</summary>
        /// <param name="show">A collected <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="show"/>.
        /// See also <seealso cref="PostCollectionSeasons"/>.
        /// </param>
        public CollectionShowAndSeasons(ITraktShow show, PostCollectionSeasons seasons)
            : base(show, seasons)
        { }
    }

    /// <summary>
    /// Represents a <see cref="ITraktShowIds"/> with a collection of seasons and episodes.
    /// See also <seealso cref="PostCollectionSeasons"/>.
    /// </summary>
    public sealed class CollectionShowIdsAndSeasons : CollectionAndSeasons<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectionShowIdsAndSeasons" /> class.</summary>
        /// <param name="showIds">A collected <see cref="ITraktShowIds"/>.</param>
        /// <param name="seasons">
        /// A collection of seasons and episodes for the <paramref name="showIds"/>.
        /// See also <seealso cref="PostCollectionSeasons"/>.
        /// </param>
        public CollectionShowIdsAndSeasons(ITraktShowIds showIds, PostCollectionSeasons seasons)
            : base(showIds, seasons)
        { }
    }
}
