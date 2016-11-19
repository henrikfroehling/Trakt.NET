namespace TraktApiSharp.Tests.Experimental.Requests.Shows.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;

    [TestClass]
    public class TraktShowWatchedProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestTraktShowWatchedProgressRequestIsNotAbstract()
        {
            typeof(TraktShowWatchedProgressRequest).IsAbstract.Should().BeFalse();
        }
    }
}
