namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncCollectionRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionRemoveRequest_Is_Not_Abstract()
        {
            typeof(SyncCollectionRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncCollectionRemoveRequest_Is_Sealed()
        {
            typeof(SyncCollectionRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionRemoveRequest_Inherits_ASyncPostRequest_2()
        {
            typeof(SyncCollectionRemoveRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncCollectionRemovePostResponse, TraktSyncCollectionPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionRemoveRequest();
            request.UriTemplate.Should().Be("sync/collection/remove");
        }
    }
}
