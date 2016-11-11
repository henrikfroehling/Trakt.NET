namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;

    [TestClass]
    public class TraktShowsPopularRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestIsNotAbstract()
        {
            typeof(TraktShowsPopularRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestIsSealed()
        {
            typeof(TraktShowsPopularRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestIsSubclassOfATraktShowsRequest()
        {
            typeof(TraktShowsPopularRequest).IsSubclassOf(typeof(ATraktShowsRequest<TraktShow>)).Should().BeTrue();
        }
    }
}
