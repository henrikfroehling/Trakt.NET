namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Seasons;

    [TestClass]
    public class TraktSeasonsAllRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestIsNotAbstract()
        {
            typeof(TraktSeasonsAllRequest).IsAbstract.Should().BeFalse();
        }
    }
}
