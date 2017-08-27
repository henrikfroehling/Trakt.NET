namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncCollectionAddRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionAddRequest_Is_Not_Abstract()
        {
            typeof(SyncCollectionAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncCollectionAddRequest_Is_Sealed()
        {
            typeof(SyncCollectionAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionAddRequest_Inherits_ASyncPostRequest_2()
        {
            typeof(SyncCollectionAddRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncCollectionPostResponse, TraktSyncCollectionPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionAddRequest();
            request.UriTemplate.Should().Be("sync/collection");
        }
    }
}
