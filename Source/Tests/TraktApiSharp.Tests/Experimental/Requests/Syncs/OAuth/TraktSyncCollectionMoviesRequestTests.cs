namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Collection;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncCollectionMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionMoviesRequestIsNotAbstract()
        {
            typeof(TraktSyncCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionMoviesRequestIsSealed()
        {
            typeof(TraktSyncCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionMoviesRequestIsSubclassOfATraktSyncListRequest()
        {
            typeof(TraktSyncCollectionMoviesRequest).IsSubclassOf(typeof(ATraktSyncListRequest<TraktCollectionMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionMoviesRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncCollectionMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }
    }
}
