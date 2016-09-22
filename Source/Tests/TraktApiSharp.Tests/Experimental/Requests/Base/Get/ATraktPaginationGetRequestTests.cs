namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktPaginationGetRequestIsAbstract()
        {
            typeof(ATraktPaginationGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktPaginationGetRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationGetRequest<int>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktPaginationGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktPaginationGetRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
