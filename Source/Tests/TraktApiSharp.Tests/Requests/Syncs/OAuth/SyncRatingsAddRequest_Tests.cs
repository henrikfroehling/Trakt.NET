namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncRatingsAddRequest_Tests
    {
        [Fact]
        public void Test_SyncRatingsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRatingsAddRequest();
            request.UriTemplate.Should().Be("sync/ratings");
        }
    }
}
