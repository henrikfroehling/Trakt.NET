namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;

    [TestClass]
    public class TraktSyncRatingsAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsAddRequestIsNotAbstract()
        {
            typeof(TraktSyncRatingsAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsAddRequestIsSealed()
        {
            typeof(TraktSyncRatingsAddRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsAddRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        {
            typeof(TraktSyncRatingsAddRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncRatingsPostResponse, TraktSyncRatingsPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsAddRequestHasValidUriTemplate()
        {
            var request = new TraktSyncRatingsAddRequest(null);
            request.UriTemplate.Should().Be("sync/ratings");
        }
    }
}
