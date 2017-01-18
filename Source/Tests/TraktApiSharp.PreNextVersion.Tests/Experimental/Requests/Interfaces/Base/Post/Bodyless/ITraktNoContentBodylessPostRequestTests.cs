namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktNoContentBodylessPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentBodylessPostRequestIsInterface()
        {
            typeof(ITraktNoContentBodylessPostRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentBodylessPostRequestDerivesFromITraktNoContentRequestInterface()
        {
            typeof(ITraktNoContentBodylessPostRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentRequest));
        }
    }
}
