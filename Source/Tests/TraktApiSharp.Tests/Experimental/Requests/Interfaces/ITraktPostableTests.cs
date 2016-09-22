namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Net.Http;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktPostableTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPostableIsInterface()
        {
            typeof(ITraktPostable<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPostableHasRequestBodyProperty()
        {
            var requestBodyPropertyInfo = typeof(ITraktPostable<int>).GetProperties()
                                                                     .Where(p => p.Name == "RequestBody")
                                                                     .FirstOrDefault();

            requestBodyPropertyInfo.CanRead.Should().BeTrue();
            requestBodyPropertyInfo.CanWrite.Should().BeTrue();
            requestBodyPropertyInfo.PropertyType.Should().Be(typeof(int));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPostableHasRequestBodyContentProperty()
        {
            var requestBodyContentPropertyInfo = typeof(ITraktPostable<>).GetProperties()
                                                                         .Where(p => p.Name == "RequestBodyContent")
                                                                         .FirstOrDefault();

            requestBodyContentPropertyInfo.CanRead.Should().BeTrue();
            requestBodyContentPropertyInfo.CanWrite.Should().BeFalse();
            requestBodyContentPropertyInfo.PropertyType.Should().Be(typeof(HttpContent));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPostableHasRequestBodyJsonProperty()
        {
            var requestBodyJsonPropertyInfo = typeof(ITraktPostable<>).GetProperties()
                                                                      .Where(p => p.Name == "RequestBodyJson")
                                                                      .FirstOrDefault();

            requestBodyJsonPropertyInfo.CanRead.Should().BeTrue();
            requestBodyJsonPropertyInfo.CanWrite.Should().BeFalse();
            requestBodyJsonPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
