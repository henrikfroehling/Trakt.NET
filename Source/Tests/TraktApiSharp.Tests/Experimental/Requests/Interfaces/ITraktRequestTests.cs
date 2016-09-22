namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestIsInterface()
        {
            typeof(ITraktRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestImplementsITraktHttpRequestInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHttpRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestImplementsITraktRequestAuthorizationInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktRequestAuthorization));
        }
    }
}
