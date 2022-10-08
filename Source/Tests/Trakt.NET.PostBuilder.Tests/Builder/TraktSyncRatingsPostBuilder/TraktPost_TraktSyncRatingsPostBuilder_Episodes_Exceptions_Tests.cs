namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisode(episode, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisode(episodeIds, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_RatingsEpisode_ArgumentExceptions()
        {
            RatingsEpisode episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisode(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisode_RatingsEpisodeIds_ArgumentExceptions()
        {
            RatingsEpisodeIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisode(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(episode, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(episodeIds, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_RatingsEpisodeRatedAt_ArgumentExceptions()
        {
            RatingsEpisodeRatedAt episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodeRatedAt_RatingsEpisodeIdsRatedAt_ArgumentExceptions()
        {
            RatingsEpisodeIdsRatedAt episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodeRatedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodes_RatingsEpisode_ArgumentExceptions()
        {
            List<RatingsEpisode> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodes(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodes_RatingsEpisodeIds_ArgumentExceptions()
        {
            List<RatingsEpisodeIds> episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodes(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodesRatedAt_RatingsEpisodeRatedAt_ArgumentExceptions()
        {
            List<RatingsEpisodeRatedAt> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodesRatedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithEpisodesRatedAt_RatingsEpisodeIdsRatedAt_ArgumentExceptions()
        {
            List<RatingsEpisodeIdsRatedAt> episodesIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithEpisodesRatedAt(episodesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
