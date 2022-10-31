namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]

    public class SyncRecommendedItemsReorderRequest_Tests
    {
        [Fact]
        public void Test_SyncRecommendedItemsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncRecommendedItemsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncRecommendedItemsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRecommendedItemsReorderRequest();
            request.UriTemplate.Should().Be("sync/recommendations/reorder");
        }
    }
}
