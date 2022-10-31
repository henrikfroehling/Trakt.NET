namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisode_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisode(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisode_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisode(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(episode, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(episodeIds, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_WatchedEpisode_ArgumentExceptions()
        {
            WatchedEpisode episode = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_WatchedEpisodeIds_ArgumentExceptions()
        {
            WatchedEpisodeIds episodeIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodes_ITraktEpisode_ArgumentExceptions()
        {
            List<ITraktEpisode> episodes = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodes(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodes_ITraktEpisodeIds_ArgumentExceptions()
        {
            List<ITraktEpisodeIds> episodeIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodes(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodesWatchedAt_WatchedEpisode_ArgumentExceptions()
        {
            List<WatchedEpisode> episodes = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodesWatchedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodesWatchedAt_WatchedEpisodeIds_ArgumentExceptions()
        {
            List<WatchedEpisodeIds> episodesIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithEpisodesWatchedAt(episodesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
