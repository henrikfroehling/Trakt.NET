namespace TraktNet.Objects.Post.Tests.Syncs.Ratings.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("Objects.Post.Syncs.Ratings.Implementations")]
    public class TraktSyncRatingsPost_Tests
    {
        [Fact]
        public void Test_TraktSyncRatingsPost_Validate()
        {
            ITraktSyncRatingsPost syncRatingsPost = new TraktSyncRatingsPost();

            // movies = null, shows = null, episodes = null
            Action act = () => syncRatingsPost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, episodes = null
            syncRatingsPost.Movies = new List<ITraktSyncRatingsPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = null
            syncRatingsPost.Shows = new List<ITraktSyncRatingsPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = empty
            syncRatingsPost.Episodes = new List<ITraktSyncRatingsPostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, episodes = empty
            (syncRatingsPost.Movies as List<ITraktSyncRatingsPostMovie>).Add(new TraktSyncRatingsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, episodes = empty
            (syncRatingsPost.Movies as List<ITraktSyncRatingsPostMovie>).Clear();
            (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Add(new TraktSyncRatingsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, episodes with at least one item
            (syncRatingsPost.Shows as List<ITraktSyncRatingsPostShow>).Clear();
            (syncRatingsPost.Episodes as List<ITraktSyncRatingsPostEpisode>).Add(new TraktSyncRatingsPostEpisode());
            act.Should().NotThrow();
        }
    }
}
