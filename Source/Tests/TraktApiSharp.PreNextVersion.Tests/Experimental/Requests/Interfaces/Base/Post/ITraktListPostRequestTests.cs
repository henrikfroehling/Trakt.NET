namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktListPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostRequestRequestIsInterface()
        {
            typeof(ITraktListPostRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktListPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostRequestDerivesFromITraktListRequestInterface()
        {
            typeof(ITraktListPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktListRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktListPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
