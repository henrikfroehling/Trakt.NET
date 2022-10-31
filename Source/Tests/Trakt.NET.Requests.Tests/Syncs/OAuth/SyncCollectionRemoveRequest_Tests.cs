namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncCollectionRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionRemoveRequest();
            request.UriTemplate.Should().Be("sync/collection/remove");
        }
    }
}
