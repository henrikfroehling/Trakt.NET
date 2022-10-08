namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithHistoryId_ITraktEpisode()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithHistoryId(100)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.HaveCount(1);

            ulong[] historyIds = syncHistoryRemovePost.HistoryIds.ToArray();
            historyIds[0].Should().Be(100);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithHistoryIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithHistoryIds(new List<ulong>
                {
                    100,
                    200,
                    300
                })
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.HaveCount(3);

            ulong[] historyIds = syncHistoryRemovePost.HistoryIds.ToArray();
            historyIds[0].Should().Be(100);
            historyIds[1].Should().Be(200);
            historyIds[2].Should().Be(300);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithHistoryIds_Params()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithHistoryIds(100, 200, 300)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.HaveCount(3);

            ulong[] historyIds = syncHistoryRemovePost.HistoryIds.ToArray();
            historyIds[0].Should().Be(100);
            historyIds[1].Should().Be(200);
            historyIds[2].Should().Be(300);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
        }
    }
}
