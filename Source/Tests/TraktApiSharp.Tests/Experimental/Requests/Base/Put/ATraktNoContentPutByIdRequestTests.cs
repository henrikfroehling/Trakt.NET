namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentPutByIdRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentPutByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentPutByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentPutByIdRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentPutByIdRequest<float>).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktNoContentPutByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktNoContentPutByIdRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktNoContentPutByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentPutByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktNoContentPutByIdRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktNoContentPutByIdRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }

        [TestMethod]
        public void TestATraktNoContentPutByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentPutByIdRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
