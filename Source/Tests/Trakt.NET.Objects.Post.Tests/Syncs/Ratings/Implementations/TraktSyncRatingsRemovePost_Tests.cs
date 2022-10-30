namespace TraktNet.Objects.Post.Tests.Syncs.Ratings.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("Objects.Post.Syncs.Ratings.Implementations")]
    public class TraktSyncRatingsRemovePost_Tests
    {
        [Fact]
        public void Test_TraktSyncRatingsRemovePost_Validate()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = new TraktSyncRatingsRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncRatingsRemovePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncRatingsRemovePost.Movies = new List<ITraktSyncRatingsPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncRatingsRemovePost.Shows = new List<ITraktSyncRatingsPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncRatingsRemovePost.Seasons = new List<ITraktSyncRatingsPostSeason>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncRatingsRemovePost.Episodes = new List<ITraktSyncRatingsPostEpisode>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            (syncRatingsRemovePost.Movies as List<ITraktSyncRatingsPostMovie>).Add(new TraktSyncRatingsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            (syncRatingsRemovePost.Movies as List<ITraktSyncRatingsPostMovie>).Clear();
            (syncRatingsRemovePost.Shows as List<ITraktSyncRatingsPostShow>).Add(new TraktSyncRatingsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            (syncRatingsRemovePost.Shows as List<ITraktSyncRatingsPostShow>).Clear();
            (syncRatingsRemovePost.Seasons as List<ITraktSyncRatingsPostSeason>).Add(new TraktSyncRatingsPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            (syncRatingsRemovePost.Seasons as List<ITraktSyncRatingsPostSeason>).Clear();
            (syncRatingsRemovePost.Episodes as List<ITraktSyncRatingsPostEpisode>).Add(new TraktSyncRatingsPostEpisode());
            act.Should().NotThrow();
        }
    }
}
