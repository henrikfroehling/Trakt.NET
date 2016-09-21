namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktRequestTests
    {
        [TestMethod]
        public void TestITraktRequestIsInterface()
        {
            typeof(ITraktRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod]
        public void TestITraktRequestImplementsITraktHttpRequestInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHttpRequest));
        }

        [TestMethod]
        public void TestITraktRequestImplementsITraktRequestAuthorizationInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktRequestAuthorization));
        }
    }
}
