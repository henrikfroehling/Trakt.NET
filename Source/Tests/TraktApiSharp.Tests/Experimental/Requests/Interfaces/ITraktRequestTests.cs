namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ITraktRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestIsInterface()
        {
            typeof(ITraktRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestDerivesFromITraktHttpRequestInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHttpRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestDerivesFromITraktRequestAuthorizationInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktRequestAuthorization));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestDerivesFromITraktUriBuildableInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktUriBuildable));
        }
    }
}
