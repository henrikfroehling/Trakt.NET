namespace TraktNet.Objects.Post.Tests.Syncs.Watchlist.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("Objects.Post.Syncs.Watchlist.Implementations")]
    public class TraktSyncWatchlistPost_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistPost_Validate()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = new TraktSyncWatchlistPost();

            // movies = null, shows = null, episodes = null
            Action act = () => syncWatchlistPost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, episodes = null
            syncWatchlistPost.Movies = new List<ITraktSyncWatchlistPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = null
            syncWatchlistPost.Shows = new List<ITraktSyncWatchlistPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = empty
            syncWatchlistPost.Episodes = new List<ITraktSyncWatchlistPostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, episodes = empty
            (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Add(new TraktSyncWatchlistPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, episodes = empty
            (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Clear();
            (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(new TraktSyncWatchlistPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, episodes with at least one item
            (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Clear();
            (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>).Add(new TraktSyncWatchlistPostEpisode());
            act.Should().NotThrow();
        }
    }
}
