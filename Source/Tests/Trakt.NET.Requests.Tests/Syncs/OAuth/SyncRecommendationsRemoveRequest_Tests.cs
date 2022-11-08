namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncRecommendationsRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncRecommendationsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRecommendationsRemoveRequest();
            request.UriTemplate.Should().Be("sync/recommendations/remove");
        }
    }
}
