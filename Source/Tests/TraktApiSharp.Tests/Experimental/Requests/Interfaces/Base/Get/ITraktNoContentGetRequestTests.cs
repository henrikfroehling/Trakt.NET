namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktNoContentGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentGetRequestIsInterface()
        {
            typeof(ITraktNoContentGetRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentGetRequestDerivesFromITraktNoContentRequestInterface()
        {
            typeof(ITraktNoContentGetRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentRequest));
        }
    }
}
