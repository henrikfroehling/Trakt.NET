namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemRequestIsAbstract()
        {
            typeof(ATraktSingleItemRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemRequestIsSubclassOfATraktBaseRequest()
        {
            typeof(ATraktSingleItemRequest<>).IsSubclassOf(typeof(ATraktBaseRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktSingleItemRequestImplementsITraktSingleItemRequestInterface()
        {
            typeof(ATraktSingleItemRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }
    }
}
