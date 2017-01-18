namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktPaginationPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostRequestIsInterface()
        {
            typeof(ITraktPaginationPostRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostRequestDerivesFromITraktPaginationRequestInterface()
        {
            typeof(ITraktPaginationPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktPaginationRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPostRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktPaginationPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
