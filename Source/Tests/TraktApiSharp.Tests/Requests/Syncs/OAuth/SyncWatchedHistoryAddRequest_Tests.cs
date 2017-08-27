namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryAddRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryAddRequest_Is_Not_Abstract()
        {
            typeof(SyncWatchedHistoryAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncWatchedHistoryAddRequest_Is_Sealed()
        {
            typeof(SyncWatchedHistoryAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedHistoryAddRequest_Inherits_ASyncPostRequest_2()
        {
            typeof(SyncWatchedHistoryAddRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncHistoryPostResponse, TraktSyncHistoryPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedHistoryAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryAddRequest();
            request.UriTemplate.Should().Be("sync/history");
        }
    }
}
