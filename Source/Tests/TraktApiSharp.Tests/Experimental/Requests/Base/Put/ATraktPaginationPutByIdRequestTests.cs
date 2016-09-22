namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationPutByIdRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationPutByIdRequestIsAbstract()
        {
            typeof(ATraktPaginationPutByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationPutByIdRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationPutByIdRequest<int, float>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktPaginationPutByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationPutByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktPaginationPutByIdRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktPaginationPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }

        [TestMethod]
        public void TestATraktPaginationPutByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktPaginationPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
