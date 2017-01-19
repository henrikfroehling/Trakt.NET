namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktListPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutByIdRequestIsInterface()
        {
            typeof(ITraktListPutByIdRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktListPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutByIdRequestDerivesFromITraktListPutRequestInterface()
        {
            typeof(ITraktListPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktListPutRequest<int, float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListPutByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktListPutByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
