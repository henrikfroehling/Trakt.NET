namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ITraktHasIdTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasIdIsInterface()
        {
            typeof(ITraktHasId).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasIdDerivesFromITraktObjectRequestInterface()
        {
            typeof(ITraktHasId).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasIdHasIdProperty()
        {
            var idPropertyInfo = typeof(ITraktHasId).GetProperties()
                                                    .Where(p => p.Name == "Id")
                                                    .FirstOrDefault();

            idPropertyInfo.CanRead.Should().BeTrue();
            idPropertyInfo.CanWrite.Should().BeTrue();
            idPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasIdHasRequestIdProperty()
        {
            var requestIdPropertyInfo = typeof(ITraktHasId).GetProperties()
                                                           .Where(p => p.Name == "RequestId")
                                                           .FirstOrDefault();

            requestIdPropertyInfo.CanRead.Should().BeTrue();
            requestIdPropertyInfo.CanWrite.Should().BeTrue();
            requestIdPropertyInfo.PropertyType.Should().Be(typeof(TraktRequestId));
        }
    }
}
