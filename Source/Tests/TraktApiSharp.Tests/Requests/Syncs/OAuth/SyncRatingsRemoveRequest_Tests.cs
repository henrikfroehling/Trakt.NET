namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncRatingsRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncRatingsRemoveRequest_Is_Not_Abstract()
        {
            typeof(SyncRatingsRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncRatingsRemoveRequest_Is_Sealed()
        {
            typeof(SyncRatingsRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncRatingsRemoveRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(SyncRatingsRemoveRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncRatingsRemovePostResponse, TraktSyncRatingsPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncRatingsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRatingsRemoveRequest();
            request.UriTemplate.Should().Be("sync/ratings/remove");
        }
    }
}
