namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class ATraktShowsMostPWCRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestIsAbstract()
        {
            typeof(ATraktShowsMostPWCRequest).IsAbstract.Should().BeTrue();
        }
    }
}
