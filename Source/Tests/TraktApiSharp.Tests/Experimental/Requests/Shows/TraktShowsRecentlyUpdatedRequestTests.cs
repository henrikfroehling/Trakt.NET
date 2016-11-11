namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowsRecentlyUpdatedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsRecentlyUpdatedRequestIsNotAbstract()
        {
            typeof(TraktShowsRecentlyUpdatedRequest).IsAbstract.Should().BeFalse();
        }
    }
}
