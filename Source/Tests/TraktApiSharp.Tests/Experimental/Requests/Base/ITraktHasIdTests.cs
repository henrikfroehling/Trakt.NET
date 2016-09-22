namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Base;

    [TestClass]
    public class ITraktHasIdTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasIdIsInterface()
        {
            typeof(ITraktHasId).IsInterface.Should().BeTrue();
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
