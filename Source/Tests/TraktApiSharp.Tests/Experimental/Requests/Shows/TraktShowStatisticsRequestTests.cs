namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowStatisticsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowStatisticsRequestIsNotAbstract()
        {
            typeof(TraktShowStatisticsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
