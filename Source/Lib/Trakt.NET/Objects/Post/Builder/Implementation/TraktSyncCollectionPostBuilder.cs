namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Interfaces;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Builder.Interfaces.Capabilities;
    using Objects.Post.Syncs.Collection;
    using System;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostBuilder : ITraktSyncCollectionPostBuilder
    {
        internal TraktSyncCollectionPostBuilder()
        {
        }

        public ITraktPostBuilderEpisodeAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedEpisode(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddCollectedShowAndSeasons(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddCollectedShowAndSeasonsCollection(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderEpisodeAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddEpisodeAndMetadata(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddMovieAndMetadata(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndMetadata(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndMetadataAndSeasons(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddShowAndMetadataAndSeasonsCollection(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> AddShowAndSeasons(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPost Build()
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows)
        {
            throw new NotImplementedException();
        }
    }
}
