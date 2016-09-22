namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktSingleItemRequestIsAbstract()
        {
            typeof(ATraktSingleItemRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktSingleItemRequestIsSubclassOfATraktBaseRequest()
        {
            typeof(ATraktSingleItemRequest<>).IsSubclassOf(typeof(ATraktBaseRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktSingleItemRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktSingleItemRequestImplementsITraktSingleItemRequestInterface()
        {
            typeof(ATraktSingleItemRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }
    }
}
