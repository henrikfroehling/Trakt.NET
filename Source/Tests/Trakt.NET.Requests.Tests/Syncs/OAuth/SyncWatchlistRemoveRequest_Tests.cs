namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchlistRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistRemoveRequest();
            request.UriTemplate.Should().Be("sync/watchlist/remove");
        }
    }
}
