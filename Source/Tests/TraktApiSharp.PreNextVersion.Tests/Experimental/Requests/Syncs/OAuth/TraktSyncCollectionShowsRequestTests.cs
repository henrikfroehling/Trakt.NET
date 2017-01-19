namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Collection;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncCollectionShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionShowsRequestIsNotAbstract()
        {
            typeof(TraktSyncCollectionShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionShowsRequestIsSealed()
        {
            typeof(TraktSyncCollectionShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionShowsRequestIsSubclassOfATraktSyncListGetRequest()
        {
            typeof(TraktSyncCollectionShowsRequest).IsSubclassOf(typeof(ATraktSyncListGetRequest<TraktCollectionShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionShowsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSyncCollectionShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionShowsRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncCollectionShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncCollectionShowsRequestHasValidUriTemplate()
        {
            var request = new TraktSyncCollectionShowsRequest(null);
            request.UriTemplate.Should().Be("sync/collection/shows{?extended}");
        }
    }
}
