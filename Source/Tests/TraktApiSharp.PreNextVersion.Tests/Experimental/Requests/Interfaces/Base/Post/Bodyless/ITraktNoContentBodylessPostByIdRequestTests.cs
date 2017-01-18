namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktNoContentBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentBodylessPostByIdRequestIsInterface()
        {
            typeof(ITraktNoContentBodylessPostByIdRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentBodylessPostByIdRequestDerivesFromITraktNoContentBodylessPostRequestInterface()
        {
            typeof(ITraktNoContentBodylessPostByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentBodylessPostRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentBodylessPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktNoContentBodylessPostByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
