namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncFavoritesAddRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritesAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritesAddRequest();
            request.UriTemplate.Should().Be("sync/favorites");
        }
    }
}
