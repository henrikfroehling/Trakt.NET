namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ATraktListPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktListPutByIdRequestIsAbstract()
        {
            typeof(ATraktListPutByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktListPutByIdRequestIsSubclassOfATraktListPutRequest()
        {
            typeof(ATraktListPutByIdRequest<int, float>).IsSubclassOf(typeof(ATraktListPutRequest<int, float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktListPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktListPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktListPutByIdRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktListPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktListPutByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktListPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
