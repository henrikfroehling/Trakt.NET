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
            _collectedMovies = new TraktPostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _moviesAndMetadata = new TraktPostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _collectedShows = new TraktPostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _collectedShowsWithSeasons = new TraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _collectedShowsWithSeasonsCollection = new TraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>();
            _showsAndMetadata = new TraktPostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _showsAndMetadataWithSeasons = new TraktPostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _showsAndMetadataWithSeasonsCollection = new TraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>();
            _showsWithSeasons = new TraktPostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _showsWithSeasonsCollection = new TraktPostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>();
            _collectedEpisodes = new TraktPostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
            _episodesAndMetadata = new TraktPostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>();
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
            return _collectedMovies;
        }

        public ITraktPostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddMovieAndMetadata(ITraktMovie movie)
        {
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
            return _collectedShows;
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedShowAndSeasons(ITraktShow show)
        {
            return _collectedShowsWithSeasons;
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddCollectedShowAndSeasonsCollection(ITraktShow show)
        {
            return _collectedShowsWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndMetadata(ITraktShow show)
        {
            return _showsAndMetadata;
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndMetadataAndSeasons(ITraktShow show)
        {
            return _showsAndMetadataWithSeasons;
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddShowAndMetadataAndSeasonsCollection(ITraktShow show)
        {
            return _showsAndMetadataWithSeasonsCollection;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndSeasons(ITraktShow show)
        {
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
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
            return _collectedEpisodes;
        }

        public ITraktPostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddEpisodeAndMetadata(ITraktEpisode episode)
        {
            return _episodesAndMetadata;
        }

        public ITraktSyncCollectionPost Build()
        {
            return new TraktSyncCollectionPost();
        }

    }
}
