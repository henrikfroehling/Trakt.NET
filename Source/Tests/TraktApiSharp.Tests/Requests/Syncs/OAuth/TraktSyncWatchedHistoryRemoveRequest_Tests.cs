namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses.Implementations;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchedHistoryRemoveRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchedHistoryRemoveRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchedHistoryRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRemoveRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchedHistoryRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRemoveRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncWatchedHistoryRemoveRequest).IsSubclassOf(typeof(ATraktSyncPostRequest<TraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchedHistoryRemoveRequest();
            request.UriTemplate.Should().Be("sync/history/remove");
        }
    }
}
