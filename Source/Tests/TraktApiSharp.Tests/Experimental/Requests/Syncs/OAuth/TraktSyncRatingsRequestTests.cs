namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Ratings;

    [TestClass]
    public class TraktSyncRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestIsNotAbstract()
        {
            typeof(TraktSyncRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestIsSealed()
        {
            typeof(TraktSyncRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestIsSubclassOfATraktSyncListRequest()
        {
            typeof(TraktSyncRatingsRequest).IsSubclassOf(typeof(ATraktSyncListRequest<TraktRatingsItem>)).Should().BeTrue();
        }
    }
}
