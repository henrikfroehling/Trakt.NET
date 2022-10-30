namespace TraktNet.Objects.Post.Tests.Syncs.Collection.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Syncs.Collection.Implementations")]
    public class TraktSyncCollectionRemovePost_Tests
    {
        [Fact]
        public void Test_TraktSyncCollectionRemovePost_Validate()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = new TraktSyncCollectionRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncCollectionRemovePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncCollectionRemovePost.Movies = new List<ITraktSyncCollectionPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncCollectionRemovePost.Shows = new List<ITraktSyncCollectionPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncCollectionRemovePost.Seasons = new List<ITraktSyncCollectionPostSeason>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncCollectionRemovePost.Episodes = new List<ITraktSyncCollectionPostEpisode>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            (syncCollectionRemovePost.Movies as List<ITraktSyncCollectionPostMovie>).Add(new TraktSyncCollectionPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            (syncCollectionRemovePost.Movies as List<ITraktSyncCollectionPostMovie>).Clear();
            (syncCollectionRemovePost.Shows as List<ITraktSyncCollectionPostShow>).Add(new TraktSyncCollectionPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            (syncCollectionRemovePost.Shows as List<ITraktSyncCollectionPostShow>).Clear();
            (syncCollectionRemovePost.Seasons as List<ITraktSyncCollectionPostSeason>).Add(new TraktSyncCollectionPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            (syncCollectionRemovePost.Seasons as List<ITraktSyncCollectionPostSeason>).Clear();
            (syncCollectionRemovePost.Episodes as List<ITraktSyncCollectionPostEpisode>).Add(new TraktSyncCollectionPostEpisode());
            act.Should().NotThrow();
        }
    }
}
