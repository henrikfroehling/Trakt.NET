namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemGetRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemGetRequestIsAbstract()
        {
            typeof(ATraktSingleItemGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemGetRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemGetRequest<int>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktSingleItemGetRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
