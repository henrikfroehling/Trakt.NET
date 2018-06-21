namespace TraktNet.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
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
