namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ITraktUriBuildableTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableIsInterface()
        {
            typeof(ITraktHasUri).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableDerivesFromITraktPathParametersInterface()
        {
            typeof(ITraktHasUri).GetInterfaces().Should().Contain(typeof(ITraktHasUriPathParameters));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasUriTemplateProperty()
        {
            var uriTemplatePropertyInfo = typeof(ITraktHasUri).GetProperties()
                                                                    .Where(p => p.Name == "UriTemplate")
                                                                    .FirstOrDefault();

            uriTemplatePropertyInfo.CanRead.Should().BeTrue();
            uriTemplatePropertyInfo.CanWrite.Should().BeFalse();
            uriTemplatePropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasUrlProperty()
        {
            var urlPropertyInfo = typeof(ITraktHasUri).GetProperties()
                                                            .Where(p => p.Name == "Url")
                                                            .FirstOrDefault();

            urlPropertyInfo.CanRead.Should().BeTrue();
            urlPropertyInfo.CanWrite.Should().BeFalse();
            urlPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktUriBuildableHasBuildUrlMethod()
        {
            var methodInfo = typeof(ITraktHasUri).GetMethods()
                                                       .Where(m => m.Name == "BuildUrl")
                                                       .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(string));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
