namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
