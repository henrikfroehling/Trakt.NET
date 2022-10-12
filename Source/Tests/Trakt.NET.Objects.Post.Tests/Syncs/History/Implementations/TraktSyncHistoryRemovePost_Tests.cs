namespace TraktNet.Objects.Post.Tests.Syncs.History.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Syncs.History.Implementations")]
    public class TraktSyncHistoryRemovePost_Tests
    {
        [Fact]
        public void Test_TraktSyncHistoryRemovePost_Validate()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = new TraktSyncHistoryRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null, history ids = null
            Action act = () => syncHistoryRemovePost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, seasons = null, episodes = null, history ids = null
            syncHistoryRemovePost.Movies = new List<ITraktSyncHistoryRemovePostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = null, episodes = null, history ids = null
            syncHistoryRemovePost.Shows = new List<ITraktSyncHistoryRemovePostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null, history ids = null
            syncHistoryRemovePost.Seasons = new List<ITraktSyncHistoryRemovePostSeason>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, history ids = null
            syncHistoryRemovePost.Episodes = new List<ITraktSyncHistoryRemovePostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, history ids = empty
            syncHistoryRemovePost.HistoryIds = new List<ulong>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty, history ids = empty
            (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryRemovePostMovie>).Add(new TraktSyncHistoryRemovePostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty, history ids = empty
            (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryRemovePostMovie>).Clear();
            (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryRemovePostShow>).Add(new TraktSyncHistoryRemovePostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty, history ids = empty
            (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryRemovePostShow>).Clear();
            (syncHistoryRemovePost.Seasons as List<ITraktSyncHistoryRemovePostSeason>).Add(new TraktSyncHistoryRemovePostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item, history ids = empty
            (syncHistoryRemovePost.Seasons as List<ITraktSyncHistoryRemovePostSeason>).Clear();
            (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryRemovePostEpisode>).Add(new TraktSyncHistoryRemovePostEpisode());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, history ids with at least one item
            (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryRemovePostEpisode>).Clear();
            (syncHistoryRemovePost.HistoryIds as List<ulong>).Add(10);
            act.Should().NotThrow();
        }
    }
}
