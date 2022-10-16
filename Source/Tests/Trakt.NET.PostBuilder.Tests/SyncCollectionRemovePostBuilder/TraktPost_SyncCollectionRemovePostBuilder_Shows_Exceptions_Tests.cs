namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
