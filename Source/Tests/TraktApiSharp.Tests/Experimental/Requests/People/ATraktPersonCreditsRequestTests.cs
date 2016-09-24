namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;

    [TestClass]
    public class ATraktPersonCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestATraktPersonCreditsRequestIsAbstract()
        {
            typeof(ATraktPersonCreditsRequest).IsAbstract.Should().BeTrue();
        }
    }
}
