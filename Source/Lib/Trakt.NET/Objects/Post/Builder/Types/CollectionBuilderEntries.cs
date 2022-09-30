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

        public CollectedEntry(T obj, DateTime collectedAt) : base(obj)
            => CollectedAt = collectedAt.ToUniversalTime();
    }

    public sealed class CollectedMovie : CollectedEntry<ITraktMovie>
    {
        public CollectedMovie(ITraktMovie movie, DateTime collectedAt)
            : base(movie, collectedAt) 
        { }
    }

    public sealed class CollectedMovieIds : CollectedEntry<ITraktMovieIds>
    {
        public CollectedMovieIds(ITraktMovieIds movieIds, DateTime collectedAt) 
            : base(movieIds, collectedAt) 
        { }
    }

    public sealed class CollectedShow : CollectedEntry<ITraktShow>
    {
        public CollectedShow(ITraktShow show, DateTime collectedAt) 
            : base(show, collectedAt) 
        { }
    }

    public sealed class CollectedShowIds : CollectedEntry<ITraktShowIds>
    {
        public CollectedShowIds(ITraktShowIds showIds, DateTime collectedAt) 
            : base(showIds, collectedAt) 
        { }
    }

    public sealed class CollectedSeason : CollectedEntry<ITraktSeason>
    {
        public CollectedSeason(ITraktSeason season, DateTime collectedAt) 
            : base(season, collectedAt) 
        { }
    }

    public sealed class CollectedSeasonIds : CollectedEntry<ITraktSeasonIds>
    {
        public CollectedSeasonIds(ITraktSeasonIds seasonIds, DateTime collectedAt) 
            : base(seasonIds, collectedAt) 
        { }
    }

    public sealed class CollectedEpisode : CollectedEntry<ITraktEpisode>
    {
        public CollectedEpisode(ITraktEpisode episode, DateTime collectedAt) 
            : base(episode, collectedAt) 
        { }
    }

    public sealed class CollectedEpisodeIds : CollectedEntry<ITraktEpisodeIds>
    {
        public CollectedEpisodeIds(ITraktEpisodeIds episodeIds, DateTime collectedAt) 
            : base(episodeIds, collectedAt) 
        { }
    }

    public abstract class EntryWithMetadata<T> : CollectionEntry<T>
    {
        public ITraktMetadata Metadata { get; }

        public EntryWithMetadata(T obj, ITraktMetadata metadata) : base(obj)
            => Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
    }

    public sealed class MovieWithMetadata : EntryWithMetadata<ITraktMovie>
    {
        public MovieWithMetadata(ITraktMovie movie, ITraktMetadata metadata) 
            : base(movie, metadata) 
        { }
    }

    public sealed class MovieIdsWithMetadata : EntryWithMetadata<ITraktMovieIds>
    {
        public MovieIdsWithMetadata(ITraktMovieIds movieIds, ITraktMetadata metadata) 
            : base(movieIds, metadata) 
        { }
    }

    public sealed class ShowWithMetadata : EntryWithMetadata<ITraktShow>
    {
        public ShowWithMetadata(ITraktShow show, ITraktMetadata metadata) 
            : base(show, metadata) 
        { }
    }

    public sealed class ShowIdsWithMetadata : EntryWithMetadata<ITraktShowIds>
    {
        public ShowIdsWithMetadata(ITraktShowIds showIds, ITraktMetadata metadata) 
            : base(showIds, metadata)
        { }
    }

    public sealed class SeasonWithMetadata : EntryWithMetadata<ITraktSeason>
    {
        public SeasonWithMetadata(ITraktSeason season, ITraktMetadata metadata) 
            : base(season, metadata) 
        { }
    }

    public sealed class SeasonIdsWithMetadata : EntryWithMetadata<ITraktSeasonIds>
    {
        public SeasonIdsWithMetadata(ITraktSeasonIds seasonIds, ITraktMetadata metadata) 
            : base(seasonIds, metadata) 
        { }
    }

    public sealed class EpisodeWithMetadata : EntryWithMetadata<ITraktEpisode>
    {
        public EpisodeWithMetadata(ITraktEpisode episode, ITraktMetadata metadata) 
            : base(episode, metadata) 
        { }
    }

    public sealed class EpisodeIdsWithMetadata : EntryWithMetadata<ITraktEpisodeIds>
    {
        public EpisodeIdsWithMetadata(ITraktEpisodeIds episodeIds, ITraktMetadata metadata)
            : base(episodeIds, metadata)
        { }
    }

    public abstract class CollectedEntryWithMetadata<T> : EntryWithMetadata<T>
    {
        public DateTime CollectedAt { get; }

        public CollectedEntryWithMetadata(T obj, ITraktMetadata metadata, DateTime collectedAt)
            : base(obj, metadata)
            => CollectedAt = collectedAt.ToUniversalTime();
    }

    public sealed class CollectedMovieWithMetadata : CollectedEntryWithMetadata<ITraktMovie>
    {
        public CollectedMovieWithMetadata(ITraktMovie movie, ITraktMetadata metadata, DateTime collectedAt)
            : base(movie, metadata, collectedAt)
        { }
    }

    public sealed class CollectedMovieIdsWithMetadata : CollectedEntryWithMetadata<ITraktMovieIds>
    {
        public CollectedMovieIdsWithMetadata(ITraktMovieIds movieIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(movieIds, metadata, collectedAt)
        { }
    }

    public sealed class CollectedShowWithMetadata : CollectedEntryWithMetadata<ITraktShow>
    {
        public CollectedShowWithMetadata(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt)
            : base(show, metadata, collectedAt)
        { }
    }

    public sealed class CollectedShowIdsWithMetadata : CollectedEntryWithMetadata<ITraktShowIds>
    {
        public CollectedShowIdsWithMetadata(ITraktShowIds showIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(showIds, metadata, collectedAt)
        { }
    }

    public sealed class CollectedSeasonWithMetadata : CollectedEntryWithMetadata<ITraktSeason>
    {
        public CollectedSeasonWithMetadata(ITraktSeason season, ITraktMetadata metadata, DateTime collectedAt)
            : base(season, metadata, collectedAt)
        { }
    }

    public sealed class CollectedSeasonIdsWithMetadata : CollectedEntryWithMetadata<ITraktSeasonIds>
    {
        public CollectedSeasonIdsWithMetadata(ITraktSeasonIds seasonIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(seasonIds, metadata, collectedAt)
        { }
    }

    public sealed class CollectedEpisodeWithMetadata : CollectedEntryWithMetadata<ITraktEpisode>
    {
        public CollectedEpisodeWithMetadata(ITraktEpisode episode, ITraktMetadata metadata, DateTime collectedAt)
            : base(episode, metadata, collectedAt)
        { }
    }

    public sealed class CollectedEpisodeIdsWithMetadata : CollectedEntryWithMetadata<ITraktEpisodeIds>
    {
        public CollectedEpisodeIdsWithMetadata(ITraktEpisodeIds episodeIds, ITraktMetadata metadata, DateTime collectedAt)
            : base(episodeIds, metadata, collectedAt)
        { }
    }

    public abstract class CollectionAndSeasons<T>
    {
        public T Object { get; }

        public PostCollectionSeasons Seasons { get; }

        public CollectionAndSeasons(T obj, PostCollectionSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }

    public sealed class CollectionShowAndSeasons : CollectionAndSeasons<ITraktShow>
    {
        public CollectionShowAndSeasons(ITraktShow show, PostCollectionSeasons seasons)
            : base(show, seasons)
        { }
    }

    public sealed class CollectionShowIdsAndSeasons : CollectionAndSeasons<ITraktShowIds>
    {
        public CollectionShowIdsAndSeasons(ITraktShowIds showIds, PostCollectionSeasons seasons)
            : base(showIds, seasons)
        { }
    }
}
