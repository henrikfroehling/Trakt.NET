namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Watched;

    [TestClass]
    public class TraktSyncWatchedMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedMoviesRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedMoviesRequestIsSealed()
        {
            typeof(TraktSyncWatchedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedMoviesRequestIsSubclassOfATraktSyncListRequest()
        {
            typeof(TraktSyncWatchedMoviesRequest).IsSubclassOf(typeof(ATraktSyncListRequest<TraktWatchedMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedMoviesRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSyncWatchedMoviesRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
