namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Delete;

    [TestClass]
    public class ITraktNoContentDeleteByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentDeleteByIdRequestIsInterface()
        {
            typeof(ITraktNoContentDeleteByIdRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentDeleteByIdRequestDerivesFromITraktNoContentDeleteRequestInterface()
        {
            typeof(ITraktNoContentDeleteByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentDeleteRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentDeleteByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktNoContentDeleteByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
