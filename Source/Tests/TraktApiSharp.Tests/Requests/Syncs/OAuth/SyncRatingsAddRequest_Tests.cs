namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncRatingsAddRequest_Tests
    {
        [Fact]
        public void Test_SyncRatingsAddRequest_Is_Not_Abstract()
        {
            typeof(SyncRatingsAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncRatingsAddRequest_Is_Sealed()
        {
            typeof(SyncRatingsAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncRatingsAddRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(SyncRatingsAddRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncRatingsPostResponse, TraktSyncRatingsPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncRatingsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncRatingsAddRequest();
            request.UriTemplate.Should().Be("sync/ratings");
        }
    }
}
