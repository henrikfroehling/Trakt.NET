namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktListGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetRequestIsAbstract()
        {
            typeof(ATraktListGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetRequestIsSubclassOfATraktListRequest()
        {
            typeof(ATraktListGetRequest<int>).IsSubclassOf(typeof(ATraktListRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktListGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktListGetRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktListGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
