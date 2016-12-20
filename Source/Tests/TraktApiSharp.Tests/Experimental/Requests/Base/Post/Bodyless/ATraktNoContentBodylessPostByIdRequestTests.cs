namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktNoContentBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktNoContentBodylessPostByIdRequestIsSubclassOfATraktNoContentBodylessPostRequest()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).IsSubclassOf(typeof(ATraktNoContentBodylessPostRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktNoContentBodylessPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktNoContentBodylessPostByIdRequestImplementsITraktObjectRequestInterface()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
