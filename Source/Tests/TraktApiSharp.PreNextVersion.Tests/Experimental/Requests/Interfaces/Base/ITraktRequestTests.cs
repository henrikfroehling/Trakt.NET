namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
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
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHasRequestAuthorization));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestDerivesFromITraktUriBuildableInterface()
        {
            typeof(ITraktRequest).GetInterfaces().Should().Contain(typeof(ITraktHasUri));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestHasClientProperty()
        {
            var clientPropertyInfo = typeof(ITraktRequest).GetProperties()
                                                          .Where(p => p.Name == "Client")
                                                          .FirstOrDefault();

            clientPropertyInfo.CanRead.Should().BeTrue();
            clientPropertyInfo.CanWrite.Should().BeFalse();
            clientPropertyInfo.PropertyType.Should().Be(typeof(TraktClient));
        }
    }
}
