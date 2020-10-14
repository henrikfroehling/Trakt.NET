namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Helper;
    using Interfaces;
    using Interfaces.Capabilities;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Syncs.Collection;
    using System;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostBuilder : ITraktSyncCollectionPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> _moviesWithMetadata;
        private readonly List<ITraktShow> _shows;
        private readonly List<Tuple<ITraktShow, ITraktMetadata, DateTime?>> _showsWithMetadata;
        private readonly List<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> _showsWithMetadataAndSeasonsCollection;
        private readonly List<ITraktEpisode> _episodes;
        private readonly List<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> _episodesWithMetadata;
        private readonly ITraktPostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedMovies;
        private readonly ITraktPostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _moviesAndMetadata;
        private readonly ITraktPostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedShows;
        private readonly ITraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedShowsWithSeasons;
        private readonly ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> _collectedShowsWithSeasonsCollection;
        private readonly ITraktPostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _showsAndMetadata;
        private readonly ITraktPostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _showsAndMetadataWithSeasons;
        private readonly ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> _showsAndMetadataWithSeasonsCollection;
        private readonly ITraktPostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _showsWithSeasons;
        private readonly ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> _showsWithSeasonsCollection;
        private readonly ITraktPostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _collectedEpisodes;
        private readonly ITraktPostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> _episodesAndMetadata;

        internal TraktSyncCollectionPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _moviesWithMetadata = new List<Tuple<ITraktMovie, ITraktMetadata, DateTime?>>();
            _shows = new List<ITraktShow>();
            _showsWithMetadata = new List<Tuple<ITraktShow, ITraktMetadata, DateTime?>>();
            _showsWithMetadataAndSeasonsCollection = new List<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>>();
            _episodes = new List<ITraktEpisode>();
            _episodesWithMetadata = new List<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>>();
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
            _movies.Add(movie);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            _movies.AddRange(movies);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies)
        {
            _moviesWithMetadata.AddRange(movies);
            return this;
        }

        public ITraktPostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedMovie(ITraktMovie movie)
        {
            _collectedMovies.SetCurrentMovie(movie);
            return _collectedMovies;
        }

        public ITraktPostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddMovieAndMetadata(ITraktMovie movie)
        {
            _moviesAndMetadata.SetCurrentMovie(movie);
            return _moviesAndMetadata;
        }

        public ITraktSyncCollectionPostBuilder WithShow(ITraktShow show)
        {
            _shows.Add(show);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            _shows.AddRange(shows);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows)
        {
            _showsWithMetadata.AddRange(shows);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows)
        {
            _showsWithMetadataAndSeasonsCollection.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedShow(ITraktShow show)
        {
            _collectedShows.SetCurrentShow(show);
            return _collectedShows;
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedShowAndSeasons(ITraktShow show)
        {
            _collectedShowsWithSeasons.SetCurrentShow(show);
            return _collectedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddCollectedShowAndSeasonsCollection(ITraktShow show)
        {
            _collectedShowsWithSeasonsCollection.SetCurrentShow(show);
            return _collectedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndMetadata(ITraktShow show)
        {
            _showsAndMetadata.SetCurrentShow(show);
            return _showsAndMetadata;
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndMetadataAndSeasons(ITraktShow show)
        {
            _showsAndMetadataWithSeasons.SetCurrentShow(show);
            return _showsAndMetadataWithSeasons;
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddShowAndMetadataAndSeasonsCollection(ITraktShow show)
        {
            _showsAndMetadataWithSeasonsCollection.SetCurrentShow(show);
            return _showsAndMetadataWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndSeasons(ITraktShow show)
        {
            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisode episode)
        {
            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes)
        {
            _episodesWithMetadata.AddRange(episodes);
            return this;
        }

        public ITraktPostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedEpisode(ITraktEpisode episode)
        {
            _collectedEpisodes.SetCurrentEpisode(episode);
            return _collectedEpisodes;
        }

        public ITraktPostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddEpisodeAndMetadata(ITraktEpisode episode)
        {
            _episodesAndMetadata.SetCurrentEpisode(episode);
            return _episodesAndMetadata;
        }

        public ITraktSyncCollectionPost Build()
        {
            return new TraktSyncCollectionPost();
        }

    }
}
