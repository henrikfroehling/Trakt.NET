namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktSingleItemGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetRequestIsInterface()
        {
            typeof(ITraktSingleItemGetRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemGetRequestDerivesFromITraktSingleItemRequestInterface()
        {
            typeof(ITraktSingleItemGetRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }
    }
}
