namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_SyncHistoryPostBuilder()
        {
            ITraktSyncHistoryPostBuilder syncHistoryPostBuilder = TraktPost.NewSyncHistoryPost();
            syncHistoryPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_Empty_Build()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost().Build();
            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
