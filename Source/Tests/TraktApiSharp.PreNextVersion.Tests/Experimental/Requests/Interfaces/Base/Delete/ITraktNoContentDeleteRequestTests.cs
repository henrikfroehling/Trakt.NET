namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Delete;

    [TestClass]
    public class ITraktNoContentDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentDeleteRequestIsInterface()
        {
            typeof(ITraktNoContentDeleteRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentDeleteRequestDerivesFromITraktNoContentRequestInterface()
        {
            typeof(ITraktNoContentDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentRequest));
        }
    }
}
