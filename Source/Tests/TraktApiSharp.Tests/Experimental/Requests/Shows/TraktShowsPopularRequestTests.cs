namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

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
    }
}
