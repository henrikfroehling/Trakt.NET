namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktListPutRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutRequestIsInterface()
        {
            typeof(ITraktListPutRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutRequestHasGenericTypeParameter()
        {
            typeof(ITraktListPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutRequestDerivesFromITraktListRequestInterface()
        {
            typeof(ITraktListPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktListRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktListPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
