namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;

    [TestClass]
    public class TraktSyncCollectionRemoveRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionRemoveRequestIsNotAbstract()
        {
            typeof(TraktSyncCollectionRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionRemoveRequestIsSealed()
        {
            typeof(TraktSyncCollectionRemoveRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionRemoveRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        {
            typeof(TraktSyncCollectionRemoveRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncCollectionRemovePostResponse, TraktSyncCollectionPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionRemoveRequestHasValidUriTemplate()
        {
            var request = new TraktSyncCollectionRemoveRequest(null);
            request.UriTemplate.Should().Be("sync/collection/remove");
        }
    }
}
