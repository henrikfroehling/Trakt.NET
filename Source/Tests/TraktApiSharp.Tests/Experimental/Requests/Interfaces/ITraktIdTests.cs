namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktIdTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdIsInterface()
        {
            typeof(ITraktId).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdHasIdProperty()
        {
            var idPropertyInfo = typeof(ITraktId).GetProperties()
                                                 .Where(p => p.Name == "Id")
                                                 .FirstOrDefault();

            idPropertyInfo.CanRead.Should().BeTrue();
            idPropertyInfo.CanWrite.Should().BeTrue();
            idPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdHasGetIdPathParametersMethod()
        {
            var methodInfo = typeof(ITraktId).GetMethods()
                                             .Where(m => m.Name == "GetIdPathParameters")
                                             .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdHasValidateIdMethod()
        {
            var methodInfo = typeof(ITraktId).GetMethods()
                                             .Where(m => m.Name == "ValidateId")
                                             .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(void));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
