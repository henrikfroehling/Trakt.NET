namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktListGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetRequestIsInterface()
        {
            typeof(ITraktListGetRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetRequestHasGenericTypeParameter()
        {
            typeof(ITraktListGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetRequestDerivesFromITraktListRequestInterface()
        {
            typeof(ITraktListGetRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListRequest<int>));
        }
    }
}
