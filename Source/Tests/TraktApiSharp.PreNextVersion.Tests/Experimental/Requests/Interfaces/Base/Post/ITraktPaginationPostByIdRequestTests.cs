namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktPaginationPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostByIdRequestIsInterface()
        {
            typeof(ITraktPaginationPostByIdRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationPostByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationPostByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostByIdRequestDerivesFromITraktPaginationRequestInterface()
        {
            typeof(ITraktPaginationPostByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktPaginationPostRequest<int, float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktPaginationPostByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
