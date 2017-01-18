namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktSingleItemGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetByIdRequestIsInterface()
        {
            typeof(ITraktSingleItemGetByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetByIdRequestDerivesFromITraktSingleItemGetRequestInterface()
        {
            typeof(ITraktSingleItemGetByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemGetRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktSingleItemGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
