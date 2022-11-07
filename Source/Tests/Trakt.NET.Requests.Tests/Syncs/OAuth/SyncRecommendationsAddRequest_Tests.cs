namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncRecommendationsAddRequest_Tests
    {
        [Fact]
        public void Test_SyncRecommendationsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRecommendationsAddRequest();
            request.UriTemplate.Should().Be("sync/recommendations");
        }
    }
}
