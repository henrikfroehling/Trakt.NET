namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktListPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostByIdRequestRequestIsInterface()
        {
            typeof(ITraktListPostByIdRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktListPostByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListPostByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostByIdRequestDerivesFromITraktListPostRequestInterface()
        {
            typeof(ITraktListPostByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktListPostRequest<int, float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktListPostByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
