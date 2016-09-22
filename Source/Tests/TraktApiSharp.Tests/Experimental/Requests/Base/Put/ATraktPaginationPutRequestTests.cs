namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationPutRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationPutRequestIsAbstract()
        {
            typeof(ATraktPaginationPutRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationPutRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationPutRequest<int, float>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationPutRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktPaginationPutRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationPutRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktPaginationPutRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktPaginationPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
