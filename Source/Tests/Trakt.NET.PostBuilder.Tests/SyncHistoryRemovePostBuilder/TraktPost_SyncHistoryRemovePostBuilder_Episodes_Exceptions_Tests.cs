namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithEpisode_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithEpisode(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithEpisode_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithEpisode(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithEpisodes_ITraktEpisode_ArgumentExceptions()
        {
            List<ITraktEpisode> episodes = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithEpisodes(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithEpisodes_ITraktEpisodeIds_ArgumentExceptions()
        {
            List<ITraktEpisodeIds> episodeIds = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithEpisodes(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
