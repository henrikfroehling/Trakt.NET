namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktSingleItemPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestIsInterface()
        {
            typeof(ITraktSingleItemPutByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemPutByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemPutByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestDerivesFromITraktSingleItemPutRequestInterface()
        {
            typeof(ITraktSingleItemPutByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemPutRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktSingleItemPutByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
