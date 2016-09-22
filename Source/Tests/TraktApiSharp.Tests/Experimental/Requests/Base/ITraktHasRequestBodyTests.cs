namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Base;

    [TestClass]
    public class ITraktHasRequestBodyTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasRequestBodyIsInterface()
        {
            typeof(ITraktHasRequestBody<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasRequestBodyHasRequestBodyContentProperty()
        {
            var requestBodyContentPropertyInfo = typeof(ITraktHasRequestBody<int>).GetProperties()
                                                                                  .Where(p => p.Name == "RequestBodyContent")
                                                                                  .FirstOrDefault();

            requestBodyContentPropertyInfo.CanRead.Should().BeTrue();
            requestBodyContentPropertyInfo.CanWrite.Should().BeTrue();
            requestBodyContentPropertyInfo.PropertyType.Should().Be(typeof(int));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktHasRequestBodyHasRequestBodyProperty()
        {
            var requestBodyPropertyInfo = typeof(ITraktHasRequestBody<int>).GetProperties()
                                                                           .Where(p => p.Name == "RequestBody")
                                                                           .FirstOrDefault();

            requestBodyPropertyInfo.CanRead.Should().BeTrue();
            requestBodyPropertyInfo.CanWrite.Should().BeTrue();
            requestBodyPropertyInfo.PropertyType.Should().Be(typeof(TraktRequestBody<int>));
        }
    }
}
