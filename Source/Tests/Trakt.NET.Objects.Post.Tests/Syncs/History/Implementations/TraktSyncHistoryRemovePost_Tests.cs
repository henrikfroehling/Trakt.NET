﻿namespace TraktNet.Objects.Post.Tests.Syncs.History.Implementations
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

            // movies = null, shows = null, episodes = null, history ids = null
            Action act = () => syncHistoryRemovePost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, episodes = null, history ids = null
            syncHistoryRemovePost.Movies = new List<ITraktSyncHistoryPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = null, history ids = null
            syncHistoryRemovePost.Shows = new List<ITraktSyncHistoryPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = empty, history ids = null
            syncHistoryRemovePost.Episodes = new List<ITraktSyncHistoryPostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, episodes = empty, history ids = empty
            syncHistoryRemovePost.HistoryIds = new List<ulong>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, episodes = empty, history ids = empty
            (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryPostMovie>).Add(new TraktSyncHistoryPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, episodes = empty, history ids = empty
            (syncHistoryRemovePost.Movies as List<ITraktSyncHistoryPostMovie>).Clear();
            (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Add(new TraktSyncHistoryPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, episodes with at least one item, history ids = empty
            (syncHistoryRemovePost.Shows as List<ITraktSyncHistoryPostShow>).Clear();
            (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryPostEpisode>).Add(new TraktSyncHistoryPostEpisode());
            act.Should().NotThrow();

            // movies = empty, shows = empty, episodes = empty, history ids with at least one item
            (syncHistoryRemovePost.Episodes as List<ITraktSyncHistoryPostEpisode>).Clear();
            (syncHistoryRemovePost.HistoryIds as List<ulong>).Add(10);
            act.Should().NotThrow();
        }
    }
}