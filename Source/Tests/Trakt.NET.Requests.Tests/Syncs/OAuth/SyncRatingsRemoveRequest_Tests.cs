namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncRatingsRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncRatingsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRatingsRemoveRequest();
            request.UriTemplate.Should().Be("sync/ratings/remove");
        }
    }
}
