namespace TraktNet.Objects.Post.Tests.Syncs.Collection.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Syncs.Collection.Implementations")]
    public class TraktSyncCollectionPost_Tests
    {
        [Fact]
        public void Test_TraktSyncCollectionPost_Validate()
        {
            ITraktSyncCollectionPost syncCollectionPost = new TraktSyncCollectionPost();

            // movies = null, shows = null, episodes = null
            Action act = () => syncCollectionPost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, episodes = null
            syncCollectionPost.Movies = new List<ITraktSyncCollectionPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = null
            syncCollectionPost.Shows = new List<ITraktSyncCollectionPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = empty
            syncCollectionPost.Episodes = new List<ITraktSyncCollectionPostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, episodes = empty
            (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>).Add(new TraktSyncCollectionPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, episodes = empty
            (syncCollectionPost.Movies as List<ITraktSyncCollectionPostMovie>).Clear();
            (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Add(new TraktSyncCollectionPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, episodes with at least one item
            (syncCollectionPost.Shows as List<ITraktSyncCollectionPostShow>).Clear();
            (syncCollectionPost.Episodes as List<ITraktSyncCollectionPostEpisode>).Add(new TraktSyncCollectionPostEpisode());
            act.Should().NotThrow();
        }
    }
}
