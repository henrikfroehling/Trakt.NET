namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ATraktListGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetByIdRequestIsAbstract()
        {
            typeof(ATraktListGetByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetByIdRequestIsSubclassOfATraktListGetRequest()
        {
            typeof(ATraktListGetByIdRequest<int>).IsSubclassOf(typeof(ATraktListGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktListGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetByIdRequestImplementsITraktListGetByIdRequestInterface()
        {
            typeof(ATraktListGetByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListGetByIdRequest<int>));
        }
    }
}
