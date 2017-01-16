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
            typeof(ITraktSingleItemPutRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemPutRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemPutRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPutRequestDerivesFromITraktSingleItemRequestInterface()
        {
            typeof(ITraktSingleItemPutRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }
    }
}
