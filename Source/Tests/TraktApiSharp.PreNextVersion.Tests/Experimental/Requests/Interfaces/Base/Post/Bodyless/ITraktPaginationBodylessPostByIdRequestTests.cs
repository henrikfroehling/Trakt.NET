namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktPaginationBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostByIdRequestIsInterface()
        {
            typeof(ITraktPaginationBodylessPostByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostByIdRequestDerivesFromITraktPaginationBodylessPostRequestInterface()
        {
            typeof(ITraktPaginationBodylessPostByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationBodylessPostRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktPaginationBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
