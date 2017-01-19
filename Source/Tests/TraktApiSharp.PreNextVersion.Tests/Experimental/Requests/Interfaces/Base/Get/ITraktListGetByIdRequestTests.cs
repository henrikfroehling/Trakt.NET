namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktListGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetByIdRequestIsInterface()
        {
            typeof(ITraktListGetByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktListGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetByIdRequestDerivesFromITraktListGetRequestInterface()
        {
            typeof(ITraktListGetByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListGetRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktListGetByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktListGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
