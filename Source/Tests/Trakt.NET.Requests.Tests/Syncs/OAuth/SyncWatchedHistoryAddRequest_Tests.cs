namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryAddRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryAddRequest();
            request.UriTemplate.Should().Be("sync/history");
        }
    }
}
