namespace TraktApiSharp.Tests.Experimental.Requests.Shows.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;
    using TraktApiSharp.Objects.Get.Shows;

    [TestClass]
    public class TraktShowCollectionProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestIsNotAbstract()
        {
            typeof(TraktShowCollectionProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestIsSealed()
        {
            typeof(TraktShowCollectionProgressRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowCollectionProgressRequestIsSubclassOfATraktShowProgressRequest()
        {
            typeof(TraktShowCollectionProgressRequest).IsSubclassOf(typeof(ATraktShowProgressRequest<TraktShowCollectionProgress>)).Should().BeTrue();
        }
    }
}
