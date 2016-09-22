namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktListPutByIdRequestTests
    {
        [TestMethod]
        public void TestATraktListPutByIdRequestIsAbstract()
        {
            typeof(ATraktListPutByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListPutByIdRequestIsSubclassOfATraktListRequest()
        {
            typeof(ATraktListPutByIdRequest<int, float>).IsSubclassOf(typeof(ATraktListRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktListPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktListPutByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktListPutByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktListPutByIdRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktListPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }

        [TestMethod]
        public void TestATraktListPutByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktListPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
