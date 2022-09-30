namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;

    internal sealed class SyncCollectionPostBuilder : ITraktSyncCollectionPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<CollectedEntry<ITraktMovie>>> _moviesCollectedAt;
        private readonly Lazy<List<CollectedEntry<ITraktMovieIds>>> _movieIdsCollectedAt;
        private readonly Lazy<List<EntryWithMetadata<ITraktMovie>>> _moviesWithMetadata;
        private readonly Lazy<List<EntryWithMetadata<ITraktMovieIds>>> _movieIdsWithMetadata;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktMovie>>> _moviesWithMetadataCollected;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktMovieIds>>> _movieIdsWithMetadataCollectedAt;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<CollectedEntry<ITraktShow>>> _showsCollectedAt;
        private readonly Lazy<List<CollectedEntry<ITraktShowIds>>> _showIdsCollectedAt;
        private readonly Lazy<List<EntryWithMetadata<ITraktShow>>> _showsWithMetadata;
        private readonly Lazy<List<EntryWithMetadata<ITraktShowIds>>> _showIdsWithMetadata;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktShow>>> _showsWithMetadataCollected;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktShowIds>>> _showIdsWithMetadataCollectedAt;
        private readonly Lazy<List<CollectionShowAndSeasons<ITraktShow>>> _showsAndSeasons;
        private readonly Lazy<List<CollectionShowAndSeasons<ITraktShowIds>>> _showIdsAndSeasons;
        private readonly Lazy<List<ITraktSeason>> _seasons;
        private readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        private readonly Lazy<List<CollectedEntry<ITraktSeason>>> _seasonsCollectedAt;
        private readonly Lazy<List<CollectedEntry<ITraktSeasonIds>>> _seasonIdsCollectedAt;
        private readonly Lazy<List<EntryWithMetadata<ITraktSeason>>> _seasonsWithMetadata;
        private readonly Lazy<List<EntryWithMetadata<ITraktSeasonIds>>> _seasonIdsWithMetadata;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktSeason>>> _seasonsWithMetadataCollected;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktSeasonIds>>> _seasonIdsWithMetadataCollectedAt;
        private readonly Lazy<List<ITraktEpisode>> _episodes;
        private readonly Lazy<List<ITraktEpisodeIds>> _episodeIds;
        private readonly Lazy<List<CollectedEntry<ITraktEpisode>>> _episodesCollectedAt;
        private readonly Lazy<List<CollectedEntry<ITraktEpisodeIds>>> _episodeIdsCollectedAt;
        private readonly Lazy<List<EntryWithMetadata<ITraktEpisode>>> _episodesWithMetadata;
        private readonly Lazy<List<EntryWithMetadata<ITraktEpisodeIds>>> _episodeIdsWithMetadata;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktEpisode>>> _episodesWithMetadataCollected;
        private readonly Lazy<List<CollectedEntryWithMetadata<ITraktEpisodeIds>>> _episodeIdsWithMetadataCollectedAt;

        internal SyncCollectionPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>(() => new List<ITraktMovie>());
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _moviesCollectedAt = new Lazy<List<CollectedEntry<ITraktMovie>>>();
            _movieIdsCollectedAt = new Lazy<List<CollectedEntry<ITraktMovieIds>>>();
            _moviesWithMetadata = new Lazy<List<EntryWithMetadata<ITraktMovie>>>();
            _movieIdsWithMetadata = new Lazy<List<EntryWithMetadata<ITraktMovieIds>>>();
            _moviesWithMetadataCollected = new Lazy<List<CollectedEntryWithMetadata<ITraktMovie>>>();
            _movieIdsWithMetadataCollectedAt = new Lazy<List<CollectedEntryWithMetadata<ITraktMovieIds>>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsCollectedAt = new Lazy<List<CollectedEntry<ITraktShow>>>();
            _showIdsCollectedAt = new Lazy<List<CollectedEntry<ITraktShowIds>>>();
            _showsWithMetadata = new Lazy<List<EntryWithMetadata<ITraktShow>>>();
            _showIdsWithMetadata = new Lazy<List<EntryWithMetadata<ITraktShowIds>>>();
            _showsWithMetadataCollected = new Lazy<List<CollectedEntryWithMetadata<ITraktShow>>>();
            _showIdsWithMetadataCollectedAt = new Lazy<List<CollectedEntryWithMetadata<ITraktShowIds>>>();
            _showsAndSeasons = new Lazy<List<CollectionShowAndSeasons<ITraktShow>>>();
            _showIdsAndSeasons = new Lazy<List<CollectionShowAndSeasons<ITraktShowIds>>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _seasonsCollectedAt = new Lazy<List<CollectedEntry<ITraktSeason>>>();
            _seasonIdsCollectedAt = new Lazy<List<CollectedEntry<ITraktSeasonIds>>>();
            _seasonsWithMetadata = new Lazy<List<EntryWithMetadata<ITraktSeason>>>();
            _seasonIdsWithMetadata = new Lazy<List<EntryWithMetadata<ITraktSeasonIds>>>();
            _seasonsWithMetadataCollected = new Lazy<List<CollectedEntryWithMetadata<ITraktSeason>>>();
            _seasonIdsWithMetadataCollectedAt = new Lazy<List<CollectedEntryWithMetadata<ITraktSeasonIds>>>();
            _episodes = new Lazy<List<ITraktEpisode>>();
            _episodeIds = new Lazy<List<ITraktEpisodeIds>>();
            _episodesCollectedAt = new Lazy<List<CollectedEntry<ITraktEpisode>>>();
            _episodeIdsCollectedAt = new Lazy<List<CollectedEntry<ITraktEpisodeIds>>>();
            _episodesWithMetadata = new Lazy<List<EntryWithMetadata<ITraktEpisode>>>();
            _episodeIdsWithMetadata = new Lazy<List<EntryWithMetadata<ITraktEpisodeIds>>>();
            _episodesWithMetadataCollected = new Lazy<List<CollectedEntryWithMetadata<ITraktEpisode>>>();
            _episodeIdsWithMetadataCollectedAt = new Lazy<List<CollectedEntryWithMetadata<ITraktEpisodeIds>>>();
        }

        public ITraktSyncCollectionPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovieCollectedAt(ITraktMovie movie, DateTime collectedAt)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return WithMovieCollectedAt(new CollectedEntry<ITraktMovie>(movie, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithMovieCollectedAt(CollectedEntry<ITraktMovie> movieCollectedAt)
        {
            if (movieCollectedAt == null)
                throw new ArgumentNullException(nameof(movieCollectedAt));

            _moviesCollectedAt.Value.Add(movieCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovieCollectedAt(ITraktMovieIds movieIds, DateTime collectedAt)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return WithMovieCollectedAt(new CollectedEntry<ITraktMovieIds>(movieIds, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithMovieCollectedAt(CollectedEntry<ITraktMovieIds> movieIdsCollectedAt)
        {
            if (movieIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(movieIdsCollectedAt));

            _movieIdsCollectedAt.Value.Add(movieIdsCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadata(ITraktMovie movie, ITraktMetadata metadata)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithMovieWithMetadata(new EntryWithMetadata<ITraktMovie>(movie, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadata(EntryWithMetadata<ITraktMovie> movieWithMetadata)
        {
            if (movieWithMetadata == null)
                throw new ArgumentNullException(nameof(movieWithMetadata));

            _moviesWithMetadata.Value.Add(movieWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadata(ITraktMovieIds movieIds, ITraktMetadata metadata)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithMovieWithMetadata(new EntryWithMetadata<ITraktMovieIds>(movieIds, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadata(EntryWithMetadata<ITraktMovieIds> movieIdsWithMetadata)
        {
            if (movieIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(movieIdsWithMetadata));

            _movieIdsWithMetadata.Value.Add(movieIdsWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(ITraktMovie movie, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithMovieWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktMovie>(movie, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktMovie> movieWithMetadataCollectedAt)
        {
            if (movieWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(movieWithMetadataCollectedAt));

            _moviesWithMetadataCollected.Value.Add(movieWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(ITraktMovieIds movieIds, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithMovieWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktMovieIds>(movieIds, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktMovieIds> movieIdsWithMetadataCollectedAt)
        {
            if (movieIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(movieIdsWithMetadataCollectedAt));

            _movieIdsWithMetadataCollectedAt.Value.Add(movieIdsWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (ITraktMovie movie in movies)
            {
                if (movie != null)
                    _movies.Value.Add(movie);
            }
            
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            foreach (ITraktMovieIds movieId in movieIds)
            {
                if (movieId != null)
                    _movieIds.Value.Add(movieId);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesCollectedAt(IEnumerable<CollectedEntry<ITraktMovie>> moviesCollectedAt)
        {
            if (moviesCollectedAt == null)
                throw new ArgumentNullException(nameof(moviesCollectedAt));

            foreach (CollectedEntry<ITraktMovie> movieCollectedAt in moviesCollectedAt)
            {
                if (movieCollectedAt != null)
                    _moviesCollectedAt.Value.Add(movieCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesCollectedAt(IEnumerable<CollectedEntry<ITraktMovieIds>> movieIdsCollectedAt)
        {
            if (movieIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(movieIdsCollectedAt));

            foreach (CollectedEntry<ITraktMovieIds> movieIdCollectedAt in movieIdsCollectedAt)
            {
                if (movieIdCollectedAt != null)
                    _movieIdsCollectedAt.Value.Add(movieIdCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesWithMetadata(IEnumerable<EntryWithMetadata<ITraktMovie>> moviesWithMetadata)
        {
            if (moviesWithMetadata == null)
                throw new ArgumentNullException(nameof(moviesWithMetadata));

            foreach (EntryWithMetadata<ITraktMovie> movieWithMetadata in moviesWithMetadata)
            {
                if (movieWithMetadata != null)
                    _moviesWithMetadata.Value.Add(movieWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesWithMetadata(IEnumerable<EntryWithMetadata<ITraktMovieIds>> movieIdsWithMetadata)
        {
            if (movieIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(movieIdsWithMetadata));

            foreach (EntryWithMetadata<ITraktMovieIds> movieIdWithMetadata in movieIdsWithMetadata)
            {
                if (movieIdWithMetadata != null)
                    _movieIdsWithMetadata.Value.Add(movieIdWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesWithMetadataCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktMovie>> moviesWithMetadataCollectedAt)
        {
            if (moviesWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(moviesWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktMovie> movieWithMetadataCollectedAt in moviesWithMetadataCollectedAt)
            {
                if (movieWithMetadataCollectedAt != null)
                    _moviesWithMetadataCollected.Value.Add(movieWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesWithMetadataCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktMovieIds>> movieIdsWithMetadataCollectedAt)
        {
            if (movieIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(movieIdsWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktMovieIds> movieIdWithMetadataCollectedAt in movieIdsWithMetadataCollectedAt)
            {
                if (movieIdWithMetadataCollectedAt != null)
                    _movieIdsWithMetadataCollectedAt.Value.Add(movieIdWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowCollectedAt(ITraktShow show, DateTime collectedAt)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return WithShowCollectedAt(new CollectedEntry<ITraktShow>(show, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithShowCollectedAt(CollectedEntry<ITraktShow> showCollectedAt)
        {
            if (showCollectedAt == null)
                throw new ArgumentNullException(nameof(showCollectedAt));

            _showsCollectedAt.Value.Add(showCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowCollectedAt(ITraktShowIds showIds, DateTime collectedAt)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return WithShowCollectedAt(new CollectedEntry<ITraktShowIds>(showIds, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithShowCollectedAt(CollectedEntry<ITraktShowIds> showIdsCollectedAt)
        {
            if (showIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(showIdsCollectedAt));

            _showIdsCollectedAt.Value.Add(showIdsCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadata(ITraktShow show, ITraktMetadata metadata)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithShowWithMetadata(new EntryWithMetadata<ITraktShow>(show, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadata(EntryWithMetadata<ITraktShow> showWithMetadata)
        {
            if (showWithMetadata == null)
                throw new ArgumentNullException(nameof(showWithMetadata));

            _showsWithMetadata.Value.Add(showWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadata(ITraktShowIds showIds, ITraktMetadata metadata)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithShowWithMetadata(new EntryWithMetadata<ITraktShowIds>(showIds, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadata(EntryWithMetadata<ITraktShowIds> showIdsWithMetadata)
        {
            if (showIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(showIdsWithMetadata));

            _showIdsWithMetadata.Value.Add(showIdsWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithShowWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktShow>(show, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktShow> showWithMetadataCollectedAt)
        {
            if (showWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(showWithMetadataCollectedAt));

            _showsWithMetadataCollected.Value.Add(showWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(ITraktShowIds showIds, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithShowWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktShowIds>(showIds, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktShowIds> showIdsWithMetadataCollectedAt)
        {
            if (showIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(showIdsWithMetadataCollectedAt));

            _showIdsWithMetadataCollectedAt.Value.Add(showIdsWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (ITraktShow show in shows)
            {
                if (show != null)
                    _shows.Value.Add(show);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            foreach (ITraktShowIds showId in showIds)
            {
                if (showId != null)
                    _showIds.Value.Add(showId);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsCollectedAt(IEnumerable<CollectedEntry<ITraktShow>> showsCollectedAt)
        {
            if (showsCollectedAt == null)
                throw new ArgumentNullException(nameof(showsCollectedAt));

            foreach (CollectedEntry<ITraktShow> showCollectedAt in showsCollectedAt)
            {
                if (showCollectedAt != null)
                    _showsCollectedAt.Value.Add(showCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsCollectedAt(IEnumerable<CollectedEntry<ITraktShowIds>> showIdsCollectedAt)
        {
            if (showIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(showIdsCollectedAt));

            foreach (CollectedEntry<ITraktShowIds> showIdCollectedAt in showIdsCollectedAt)
            {
                if (showIdCollectedAt != null)
                    _showIdsCollectedAt.Value.Add(showIdCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsWithMetadata(IEnumerable<EntryWithMetadata<ITraktShow>> showsWithMetadata)
        {
            if (showsWithMetadata == null)
                throw new ArgumentNullException(nameof(showsWithMetadata));

            foreach (EntryWithMetadata<ITraktShow> showWithMetadata in showsWithMetadata)
            {
                if (showWithMetadata != null)
                    _showsWithMetadata.Value.Add(showWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsWithMetadata(IEnumerable<EntryWithMetadata<ITraktShowIds>> showIdsWithMetadata)
        {
            if (showIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(showIdsWithMetadata));

            foreach (EntryWithMetadata<ITraktShowIds> showIdWithMetadata in showIdsWithMetadata)
            {
                if (showIdWithMetadata != null)
                    _showIdsWithMetadata.Value.Add(showIdWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktShow>> showsWithMetadataCollectedAt)
        {
            if (showsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(showsWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktShow> showWithMetadataCollectedAt in showsWithMetadataCollectedAt)
            {
                if (showWithMetadataCollectedAt != null)
                    _showsWithMetadataCollected.Value.Add(showWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktShowIds>> showIdsWithMetadataCollectedAt)
        {
            if (showIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(showIdsWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktShowIds> showIdWithMetadataCollectedAt in showIdsWithMetadataCollectedAt)
            {
                if (showIdWithMetadataCollectedAt != null)
                    _showIdsWithMetadataCollectedAt.Value.Add(showIdWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowAndSeasons(ITraktShow show, PostCollectionSeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new CollectionShowAndSeasons<ITraktShow>(show, seasons));
        }

        public ITraktSyncCollectionPostBuilder WithShowAndSeasons(CollectionShowAndSeasons<ITraktShow> showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostCollectionSeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new CollectionShowAndSeasons<ITraktShowIds>(showIds, seasons));
        }

        public ITraktSyncCollectionPostBuilder WithShowAndSeasons(CollectionShowAndSeasons<ITraktShowIds> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndSeasons(IEnumerable<CollectionShowAndSeasons<ITraktShow>> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (CollectionShowAndSeasons<ITraktShow> showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndSeasons(IEnumerable<CollectionShowAndSeasons<ITraktShowIds>> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (CollectionShowAndSeasons<ITraktShowIds> showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(ITraktSeason season, DateTime collectedAt)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            return WithSeasonCollectedAt(new CollectedEntry<ITraktSeason>(season, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(CollectedEntry<ITraktSeason> seasonCollectedAt)
        {
            if (seasonCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonCollectedAt));

            _seasonsCollectedAt.Value.Add(seasonCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(ITraktSeasonIds seasonIds, DateTime collectedAt)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            return WithSeasonCollectedAt(new CollectedEntry<ITraktSeasonIds>(seasonIds, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(CollectedEntry<ITraktSeasonIds> seasonIdsCollectedAt)
        {
            if (seasonIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsCollectedAt));

            _seasonIdsCollectedAt.Value.Add(seasonIdsCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(ITraktSeason season, ITraktMetadata metadata)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithSeasonWithMetadata(new EntryWithMetadata<ITraktSeason>(season, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(EntryWithMetadata<ITraktSeason> seasonWithMetadata)
        {
            if (seasonWithMetadata == null)
                throw new ArgumentNullException(nameof(seasonWithMetadata));

            _seasonsWithMetadata.Value.Add(seasonWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(ITraktSeasonIds seasonIds, ITraktMetadata metadata)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithSeasonWithMetadata(new EntryWithMetadata<ITraktSeasonIds>(seasonIds, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(EntryWithMetadata<ITraktSeasonIds> seasonIdsWithMetadata)
        {
            if (seasonIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(seasonIdsWithMetadata));

            _seasonIdsWithMetadata.Value.Add(seasonIdsWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(ITraktSeason season, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithSeasonWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktSeason>(season, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktSeason> seasonWithMetadataCollectedAt)
        {
            if (seasonWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonWithMetadataCollectedAt));

            _seasonsWithMetadataCollected.Value.Add(seasonWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(ITraktSeasonIds seasonIds, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithSeasonWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktSeasonIds>(seasonIds, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktSeasonIds> seasonIdsWithMetadataCollectedAt)
        {
            if (seasonIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsWithMetadataCollectedAt));

            _seasonIdsWithMetadataCollectedAt.Value.Add(seasonIdsWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            foreach (ITraktSeason season in seasons)
            {
                if (season != null)
                    _seasons.Value.Add(season);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            foreach (ITraktSeasonIds seasonId in seasonIds)
            {
                if (seasonId != null)
                    _seasonIds.Value.Add(seasonId);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonsCollectedAt(IEnumerable<CollectedEntry<ITraktSeason>> seasonsCollectedAt)
        {
            if (seasonsCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonsCollectedAt));

            foreach (CollectedEntry<ITraktSeason> seasonCollectedAt in seasonsCollectedAt)
            {
                if (seasonCollectedAt != null)
                    _seasonsCollectedAt.Value.Add(seasonCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonsCollectedAt(IEnumerable<CollectedEntry<ITraktSeasonIds>> seasonIdsCollectedAt)
        {
            if (seasonIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsCollectedAt));

            foreach (CollectedEntry<ITraktSeasonIds> seasonIdCollectedAt in seasonIdsCollectedAt)
            {
                if (seasonIdCollectedAt != null)
                    _seasonIdsCollectedAt.Value.Add(seasonIdCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonsWithMetadata(IEnumerable<EntryWithMetadata<ITraktSeason>> seasonsWithMetadata)
        {
            if (seasonsWithMetadata == null)
                throw new ArgumentNullException(nameof(seasonsWithMetadata));

            foreach (EntryWithMetadata<ITraktSeason> seasonWithMetadata in seasonsWithMetadata)
            {
                if (seasonWithMetadata != null)
                    _seasonsWithMetadata.Value.Add(seasonWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonsWithMetadata(IEnumerable<EntryWithMetadata<ITraktSeasonIds>> seasonIdsWithMetadata)
        {
            if (seasonIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(seasonIdsWithMetadata));

            foreach (EntryWithMetadata<ITraktSeasonIds> seasonIdWithMetadata in seasonIdsWithMetadata)
            {
                if (seasonIdWithMetadata != null)
                    _seasonIdsWithMetadata.Value.Add(seasonIdWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktSeason>> seasonsWithMetadataCollectedAt)
        {
            if (seasonsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonsWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktSeason> seasonWithMetadataCollectedAt in seasonsWithMetadataCollectedAt)
            {
                if (seasonWithMetadataCollectedAt != null)
                    _seasonsWithMetadataCollected.Value.Add(seasonWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithSeasonsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktSeasonIds>> seasonIdsWithMetadataCollectedAt)
        {
            if (seasonIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktSeasonIds> seasonIdWithMetadataCollectedAt in seasonIdsWithMetadataCollectedAt)
            {
                if (seasonIdWithMetadataCollectedAt != null)
                    _seasonIdsWithMetadataCollectedAt.Value.Add(seasonIdWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Value.Add(episode);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            _episodeIds.Value.Add(episodeIds);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(ITraktEpisode episode, DateTime collectedAt)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            return WithEpisodeCollectedAt(new CollectedEntry<ITraktEpisode>(episode, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(CollectedEntry<ITraktEpisode> episodeCollectedAt)
        {
            if (episodeCollectedAt == null)
                throw new ArgumentNullException(nameof(episodeCollectedAt));

            _episodesCollectedAt.Value.Add(episodeCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(ITraktEpisodeIds episodeIds, DateTime collectedAt)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            return WithEpisodeCollectedAt(new CollectedEntry<ITraktEpisodeIds>(episodeIds, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(CollectedEntry<ITraktEpisodeIds> episodeIdsCollectedAt)
        {
            if (episodeIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsCollectedAt));

            _episodeIdsCollectedAt.Value.Add(episodeIdsCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(ITraktEpisode episode, ITraktMetadata metadata)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithEpisodeWithMetadata(new EntryWithMetadata<ITraktEpisode>(episode, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(EntryWithMetadata<ITraktEpisode> episodeWithMetadata)
        {
            if (episodeWithMetadata == null)
                throw new ArgumentNullException(nameof(episodeWithMetadata));

            _episodesWithMetadata.Value.Add(episodeWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(ITraktEpisodeIds episodeIds, ITraktMetadata metadata)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithEpisodeWithMetadata(new EntryWithMetadata<ITraktEpisodeIds>(episodeIds, metadata));
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(EntryWithMetadata<ITraktEpisodeIds> episodeIdsWithMetadata)
        {
            if (episodeIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(episodeIdsWithMetadata));

            _episodeIdsWithMetadata.Value.Add(episodeIdsWithMetadata);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(ITraktEpisode episode, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithEpisodeWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktEpisode>(episode, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktEpisode> episodeWithMetadataCollectedAt)
        {
            if (episodeWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(episodeWithMetadataCollectedAt));

            _episodesWithMetadataCollected.Value.Add(episodeWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(ITraktEpisodeIds episodeIds, ITraktMetadata metadata, DateTime collectedAt)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return WithEpisodeWithMetadataAndCollectedAt(new CollectedEntryWithMetadata<ITraktEpisodeIds>(episodeIds, metadata, collectedAt));
        }

        public ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktEpisodeIds> episodeIdsWithMetadataCollectedAt)
        {
            if (episodeIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsWithMetadataCollectedAt));

            _episodeIdsWithMetadataCollectedAt.Value.Add(episodeIdsWithMetadataCollectedAt);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (ITraktEpisode episode in episodes)
            {
                if (episode != null)
                    _episodes.Value.Add(episode);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            foreach (ITraktEpisodeIds episodeId in episodeIds)
            {
                if (episodeId != null)
                    _episodeIds.Value.Add(episodeId);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesCollectedAt(IEnumerable<CollectedEntry<ITraktEpisode>> episodesCollectedAt)
        {
            if (episodesCollectedAt == null)
                throw new ArgumentNullException(nameof(episodesCollectedAt));

            foreach (CollectedEntry<ITraktEpisode> episodeCollectedAt in episodesCollectedAt)
            {
                if (episodeCollectedAt != null)
                    _episodesCollectedAt.Value.Add(episodeCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesCollectedAt(IEnumerable<CollectedEntry<ITraktEpisodeIds>> episodeIdsCollectedAt)
        {
            if (episodeIdsCollectedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsCollectedAt));

            foreach (CollectedEntry<ITraktEpisodeIds> episodeIdCollectedAt in episodeIdsCollectedAt)
            {
                if (episodeIdCollectedAt != null)
                    _episodeIdsCollectedAt.Value.Add(episodeIdCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesWithMetadata(IEnumerable<EntryWithMetadata<ITraktEpisode>> episodesWithMetadata)
        {
            if (episodesWithMetadata == null)
                throw new ArgumentNullException(nameof(episodesWithMetadata));

            foreach (EntryWithMetadata<ITraktEpisode> episodeWithMetadata in episodesWithMetadata)
            {
                if (episodeWithMetadata != null)
                    _episodesWithMetadata.Value.Add(episodeWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesWithMetadata(IEnumerable<EntryWithMetadata<ITraktEpisodeIds>> episodeIdsWithMetadata)
        {
            if (episodeIdsWithMetadata == null)
                throw new ArgumentNullException(nameof(episodeIdsWithMetadata));

            foreach (EntryWithMetadata<ITraktEpisodeIds> episodeIdWithMetadata in episodeIdsWithMetadata)
            {
                if (episodeIdWithMetadata != null)
                    _episodeIdsWithMetadata.Value.Add(episodeIdWithMetadata);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktEpisode>> episodesWithMetadataCollectedAt)
        {
            if (episodesWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(episodesWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktEpisode> episodeWithMetadataCollected in episodesWithMetadataCollectedAt)
            {
                if (episodeWithMetadataCollected != null)
                    _episodesWithMetadataCollected.Value.Add(episodeWithMetadataCollected);
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktEpisodeIds>> episodeIdsWithMetadataCollectedAt)
        {
            if (episodeIdsWithMetadataCollectedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsWithMetadataCollectedAt));

            foreach (CollectedEntryWithMetadata<ITraktEpisodeIds> episodeIdWithMetadataCollectedAt in episodeIdsWithMetadataCollectedAt)
            {
                if (episodeIdWithMetadataCollectedAt != null)
                    _episodeIdsWithMetadataCollectedAt.Value.Add(episodeIdWithMetadataCollectedAt);
            }

            return this;
        }

        public ITraktSyncCollectionPost Build()
        {
            ITraktSyncCollectionPost syncCollectionPost = new TraktSyncCollectionPost();
            AddMovies(syncCollectionPost);
            AddShows(syncCollectionPost);
            AddSeasons(syncCollectionPost);
            AddEpisodes(syncCollectionPost);
            return syncCollectionPost;
        }

        private void AddMovies(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated && !_moviesCollectedAt.IsValueCreated
               && !_movieIdsCollectedAt.IsValueCreated && !_moviesWithMetadata.IsValueCreated && !_movieIdsWithMetadata.IsValueCreated
               && !_moviesWithMetadataCollected.IsValueCreated && !_movieIdsWithMetadataCollectedAt.IsValueCreated)
            {
                return;
            }

            syncCollectionPost.Movies ??= new List<ITraktSyncCollectionPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieIds));
                }
            }

            if (_moviesCollectedAt.IsValueCreated && _moviesCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktMovie> movieCollectedAt in _moviesCollectedAt.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieCollectedAt.Object, null, movieCollectedAt.CollectedAt));
                }
            }

            if (_movieIdsCollectedAt.IsValueCreated && _movieIdsCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktMovieIds> movieIdCollectedAt in _movieIdsCollectedAt.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieIdCollectedAt.Object, null, movieIdCollectedAt.CollectedAt));
                }
            }

            if (_moviesWithMetadata.IsValueCreated && _moviesWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktMovie> movieWithMetadata in _moviesWithMetadata.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieWithMetadata.Object, movieWithMetadata.Metadata));
                }
            }

            if (_movieIdsWithMetadata.IsValueCreated && _movieIdsWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktMovieIds> movieIdWithMetadata in _movieIdsWithMetadata.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieIdWithMetadata.Object, movieIdWithMetadata.Metadata));
                }
            }

            if (_moviesWithMetadataCollected.IsValueCreated && _moviesWithMetadataCollected.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktMovie> movieWithMetadataCollectedAt in _moviesWithMetadataCollected.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieWithMetadataCollectedAt.Object, movieWithMetadataCollectedAt.Metadata, movieWithMetadataCollectedAt.CollectedAt));
                }
            }

            if (_movieIdsWithMetadataCollectedAt.IsValueCreated && _movieIdsWithMetadataCollectedAt.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktMovieIds> movieIdWithMetadataCollectedAt in _movieIdsWithMetadataCollectedAt.Value)
                {
                    (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>)
                        .Add(CreateCollectionPostMovie(movieIdWithMetadataCollectedAt.Object, movieIdWithMetadataCollectedAt.Metadata, movieIdWithMetadataCollectedAt.CollectedAt));
                }
            }
        }

        private void AddShows(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated && !_showsCollectedAt.IsValueCreated
               && !_showIdsCollectedAt.IsValueCreated && !_showsWithMetadata.IsValueCreated && !_showIdsWithMetadata.IsValueCreated
               && !_showsWithMetadataCollected.IsValueCreated && !_showIdsWithMetadataCollectedAt.IsValueCreated
               && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
            {
                return;
            }

            syncCollectionPost.Shows ??= new List<ITraktSyncCollectionPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showIds));
                }
            }

            if (_showsCollectedAt.IsValueCreated && _showsCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktShow> showCollectedAt in _showsCollectedAt.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showCollectedAt.Object, null, showCollectedAt.CollectedAt));
                }
            }

            if (_showIdsCollectedAt.IsValueCreated && _showIdsCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktShowIds> showIdCollectedAt in _showIdsCollectedAt.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showIdCollectedAt.Object, null, showIdCollectedAt.CollectedAt));
                }
            }

            if (_showsWithMetadata.IsValueCreated && _showsWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktShow> showWithMetadata in _showsWithMetadata.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showWithMetadata.Object, showWithMetadata.Metadata));
                }
            }

            if (_showIdsWithMetadata.IsValueCreated && _showIdsWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktShowIds> showIdWithMetadata in _showIdsWithMetadata.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showIdWithMetadata.Object, showIdWithMetadata.Metadata));
                }
            }

            if (_showsWithMetadataCollected.IsValueCreated && _showsWithMetadataCollected.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktShow> showWithMetadataCollectedAt in _showsWithMetadataCollected.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showWithMetadataCollectedAt.Object, showWithMetadataCollectedAt.Metadata, showWithMetadataCollectedAt.CollectedAt));
                }
            }

            if (_showIdsWithMetadataCollectedAt.IsValueCreated && _showIdsWithMetadataCollectedAt.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktShowIds> showIdWithMetadataCollectedAt in _showIdsWithMetadataCollectedAt.Value)
                {
                    (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>)
                        .Add(CreateCollectionPostShow(showIdWithMetadataCollectedAt.Object, showIdWithMetadataCollectedAt.Metadata, showIdWithMetadataCollectedAt.CollectedAt));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateCollectionPostShowAndSeasons(syncCollectionPost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateCollectionPostShowAndSeasons(syncCollectionPost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated && !_seasonsCollectedAt.IsValueCreated
               && !_seasonIdsCollectedAt.IsValueCreated && !_seasonsWithMetadata.IsValueCreated && !_seasonIdsWithMetadata.IsValueCreated
               && !_seasonsWithMetadataCollected.IsValueCreated && !_seasonIdsWithMetadataCollectedAt.IsValueCreated)
            {
                return;
            }

            syncCollectionPost.Seasons ??= new List<ITraktSyncCollectionPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonIds));
                }
            }

            if (_seasonsCollectedAt.IsValueCreated && _seasonsCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktSeason> seasonCollectedAt in _seasonsCollectedAt.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonCollectedAt.Object, null, seasonCollectedAt.CollectedAt));
                }
            }

            if (_seasonIdsCollectedAt.IsValueCreated && _seasonIdsCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktSeasonIds> seasonIdCollectedAt in _seasonIdsCollectedAt.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonIdCollectedAt.Object, null, seasonIdCollectedAt.CollectedAt));
                }
            }

            if (_seasonsWithMetadata.IsValueCreated && _seasonsWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktSeason> seasonWithMetadata in _seasonsWithMetadata.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonWithMetadata.Object, seasonWithMetadata.Metadata));
                }
            }

            if (_seasonIdsWithMetadata.IsValueCreated && _seasonIdsWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktSeasonIds> seasonIdWithMetadata in _seasonIdsWithMetadata.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonIdWithMetadata.Object, seasonIdWithMetadata.Metadata));
                }
            }

            if (_seasonsWithMetadataCollected.IsValueCreated && _seasonsWithMetadataCollected.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktSeason> seasonWithMetadataCollectedAt in _seasonsWithMetadataCollected.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonWithMetadataCollectedAt.Object, seasonWithMetadataCollectedAt.Metadata, seasonWithMetadataCollectedAt.CollectedAt));
                }
            }

            if (_seasonIdsWithMetadataCollectedAt.IsValueCreated && _seasonIdsWithMetadataCollectedAt.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktSeasonIds> seasonIdWithMetadataCollectedAt in _seasonIdsWithMetadataCollectedAt.Value)
                {
                    (syncCollectionPost.Seasons as List<ITraktSyncCollectionPostSeason>)
                        .Add(CreateCollectionPostSeason(seasonIdWithMetadataCollectedAt.Object, seasonIdWithMetadataCollectedAt.Metadata, seasonIdWithMetadataCollectedAt.CollectedAt));
                }
            }
        }

        private void AddEpisodes(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated && !_episodesCollectedAt.IsValueCreated
               && !_episodeIdsCollectedAt.IsValueCreated && !_episodesWithMetadata.IsValueCreated && !_episodeIdsWithMetadata.IsValueCreated
               && !_episodesWithMetadataCollected.IsValueCreated && !_episodeIdsWithMetadataCollectedAt.IsValueCreated)
            {
                return;
            }

            syncCollectionPost.Episodes ??= new List<ITraktSyncCollectionPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeIds));
                }
            }

            if (_episodesCollectedAt.IsValueCreated && _episodesCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktEpisode> episodeCollectedAt in _episodesCollectedAt.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeCollectedAt.Object, null, episodeCollectedAt.CollectedAt));
                }
            }

            if (_episodeIdsCollectedAt.IsValueCreated && _episodeIdsCollectedAt.Value.Any())
            {
                foreach (CollectedEntry<ITraktEpisodeIds> episodeIdCollectedAt in _episodeIdsCollectedAt.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeIdCollectedAt.Object, null, episodeIdCollectedAt.CollectedAt));
                }
            }

            if (_episodesWithMetadata.IsValueCreated && _episodesWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktEpisode> episodeWithMetadata in _episodesWithMetadata.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeWithMetadata.Object, episodeWithMetadata.Metadata));
                }
            }

            if (_episodeIdsWithMetadata.IsValueCreated && _episodeIdsWithMetadata.Value.Any())
            {
                foreach (EntryWithMetadata<ITraktEpisodeIds> episodeIdWithMetadata in _episodeIdsWithMetadata.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeIdWithMetadata.Object, episodeIdWithMetadata.Metadata));
                }
            }

            if (_episodesWithMetadataCollected.IsValueCreated && _episodesWithMetadataCollected.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktEpisode> episodeWithMetadataCollectedAt in _episodesWithMetadataCollected.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeWithMetadataCollectedAt.Object, episodeWithMetadataCollectedAt.Metadata, episodeWithMetadataCollectedAt.CollectedAt));
                }
            }

            if (_episodeIdsWithMetadataCollectedAt.IsValueCreated && _episodeIdsWithMetadataCollectedAt.Value.Any())
            {
                foreach (CollectedEntryWithMetadata<ITraktEpisodeIds> episodeIdWithMetadataCollectedAt in _episodeIdsWithMetadataCollectedAt.Value)
                {
                    (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>)
                        .Add(CreateCollectionPostEpisode(episodeIdWithMetadataCollectedAt.Object, episodeIdWithMetadataCollectedAt.Metadata, episodeIdWithMetadataCollectedAt.CollectedAt));
                }
            }
        }

        private static ITraktSyncCollectionPostMovie CreateCollectionPostMovie(ITraktMovie movie, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostMovie syncCollectionPostMovie = new TraktSyncCollectionPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostMovie.CollectedAt = collectedAt.Value;

            return syncCollectionPostMovie;
        }

        private static ITraktSyncCollectionPostMovie CreateCollectionPostMovie(ITraktMovieIds movieIds, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostMovie syncCollectionPostMovie = new TraktSyncCollectionPostMovie
            {
                Ids = movieIds,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostMovie.CollectedAt = collectedAt.Value;

            return syncCollectionPostMovie;
        }

        private static ITraktSyncCollectionPostShow CreateCollectionPostShow(ITraktShow show, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostShow syncCollectionPostShow = new TraktSyncCollectionPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostShow.CollectedAt = collectedAt.Value;

            return syncCollectionPostShow;
        }

        private static ITraktSyncCollectionPostShow CreateCollectionPostShow(ITraktShowIds showIds, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostShow syncCollectionPostShow = new TraktSyncCollectionPostShow
            {
                Ids = showIds,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostShow.CollectedAt = collectedAt.Value;

            return syncCollectionPostShow;
        }

        private static void CreateCollectionPostShowAndSeasons<T>(ITraktSyncCollectionPost syncCollectionPost, List<CollectionShowAndSeasons<T>> showsAndSeasons)
        {
            foreach (CollectionShowAndSeasons<T> showAndSeasons in showsAndSeasons)
            {
                ITraktSyncCollectionPostShow syncCollectionPostShow;

                if (typeof(T) == typeof(ITraktShow))
                    syncCollectionPostShow = CreateCollectionPostShow(showAndSeasons.Object as ITraktShow);
                else
                    syncCollectionPostShow = CreateCollectionPostShow(showAndSeasons.Object as ITraktShowIds);

                Debug.Assert(syncCollectionPost != null);

                if (showAndSeasons.Seasons.Count() > 0)
                {
                    foreach (PostCollectionSeason season in showAndSeasons.Seasons)
                    {
                        ITraktSyncCollectionPostShowSeason syncCollectionPostShowSeason = CreateCollectionPostShowSeason(season);

                        if (season.Episodes != null && season.Episodes.Count() > 0)
                        {
                            foreach (PostCollectionEpisode episode in season.Episodes)
                            {
                                (syncCollectionPostShowSeason.Episodes as List<ITraktSyncCollectionPostShowEpisode>)
                                    .Add(CreateCollectionPostShowEpisode(episode));
                            }
                        }

                        (syncCollectionPostShow.Seasons as List<ITraktSyncCollectionPostShowSeason>).Add(syncCollectionPostShowSeason);
                    }
                }

                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(syncCollectionPostShow);
            }
        }

        private static ITraktSyncCollectionPostShowSeason CreateCollectionPostShowSeason(PostCollectionSeason season)
        {
            ITraktSyncCollectionPostShowSeason syncCollectionPostShowSeason = new TraktSyncCollectionPostShowSeason
            {
                Number = season.Number,
                MediaType = season.Metadata?.MediaType,
                MediaResolution = season.Metadata?.MediaResolution,
                Audio = season.Metadata?.Audio,
                AudioChannels = season.Metadata?.AudioChannels,
                ThreeDimensional = season.Metadata?.ThreeDimensional,
                HDR = season.Metadata?.HDR
            };

            if (season.CollectedAt.HasValue)
                syncCollectionPostShowSeason.CollectedAt = season.CollectedAt.Value;

            return syncCollectionPostShowSeason;
        }

        private static ITraktSyncCollectionPostShowEpisode CreateCollectionPostShowEpisode(PostCollectionEpisode episode)
        {
            var syncCollectionPostShowEpisode = new TraktSyncCollectionPostShowEpisode
            {
                Number = episode.Number,
                MediaType = episode.Metadata?.MediaType,
                MediaResolution = episode.Metadata?.MediaResolution,
                Audio = episode.Metadata?.Audio,
                AudioChannels = episode.Metadata?.AudioChannels,
                ThreeDimensional = episode.Metadata?.ThreeDimensional,
                HDR = episode.Metadata?.HDR
            };

            if (episode.CollectedAt.HasValue)
                syncCollectionPostShowEpisode.CollectedAt = episode.CollectedAt.Value;

            return syncCollectionPostShowEpisode;
        }

        private static ITraktSyncCollectionPostSeason CreateCollectionPostSeason(ITraktSeason season, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostSeason syncCollectionPostSeason = new TraktSyncCollectionPostSeason
            {
                Ids = season.Ids,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostSeason.CollectedAt = collectedAt.Value;

            return syncCollectionPostSeason;
        }

        private static ITraktSyncCollectionPostSeason CreateCollectionPostSeason(ITraktSeasonIds seasonIds, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostSeason syncCollectionPostSeason = new TraktSyncCollectionPostSeason
            {
                Ids = seasonIds,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostSeason.CollectedAt = collectedAt.Value;

            return syncCollectionPostSeason;
        }

        private static ITraktSyncCollectionPostEpisode CreateCollectionPostEpisode(ITraktEpisode episode, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostEpisode syncCollectionPostEpisode = new TraktSyncCollectionPostEpisode
            {
                Ids = episode.Ids,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostEpisode.CollectedAt = collectedAt.Value;

            return syncCollectionPostEpisode;
        }

        private static ITraktSyncCollectionPostEpisode CreateCollectionPostEpisode(ITraktEpisodeIds episodeIds, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            ITraktSyncCollectionPostEpisode syncCollectionPostEpisode = new TraktSyncCollectionPostEpisode
            {
                Ids = episodeIds,
                MediaType = metadata?.MediaType,
                MediaResolution = metadata?.MediaResolution,
                Audio = metadata?.Audio,
                AudioChannels = metadata?.AudioChannels,
                ThreeDimensional = metadata?.ThreeDimensional,
                HDR = metadata?.HDR
            };

            if (collectedAt.HasValue)
                syncCollectionPostEpisode.CollectedAt = collectedAt.Value;

            return syncCollectionPostEpisode;
        }
    }
}
