namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(episode, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(episodeIds, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_RatingsShow_ArgumentExceptions()
        {
            RatingsShow episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_RatingsShowIds_ArgumentExceptions()
        {
            RatingsShowIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_ITraktShow_ArgumentExceptions()
        {
            ITraktShow episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(episode, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(episodeIds, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_RatingsShowRatedAt_ArgumentExceptions()
        {
            RatingsShowRatedAt episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_RatingsShowIdsRatedAt_ArgumentExceptions()
        {
            RatingsShowIdsRatedAt episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows_RatingsShow_ArgumentExceptions()
        {
            List<RatingsShow> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShows(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows_RatingsShowIds_ArgumentExceptions()
        {
            List<RatingsShowIds> episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShows(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsRatedAt_RatingsShowRatedAt_ArgumentExceptions()
        {
            List<RatingsShowRatedAt> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowsRatedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsRatedAt_RatingsShowIdsRatedAt_ArgumentExceptions()
        {
            List<RatingsShowIdsRatedAt> episodesIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowsRatedAt(episodesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
