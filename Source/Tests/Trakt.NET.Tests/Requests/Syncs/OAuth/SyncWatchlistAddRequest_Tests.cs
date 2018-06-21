namespace TraktNet.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchlistAddRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistAddRequest();
            request.UriTemplate.Should().Be("sync/watchlist");
        }
    }
}
