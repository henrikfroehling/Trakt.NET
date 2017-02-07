namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncRatingsRemoveRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncRatingsRemoveRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncRatingsRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncRatingsRemoveRequest_Is_Sealed()
        {
            typeof(TraktSyncRatingsRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncRatingsRemoveRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncRatingsRemoveRequest).IsSubclassOf(typeof(ATraktSyncPostRequest<TraktSyncRatingsRemovePostResponse, TraktSyncRatingsPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncRatingsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncRatingsRemoveRequest();
            request.UriTemplate.Should().Be("sync/ratings/remove");
        }
    }
}
