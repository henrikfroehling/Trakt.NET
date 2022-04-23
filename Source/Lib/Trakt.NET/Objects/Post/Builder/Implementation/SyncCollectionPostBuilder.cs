﻿namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using Helper;
    using Objects.Basic;
    using Post.Syncs.Collection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class SyncCollectionPostBuilder : ITraktSyncCollectionPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<PostBuilderObjectWithMetadata<ITraktMovie>> _moviesWithMetadata;
        private readonly List<ITraktShow> _shows;
        private readonly List<PostBuilderObjectWithMetadata<ITraktShow>> _showsWithMetadata;
        private readonly List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons>> _showsWithMetadataAndSeasonsCollection;
        private readonly List<ITraktEpisode> _episodes;
        private readonly List<PostBuilderObjectWithMetadata<ITraktEpisode>> _episodesWithMetadata;
        private readonly PostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedMovies;
        private readonly PostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _moviesAndMetadata;
        private readonly PostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedShows;
        private readonly PostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedShowsWithSeasons;
        private readonly PostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> _collectedShowsWithSeasonsCollection;
        private readonly PostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _showsAndMetadata;
        private readonly PostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _showsAndMetadataWithSeasons;
        private readonly PostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> _showsAndMetadataWithSeasonsCollection;
        private readonly PostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> _showsWithSeasonsCollection;
        private readonly PostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedEpisodes;
        private readonly PostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _episodesAndMetadata;

        internal SyncCollectionPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _moviesWithMetadata = new List<PostBuilderObjectWithMetadata<ITraktMovie>>();
            _shows = new List<ITraktShow>();
            _showsWithMetadata = new List<PostBuilderObjectWithMetadata<ITraktShow>>();
            _showsWithMetadataAndSeasonsCollection = new List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons>>();
            _episodes = new List<ITraktEpisode>();
            _episodesWithMetadata = new List<PostBuilderObjectWithMetadata<ITraktEpisode>>();
            _collectedMovies = new PostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _moviesAndMetadata = new PostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _collectedShows = new PostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _collectedShowsWithSeasons = new PostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _collectedShowsWithSeasonsCollection = new PostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>(this);
            _showsAndMetadata = new PostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _showsAndMetadataWithSeasons = new PostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _showsAndMetadataWithSeasonsCollection = new PostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>(this);
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>(this);
            _collectedEpisodes = new PostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
            _episodesAndMetadata = new PostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>(this);
        }

        public ITraktSyncCollectionPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata>> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (var tuple in movies)
            {
                _moviesWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktMovie>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (var tuple in movies)
            {
                _moviesWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktMovie>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2,
                    CollectedAt = tuple.Item3
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithCollectedMovies(IEnumerable<Tuple<ITraktMovie, DateTime?>> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (var tuple in movies)
            {
                _moviesWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktMovie>
                {
                    Object = tuple.Item1,
                    CollectedAt = tuple.Item2
                });
            }

            return this;
        }

        public ITraktPostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithCollectedMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _collectedMovies.SetCurrentMovie(movie);
            return _collectedMovies;
        }

        public ITraktPostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithMovieAndMetadata(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _moviesAndMetadata.SetCurrentMovie(movie);
            return _moviesAndMetadata;
        }

        public ITraktSyncCollectionPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (var tuple in shows)
            {
                _showsWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktShow>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (var tuple in shows)
            {
                _showsWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktShow>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2,
                    CollectedAt = tuple.Item3
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, PostSeasons>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (var tuple in shows)
            {
                _showsWithMetadataAndSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2,
                    Seasons = tuple.Item3
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (var tuple in shows)
            {
                _showsWithMetadataAndSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2,
                    CollectedAt = tuple.Item3,
                    Seasons = tuple.Item4
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithCollectedShows(IEnumerable<Tuple<ITraktShow, DateTime?>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (var tuple in shows)
            {
                _showsWithMetadataAndSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons>
                {
                    Object = tuple.Item1,
                    CollectedAt = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithCollectedShows(IEnumerable<Tuple<ITraktShow, DateTime?, PostSeasons>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (var tuple in shows)
            {
                _showsWithMetadataAndSeasonsCollection.Add(new PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons>
                {
                    Object = tuple.Item1,
                    CollectedAt = tuple.Item2,
                    Seasons = tuple.Item3
                });
            }

            return this;
        }

        public ITraktPostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithCollectedShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _collectedShows.SetCurrentShow(show);
            return _collectedShows;
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithCollectedShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _collectedShowsWithSeasons.SetCurrentShow(show);
            return _collectedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> WithCollectedShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _collectedShowsWithSeasonsCollection.SetCurrentShow(show);
            return _collectedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithShowAndMetadata(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsAndMetadata.SetCurrentShow(show);
            return _showsAndMetadata;
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithShowAndMetadataAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsAndMetadataWithSeasons.SetCurrentShow(show);
            return _showsAndMetadataWithSeasons;
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> WithShowAndMetadataAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsAndMetadataWithSeasonsCollection.SetCurrentShow(show);
            return _showsAndMetadataWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> WithShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata>> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (var tuple in episodes)
            {
                _episodesWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (var tuple in episodes)
            {
                _episodesWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
                {
                    Object = tuple.Item1,
                    Metadata = tuple.Item2,
                    CollectedAt = tuple.Item3
                });
            }

            return this;
        }

        public ITraktSyncCollectionPostBuilder WithCollectedEpisodes(IEnumerable<Tuple<ITraktEpisode, DateTime?>> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (var tuple in episodes)
            {
                _episodesWithMetadata.Add(new PostBuilderObjectWithMetadata<ITraktEpisode>
                {
                    Object = tuple.Item1,
                    CollectedAt = tuple.Item2
                });
            }

            return this;
        }

        public ITraktPostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithCollectedEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _collectedEpisodes.SetCurrentEpisode(episode);
            return _collectedEpisodes;
        }

        public ITraktPostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> WithEpisodeAndMetadata(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodesAndMetadata.SetCurrentEpisode(episode);
            return _episodesAndMetadata;
        }

        public ITraktSyncCollectionPost Build()
        {
            ITraktSyncCollectionPost syncCollectionPost = new TraktSyncCollectionPost();
            AddMovies(syncCollectionPost);
            AddShows(syncCollectionPost);
            AddEpisodes(syncCollectionPost);
            return syncCollectionPost;
        }

        private void AddMovies(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (syncCollectionPost.Movies == null)
                syncCollectionPost.Movies = new List<ITraktSyncCollectionPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>).Add(CreateSyncCollectionPostMovie(movie));

            foreach (PostBuilderObjectWithMetadata<ITraktMovie> movieEntry in _moviesWithMetadata)
                (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>).Add(CreateSyncCollectionPostMovie(movieEntry.Object, movieEntry.Metadata, movieEntry.CollectedAt));

            foreach (PostBuilderCollectedObject<ITraktMovie> movieEntry in _collectedMovies.CollectedMovies)
                (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>).Add(CreateSyncCollectionPostMovie(movieEntry.Object, null, movieEntry.CollectedAt));

            foreach (PostBuilderObjectWithMetadata<ITraktMovie> movieEntry in _moviesAndMetadata.MoviesAndMetadata)
                (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>).Add(CreateSyncCollectionPostMovie(movieEntry.Object, movieEntry.Metadata, movieEntry.CollectedAt));
        }

        private void AddShows(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (syncCollectionPost.Shows == null)
                syncCollectionPost.Shows = new List<ITraktSyncCollectionPostShow>();

            foreach (ITraktShow show in _shows)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShow(show));

            foreach (PostBuilderObjectWithMetadata<ITraktShow> showEntry in _showsWithMetadata)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShow(showEntry.Object, showEntry.Metadata, showEntry.CollectedAt));

            foreach (PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons> showEntry in _showsWithMetadataAndSeasonsCollection)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasonsCollection(showEntry.Object, showEntry.Metadata, showEntry.CollectedAt, showEntry.Seasons));

            foreach (PostBuilderCollectedObject<ITraktShow> showEntry in _collectedShows.CollectedShows)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShow(showEntry.Object, null, showEntry.CollectedAt));

            foreach (PostBuilderCollectedObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _collectedShowsWithSeasons.CollectedShowsWithSeasons)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasons(showEntry.Object, null, showEntry.CollectedAt, showEntry.Seasons));

            foreach (PostBuilderCollectedObjectWithSeasons<ITraktShow, PostSeasons> showEntry in _collectedShowsWithSeasonsCollection.CollectedShowsWithSeasonsCollection)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasonsCollection(showEntry.Object, null, showEntry.CollectedAt, showEntry.Seasons));

            foreach (PostBuilderObjectWithMetadata<ITraktShow> showEntry in _showsAndMetadata.ShowsAndMetadata)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShow(showEntry.Object, showEntry.Metadata, showEntry.CollectedAt));

            foreach (PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsAndMetadataWithSeasons.ShowsAndMetadataWithSeasons)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasons(showEntry.Object, showEntry.Metadata, showEntry.CollectedAt, showEntry.Seasons));

            foreach (PostBuilderObjectWithMetadataAndSeasons<ITraktShow, PostSeasons> showEntry in _showsAndMetadataWithSeasonsCollection.ShowsAndMetadataWithSeasonsCollection)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasonsCollection(showEntry.Object, showEntry.Metadata, showEntry.CollectedAt, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasons(showEntry.Object, null, null, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostSeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(CreateSyncCollectionPostShowWithSeasonsCollection(showEntry.Object, null, null, showEntry.Seasons));
        }

        private void AddEpisodes(ITraktSyncCollectionPost syncCollectionPost)
        {
            if (syncCollectionPost.Episodes == null)
                syncCollectionPost.Episodes = new List<ITraktSyncCollectionPostEpisode>();

            foreach (ITraktEpisode episode in _episodes)
                (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>).Add(CreateSyncCollectionPostEpisode(episode));

            foreach (PostBuilderObjectWithMetadata<ITraktEpisode> episodeEntry in _episodesWithMetadata)
                (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>).Add(CreateSyncCollectionPostEpisode(episodeEntry.Object, episodeEntry.Metadata, episodeEntry.CollectedAt));

            foreach (PostBuilderCollectedObject<ITraktEpisode> episodeEntry in _collectedEpisodes.CollectedEpisodes)
                (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>).Add(CreateSyncCollectionPostEpisode(episodeEntry.Object, null, episodeEntry.CollectedAt));

            foreach (PostBuilderObjectWithMetadata<ITraktEpisode> episodeEntry in _episodesAndMetadata.EpisodesAndMetadata)
                (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>).Add(CreateSyncCollectionPostEpisode(episodeEntry.Object, episodeEntry.Metadata, episodeEntry.CollectedAt));
        }

        private ITraktSyncCollectionPostMovie CreateSyncCollectionPostMovie(ITraktMovie movie, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            var syncCollectionPostMovie = new TraktSyncCollectionPostMovie
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
                syncCollectionPostMovie.CollectedAt = collectedAt.Value.ToUniversalTime();

            return syncCollectionPostMovie;
        }

        private ITraktSyncCollectionPostShow CreateSyncCollectionPostShow(ITraktShow show, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            var syncCollectionPostShow = new TraktSyncCollectionPostShow
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
                syncCollectionPostShow.CollectedAt = collectedAt.Value.ToUniversalTime();

            return syncCollectionPostShow;
        }

        private ITraktSyncCollectionPostShow CreateSyncCollectionPostShowWithSeasons(ITraktShow show, ITraktMetadata metadata = null, DateTime? collectedAt = null, IEnumerable<int> seasons = null)
        {
            var syncCollectionPostShow = CreateSyncCollectionPostShow(show, metadata, collectedAt);

            if (seasons != null)
                syncCollectionPostShow.Seasons = CreateSyncCollectionPostShowSeasons(seasons);

            return syncCollectionPostShow;
        }

        private ITraktSyncCollectionPostShow CreateSyncCollectionPostShowWithSeasonsCollection(ITraktShow show, ITraktMetadata metadata = null, DateTime? collectedAt = null, PostSeasons seasons = null)
        {
            var syncCollectionPostShow = CreateSyncCollectionPostShow(show, metadata, collectedAt);

            if (seasons != null)
                syncCollectionPostShow.Seasons = CreateSyncCollectionPostShowSeasons(seasons);
            
            return syncCollectionPostShow;
        }

        private IEnumerable<ITraktSyncCollectionPostShowSeason> CreateSyncCollectionPostShowSeasons(IEnumerable<int> seasons)
        {
            var syncCollectionPostShowSeasons = new List<ITraktSyncCollectionPostShowSeason>();

            foreach (int season in seasons)
            {
                syncCollectionPostShowSeasons.Add(new TraktSyncCollectionPostShowSeason
                {
                    Number = season
                });
            }

            return syncCollectionPostShowSeasons;
        }

        private IEnumerable<ITraktSyncCollectionPostShowSeason> CreateSyncCollectionPostShowSeasons(PostSeasons seasons)
        {
            var syncCollectionPostShowSeasons = new List<ITraktSyncCollectionPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                var syncCollectionPostShowSeason = new TraktSyncCollectionPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var syncCollectionPostShowEpisodes = new List<ITraktSyncCollectionPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        syncCollectionPostShowEpisodes.Add(new TraktSyncCollectionPostShowEpisode
                        {
                            Number = episode.Number,
                            MediaType = episode.Metadata?.MediaType,
                            MediaResolution = episode.Metadata?.MediaResolution,
                            Audio = episode.Metadata?.Audio,
                            AudioChannels = episode.Metadata?.AudioChannels,
                            ThreeDimensional = episode.Metadata?.ThreeDimensional,
                            HDR = episode.Metadata?.HDR,
                            CollectedAt = episode.At
                        });
                    }

                    syncCollectionPostShowSeason.Episodes = syncCollectionPostShowEpisodes;
                }

                syncCollectionPostShowSeasons.Add(syncCollectionPostShowSeason);
            }

            return syncCollectionPostShowSeasons;
        }

        private ITraktSyncCollectionPostEpisode CreateSyncCollectionPostEpisode(ITraktEpisode episode, ITraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            var syncCollectionPostEpisode = new TraktSyncCollectionPostEpisode
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
                syncCollectionPostEpisode.CollectedAt = collectedAt.Value.ToUniversalTime();

            return syncCollectionPostEpisode;
        }
    }
}
