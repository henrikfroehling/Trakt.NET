namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemPutByIdRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemPutByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemPutByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPutByIdRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemPutByIdRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktSingleItemPutByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemPutByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktSingleItemPutByIdRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktSingleItemPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }

        [TestMethod]
        public void TestATraktSingleItemPutByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktSingleItemPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
