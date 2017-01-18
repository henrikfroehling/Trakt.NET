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
            typeof(ITraktSingleItemPutByIdRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestDerivesFromITraktSingleItemPutRequestInterface()
        {
            typeof(ITraktSingleItemPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemPutRequest<int, float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktSingleItemPutByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
