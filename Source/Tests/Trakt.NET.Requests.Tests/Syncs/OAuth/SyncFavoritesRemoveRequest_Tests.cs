namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncFavoritesRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritesRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritesRemoveRequest();
            request.UriTemplate.Should().Be("sync/favorites/remove");
        }
    }
}
