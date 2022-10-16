namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithSeason(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithSeason(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeasons_ITraktSeason_ArgumentExceptions()
        {
            List<ITraktSeason> seasons = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithSeasons(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeasons_ITraktSeasonIds_ArgumentExceptions()
        {
            List<ITraktSeasonIds> seasonIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithSeasons(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
