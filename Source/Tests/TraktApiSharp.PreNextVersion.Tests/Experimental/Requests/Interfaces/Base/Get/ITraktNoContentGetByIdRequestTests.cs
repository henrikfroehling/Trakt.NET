namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktNoContentGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentGetByIdRequestIsInterface()
        {
            typeof(ITraktNoContentGetByIdRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentGetByIdRequestDerivesFromITraktNoContentGetRequestInterface()
        {
            typeof(ITraktNoContentGetByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentGetRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentGetByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktNoContentGetByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
