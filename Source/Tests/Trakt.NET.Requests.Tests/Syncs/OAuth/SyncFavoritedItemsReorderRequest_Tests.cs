namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]

    public class SyncFavoritedItemsReorderRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritedItemsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncFavoritedItemsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncFavoritedItemsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritedItemsReorderRequest();
            request.UriTemplate.Should().Be("sync/favorites/reorder");
        }
    }
}
