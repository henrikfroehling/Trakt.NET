namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncCollectionRemoveRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncCollectionRemoveRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncCollectionRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncCollectionRemoveRequest_Is_Sealed()
        {
            typeof(TraktSyncCollectionRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionRemoveRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncCollectionRemoveRequest).IsSubclassOf(typeof(ATraktSyncPostRequest<TraktSyncCollectionRemovePostResponse, TraktSyncCollectionPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncCollectionRemoveRequest();
            request.UriTemplate.Should().Be("sync/collection/remove");
        }
    }
}
