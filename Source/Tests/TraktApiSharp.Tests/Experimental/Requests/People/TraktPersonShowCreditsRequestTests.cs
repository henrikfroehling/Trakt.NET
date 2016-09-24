namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;

    [TestClass]
    public class TraktPersonShowCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Show")]
        public void TestTraktPersonShowCreditsRequestIsNotAbstract()
        {
            typeof(TraktPersonShowCreditsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
