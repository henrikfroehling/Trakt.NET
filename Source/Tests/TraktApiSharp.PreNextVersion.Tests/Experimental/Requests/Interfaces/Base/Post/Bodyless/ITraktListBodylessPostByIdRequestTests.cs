namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktListBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostByIdRequestIsInterface()
        {
            typeof(ITraktListBodylessPostByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktListBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostByIdRequestDerivesFromITraktListBodylessPostRequestInterface()
        {
            typeof(ITraktListBodylessPostByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListBodylessPostRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktListBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
