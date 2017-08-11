namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncCollectionAddRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncCollectionAddRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncCollectionAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncCollectionAddRequest_Is_Sealed()
        {
            typeof(TraktSyncCollectionAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionAddRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncCollectionAddRequest).IsSubclassOf(typeof(ATraktSyncPostRequest<ITraktSyncCollectionPostResponse, TraktSyncCollectionPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionAddRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncCollectionAddRequest();
            request.UriTemplate.Should().Be("sync/collection");
        }
    }
}
