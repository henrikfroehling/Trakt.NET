namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncHistoryRemoveRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_SyncHistoryRemovePostBuilder()
        {
            ITraktSyncHistoryRemovePostBuilder syncCollectionPostBuilder = TraktPost.NewSyncHistoryRemovePost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_Empty_Build()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost().Build();
            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Shows.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.Episodes.Should().NotBeNull().And.BeEmpty();
            syncHistoryRemovePost.HistoryIds.Should().NotBeNull().And.BeEmpty();
        }
    }
}
