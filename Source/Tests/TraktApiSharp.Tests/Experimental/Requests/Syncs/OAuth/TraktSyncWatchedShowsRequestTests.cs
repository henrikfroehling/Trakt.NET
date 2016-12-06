namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Watched;

    [TestClass]
    public class TraktSyncWatchedShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestIsSealed()
        {
            typeof(TraktSyncWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestIsSubclassOfATraktSyncListRequest()
        {
            typeof(TraktSyncWatchedShowsRequest).IsSubclassOf(typeof(ATraktSyncListRequest<TraktWatchedShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSyncWatchedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
