namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Net.Http;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktHttpRequestTests
    {
        [TestMethod]
        public void TestITraktHttpRequestIsInterface()
        {
            typeof(ITraktHttpRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod]
        public void TestITraktHttpRequestHasMethodProperty()
        {
            var methodPropertyInfo = typeof(ITraktHttpRequest).GetProperties()
                                                              .Where(p => p.Name == "Method")
                                                              .FirstOrDefault();

            methodPropertyInfo.CanRead.Should().BeTrue();
            methodPropertyInfo.CanWrite.Should().BeFalse();
            methodPropertyInfo.PropertyType.Should().Be(typeof(HttpMethod));
        }
    }
}
