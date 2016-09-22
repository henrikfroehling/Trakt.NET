namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemGetByIdRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemGetByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemGetByIdRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemGetByIdRequest<int>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktSingleItemGetByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktSingleItemGetByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
