namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests;

    [TestClass]
    public class ITraktObjectRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktObjectRequestIsInterface()
        {
            typeof(ITraktObjectRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktObjectRequestHasRequestObjectTypeProperty()
        {
            var requestObjectTypePropertyInfo = typeof(ITraktObjectRequest).GetProperties()
                                                                           .Where(p => p.Name == "RequestObjectType")
                                                                           .FirstOrDefault();

            requestObjectTypePropertyInfo.CanRead.Should().BeTrue();
            requestObjectTypePropertyInfo.CanWrite.Should().BeFalse();
            requestObjectTypePropertyInfo.PropertyType.Should().Be(typeof(TraktRequestObjectType));
        }
    }
}
