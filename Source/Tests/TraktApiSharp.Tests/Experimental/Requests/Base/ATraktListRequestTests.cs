namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktListRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktListRequestIsAbstract()
        {
            typeof(ATraktListRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktListRequestIsSubclassOfATraktBaseRequest()
        {
            typeof(ATraktListRequest<>).IsSubclassOf(typeof(ATraktBaseRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktListRequestHasGenericTypeParameter()
        {
            typeof(ATraktListRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktListRequestImplementsITraktListRequestInterface()
        {
            typeof(ATraktListRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListRequest<int>));
        }
    }
}
