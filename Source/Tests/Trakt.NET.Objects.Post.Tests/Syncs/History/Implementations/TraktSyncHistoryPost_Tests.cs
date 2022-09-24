namespace TraktNet.Objects.Post.Tests.Syncs.History.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Syncs.History.Implementations")]
    public class TraktSyncHistoryPost_Tests
    {
        [Fact]
        public void Test_TraktSyncHistoryPost_Validate()
        {
            ITraktSyncHistoryPost syncHistoryPost = new TraktSyncHistoryPost();

            // movies = null, shows = null, episodes = null
            Action act = () => syncHistoryPost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, episodes = null
            syncHistoryPost.Movies = new List<ITraktSyncHistoryPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = null
            syncHistoryPost.Shows = new List<ITraktSyncHistoryPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = empty
            syncHistoryPost.Episodes = new List<ITraktSyncHistoryPostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, episodes = empty
            (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>).Add(new TraktSyncHistoryPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, episodes = empty
            (syncHistoryPost.Movies as List<ITraktSyncHistoryPostMovie>).Clear();
            (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Add(new TraktSyncHistoryPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, episodes with at least one item
            (syncHistoryPost.Shows as List<ITraktSyncHistoryPostShow>).Clear();
            (syncHistoryPost.Episodes as List<ITraktSyncHistoryPostEpisode>).Add(new TraktSyncHistoryPostEpisode());
            act.Should().NotThrow();
        }
    }
}
