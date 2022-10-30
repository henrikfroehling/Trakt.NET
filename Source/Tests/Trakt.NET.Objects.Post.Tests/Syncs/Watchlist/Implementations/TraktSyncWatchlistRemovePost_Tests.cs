namespace TraktNet.Objects.Post.Tests.Syncs.Watchlist.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("Objects.Post.Syncs.Watchlist.Implementations")]
    public class TraktSyncWatchlistRemovePost_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistRemovePost_Validate()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = new TraktSyncWatchlistRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncWatchlistRemovePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncWatchlistRemovePost.Movies = new List<ITraktSyncWatchlistPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncWatchlistRemovePost.Shows = new List<ITraktSyncWatchlistPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncWatchlistRemovePost.Seasons = new List<ITraktSyncWatchlistPostSeason>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncWatchlistRemovePost.Episodes = new List<ITraktSyncWatchlistPostEpisode>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            (syncWatchlistRemovePost.Movies as List<ITraktSyncWatchlistPostMovie>).Add(new TraktSyncWatchlistPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            (syncWatchlistRemovePost.Movies as List<ITraktSyncWatchlistPostMovie>).Clear();
            (syncWatchlistRemovePost.Shows as List<ITraktSyncWatchlistPostShow>).Add(new TraktSyncWatchlistPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            (syncWatchlistRemovePost.Shows as List<ITraktSyncWatchlistPostShow>).Clear();
            (syncWatchlistRemovePost.Seasons as List<ITraktSyncWatchlistPostSeason>).Add(new TraktSyncWatchlistPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            (syncWatchlistRemovePost.Seasons as List<ITraktSyncWatchlistPostSeason>).Clear();
            (syncWatchlistRemovePost.Episodes as List<ITraktSyncWatchlistPostEpisode>).Add(new TraktSyncWatchlistPostEpisode());
            act.Should().NotThrow();
        }
    }
}
