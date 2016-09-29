namespace TraktApiSharp.Tests.Experimental.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Checkins.OAuth;

    [TestClass]
    public class TraktCheckinsDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinsDeleteRequestIsNotAbstract()
        {
            typeof(TraktCheckinsDeleteRequest).IsAbstract.Should().BeFalse();
        }
    }
}
