namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktListBodylessPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostRequestIsInterface()
        {
            typeof(ITraktListBodylessPostRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktListBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListBodylessPostRequestDerivesFromITraktListRequestInterface()
        {
            typeof(ITraktListBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListRequest<int>));
        }
    }
}
