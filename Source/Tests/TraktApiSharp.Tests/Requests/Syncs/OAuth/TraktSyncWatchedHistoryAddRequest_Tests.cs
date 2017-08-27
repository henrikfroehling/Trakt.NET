namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchedHistoryAddRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchedHistoryAddRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchedHistoryAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryAddRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchedHistoryAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryAddRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncWatchedHistoryAddRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncHistoryPostResponse, TraktSyncHistoryPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedHistoryAddRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchedHistoryAddRequest();
            request.UriTemplate.Should().Be("sync/history");
        }
    }
}
