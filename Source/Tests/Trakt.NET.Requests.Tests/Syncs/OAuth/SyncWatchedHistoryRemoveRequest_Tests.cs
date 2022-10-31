namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncWatchedHistoryRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedHistoryRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedHistoryRemoveRequest();
            request.UriTemplate.Should().Be("sync/history/remove");
        }
    }
}
