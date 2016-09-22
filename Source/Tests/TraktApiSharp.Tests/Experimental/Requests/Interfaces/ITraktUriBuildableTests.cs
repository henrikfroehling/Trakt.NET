namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktUriBuildableTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableIsInterface()
        {
            typeof(ITraktUriBuildable).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasUriTemplateProperty()
        {
            var uriTemplatePropertyInfo = typeof(ITraktUriBuildable).GetProperties()
                                                                    .Where(p => p.Name == "UriTemplate")
                                                                    .FirstOrDefault();

            uriTemplatePropertyInfo.CanRead.Should().BeTrue();
            uriTemplatePropertyInfo.CanWrite.Should().BeFalse();
            uriTemplatePropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasUrlProperty()
        {
            var urlPropertyInfo = typeof(ITraktUriBuildable).GetProperties()
                                                            .Where(p => p.Name == "Url")
                                                            .FirstOrDefault();

            urlPropertyInfo.CanRead.Should().BeTrue();
            urlPropertyInfo.CanWrite.Should().BeFalse();
            urlPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasBuildUrlMethod()
        {
            var methodInfo = typeof(ITraktUriBuildable).GetMethods()
                                                       .Where(m => m.Name == "BuildUrl")
                                                       .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(string));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(ITraktUriBuildable).GetMethods()
                                                       .Where(m => m.Name == "GetUriPathParameters")
                                                       .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
