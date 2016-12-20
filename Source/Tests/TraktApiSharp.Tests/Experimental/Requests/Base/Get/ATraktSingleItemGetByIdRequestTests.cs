namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktSingleItemGetByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktSingleItemGetByIdRequestIsSubclassOfATraktSingleItemGetRequest()
        {
            typeof(ATraktSingleItemGetByIdRequest<int>).IsSubclassOf(typeof(ATraktSingleItemGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktSingleItemGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktSingleItemGetByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktSingleItemGetByIdRequestImplementsITraktObjectRequestInterface()
        {
            typeof(ATraktSingleItemGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
