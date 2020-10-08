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

        public ITraktPostBuilderEpisodeAddedCollectedAt<ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost> AddEpisode(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderMovieAddedCollectedAt<ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost> AddMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>, ITraktSyncCollectionPost, PostSeasons> AddShow(ITraktShow show)
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

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows)
        {
            throw new NotImplementedException();
        }

        public ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderEpisodeAddedMetadata<ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost> ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>.AddEpisode(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderMovieAddedMetadata<ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost> ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>.AddMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>, ITraktSyncCollectionPost, PostSeasons> ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>.AddShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>, ITraktSyncCollectionPost, PostSeasons> ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>.AddShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithEpisode(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithEpisode(ITraktEpisode episode)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithMovie(ITraktMovie movie)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithCollectedAt<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost> ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithMetadata<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost>, ITraktSyncCollectionPost>.WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>, ITraktSyncCollectionPost>.WithShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>, ITraktSyncCollectionPost>.WithShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }

        ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons> ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<ITraktSyncCollectionPostBuilder, ITraktSyncCollectionPost, PostSeasons>, ITraktSyncCollectionPost>.WithShow(ITraktShow show)
        {
            throw new NotImplementedException();
        }
    }
}
