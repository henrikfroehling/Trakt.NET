namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;

    [TestClass]
    public class TraktSyncCollectionAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionAddRequestIsNotAbstract()
        {
            typeof(TraktSyncCollectionAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionAddRequestIsSealed()
        {
            typeof(TraktSyncCollectionAddRequest).IsSealed.Should().BeTrue();
        }

        //[TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        //public void TestTraktSyncCollectionAddRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        //{
        //    typeof(TraktSyncCollectionAddRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncCollectionPostResponse, TraktSyncCollectionPost>)).Should().BeTrue();
        //}

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionAddRequestHasValidUriTemplate()
        {
            var request = new TraktSyncCollectionAddRequest(null);
            request.UriTemplate.Should().Be("sync/collection");
        }
    }
}
