namespace TraktNet.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncCollectionAddRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionAddRequest();
            request.UriTemplate.Should().Be("sync/collection");
        }
    }
}
