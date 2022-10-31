namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(show, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(showIds, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_RatingsShow_ArgumentExceptions()
        {
            RatingsShow show = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShow_RatingsShowIds_ArgumentExceptions()
        {
            RatingsShowIds showIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(show, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(showIds, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_RatingsShowRatedAt_ArgumentExceptions()
        {
            RatingsShowRatedAt show = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowRatedAt_RatingsShowIdsRatedAt_ArgumentExceptions()
        {
            RatingsShowIdsRatedAt showIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowRatedAt(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows_RatingsShow_ArgumentExceptions()
        {
            List<RatingsShow> shows = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShows_RatingsShowIds_ArgumentExceptions()
        {
            List<RatingsShowIds> showIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsRatedAt_RatingsShowRatedAt_ArgumentExceptions()
        {
            List<RatingsShowRatedAt> shows = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowsRatedAt(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsRatedAt_RatingsShowIdsRatedAt_ArgumentExceptions()
        {
            List<RatingsShowIdsRatedAt> showsIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithShowsRatedAt(showsIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
