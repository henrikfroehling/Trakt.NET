namespace TraktApiSharp.Tests.Experimental.Requests.Shows.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;
    using TraktApiSharp.Objects.Get.Shows;

    [TestClass]
    public class TraktShowWatchedProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsNotAbstract()
        {
            typeof(TraktShowWatchedProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsSealed()
        {
            typeof(TraktShowWatchedProgressRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsSubclassOfATraktShowProgressRequest()
        {
            typeof(TraktShowWatchedProgressRequest).IsSubclassOf(typeof(ATraktShowProgressRequest<TraktShowWatchedProgress>)).Should().BeTrue();
        }
    }
}
