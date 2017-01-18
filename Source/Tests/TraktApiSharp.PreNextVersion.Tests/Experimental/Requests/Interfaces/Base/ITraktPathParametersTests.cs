namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ITraktPathParametersTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPathParametersIsInterface()
        {
            typeof(ITraktPathParameters).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPathParametersHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(ITraktPathParameters).GetMethods()
                                                         .Where(m => m.Name == "GetUriPathParameters")
                                                         .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
