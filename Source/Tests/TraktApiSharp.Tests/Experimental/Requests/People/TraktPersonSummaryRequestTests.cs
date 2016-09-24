namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;

    [TestClass]
    public class TraktPersonSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestTraktPersonSummaryRequestIsNotAbstract()
        {
            typeof(TraktPersonSummaryRequest).IsAbstract.Should().BeFalse();
        }
    }
}
