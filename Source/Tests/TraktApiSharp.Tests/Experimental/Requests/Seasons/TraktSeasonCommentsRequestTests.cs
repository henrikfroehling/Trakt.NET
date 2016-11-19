namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Seasons;

    [TestClass]
    public class TraktSeasonCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonCommentsRequestIsNotAbstract()
        {
            typeof(TraktSeasonCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonCommentsRequestIsSealed()
        {
            typeof(TraktSeasonCommentsRequest).IsSealed.Should().BeTrue();
        }
    }
}
