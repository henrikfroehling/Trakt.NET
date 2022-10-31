namespace TraktNet.Objects.Post.Tests.Syncs.Watchlist.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Watchlist.Implementations")]
    public class TraktSyncWatchlistPost_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistPost_Validate()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = new TraktSyncWatchlistPost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncWatchlistPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncWatchlistPost.Movies = new List<ITraktSyncWatchlistPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncWatchlistPost.Shows = new List<ITraktSyncWatchlistPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncWatchlistPost.Seasons = new List<ITraktSyncWatchlistPostSeason>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncWatchlistPost.Episodes = new List<ITraktSyncWatchlistPostEpisode>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Add(new TraktSyncWatchlistPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Clear();
            (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(new TraktSyncWatchlistPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Clear();
            (syncWatchlistPost.Seasons as List<ITraktSyncWatchlistPostSeason>).Add(new TraktSyncWatchlistPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            (syncWatchlistPost.Seasons as List<ITraktSyncWatchlistPostSeason>).Clear();
            (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>).Add(new TraktSyncWatchlistPostEpisode());
            act.Should().NotThrow();
        }
    }
}
