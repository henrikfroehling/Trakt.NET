namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisode_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithEpisode(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisode_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithEpisode(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisodes_ITraktEpisode_ArgumentExceptions()
        {
            List<ITraktEpisode> episodes = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithEpisodes(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithEpisodes_ITraktEpisodeIds_ArgumentExceptions()
        {
            List<ITraktEpisodeIds> episodeIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithEpisodes(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
