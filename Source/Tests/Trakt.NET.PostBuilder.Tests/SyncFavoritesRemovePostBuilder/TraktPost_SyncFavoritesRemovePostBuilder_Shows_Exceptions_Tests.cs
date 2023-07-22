namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncFavoritesRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
