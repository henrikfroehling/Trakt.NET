namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Implementations;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncRatingsAddRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncRatingsAddRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncRatingsAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncRatingsAddRequest_Is_Sealed()
        {
            typeof(TraktSyncRatingsAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncRatingsAddRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncRatingsAddRequest).IsSubclassOf(typeof(ATraktSyncPostRequest<TraktSyncRatingsPostResponse, TraktSyncRatingsPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncRatingsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncRatingsAddRequest();
            request.UriTemplate.Should().Be("sync/ratings");
        }
    }
}
