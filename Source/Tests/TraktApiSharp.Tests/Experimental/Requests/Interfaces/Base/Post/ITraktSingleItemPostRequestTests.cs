namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktSingleItemPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostRequestIsInterface()
        {
            typeof(ITraktSingleItemPostRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostRequestDerivesFromITraktSingleItemRequestInterface()
        {
            typeof(ITraktSingleItemPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktSingleItemPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
