namespace TraktNet.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
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
