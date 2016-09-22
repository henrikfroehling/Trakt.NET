namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemPutRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemPutRequestIsAbstract()
        {
            typeof(ATraktSingleItemPutRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPutRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemPutRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPutRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktSingleItemPutRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemPutRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktSingleItemPutRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktSingleItemPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
