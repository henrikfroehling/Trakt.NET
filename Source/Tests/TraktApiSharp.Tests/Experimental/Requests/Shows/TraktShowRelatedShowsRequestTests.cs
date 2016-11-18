namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowRelatedShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestIsNotAbstract()
        {
            typeof(TraktShowRelatedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestIsSealed()
        {
            typeof(TraktShowRelatedShowsRequest).IsSealed.Should().BeTrue();
        }
    }
}
