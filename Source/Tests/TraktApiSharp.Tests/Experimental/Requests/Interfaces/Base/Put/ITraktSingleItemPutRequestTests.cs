namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktSingleItemPutRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutRequestIsInterface()
        {
            typeof(ITraktSingleItemPutRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutRequestDerivesFromITraktSingleItemRequestInterface()
        {
            typeof(ITraktSingleItemPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktSingleItemPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
