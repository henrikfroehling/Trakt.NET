namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryRemoveRequest_Is_Not_Abstract()
        {
            typeof(SyncWatchedHistoryRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncWatchedHistoryRemoveRequest_Is_Sealed()
        {
            typeof(SyncWatchedHistoryRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedHistoryRemoveRequest_Inherits_ASyncPostRequest_2()
        {
            typeof(SyncWatchedHistoryRemoveRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedHistoryRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryRemoveRequest();
            request.UriTemplate.Should().Be("sync/history/remove");
        }
    }
}
