namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeason(episode, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeason(episodeIds, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_RatingsSeason_ArgumentExceptions()
        {
            RatingsSeason episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeason(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeason_RatingsSeasonIds_ArgumentExceptions()
        {
            RatingsSeasonIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeason(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(episode, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(episodeIds, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_RatingsSeasonRatedAt_ArgumentExceptions()
        {
            RatingsSeasonRatedAt episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonRatedAt_RatingsSeasonIdsRatedAt_ArgumentExceptions()
        {
            RatingsSeasonIdsRatedAt episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasonRatedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasons_RatingsSeason_ArgumentExceptions()
        {
            List<RatingsSeason> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasons(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasons_RatingsSeasonIds_ArgumentExceptions()
        {
            List<RatingsSeasonIds> episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasons(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonsRatedAt_RatingsSeasonRatedAt_ArgumentExceptions()
        {
            List<RatingsSeasonRatedAt> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasonsRatedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithSeasonsRatedAt_RatingsSeasonIdsRatedAt_ArgumentExceptions()
        {
            List<RatingsSeasonIdsRatedAt> episodesIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithSeasonsRatedAt(episodesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
