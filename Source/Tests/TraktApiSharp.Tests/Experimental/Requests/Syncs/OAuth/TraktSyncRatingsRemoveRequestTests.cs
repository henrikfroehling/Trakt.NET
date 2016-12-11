namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;

    [TestClass]
    public class TraktSyncRatingsRemoveRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRemoveRequestIsNotAbstract()
        {
            typeof(TraktSyncRatingsRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRemoveRequestIsSealed()
        {
            typeof(TraktSyncRatingsRemoveRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRemoveRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        {
            typeof(TraktSyncRatingsRemoveRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncRatingsRemovePostResponse, TraktSyncRatingsPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRemoveRequestHasValidUriTemplate()
        {
            var request = new TraktSyncRatingsRemoveRequest(null);
            request.UriTemplate.Should().Be("sync/ratings/remove");
        }
    }
}
