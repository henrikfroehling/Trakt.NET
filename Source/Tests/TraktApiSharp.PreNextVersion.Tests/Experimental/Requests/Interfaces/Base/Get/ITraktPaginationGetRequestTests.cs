namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktPaginationGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetRequestIsInterface()
        {
            typeof(ITraktPaginationGetRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetRequestDerivesFromITraktPaginationRequestInterface()
        {
            typeof(ITraktPaginationGetRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationRequest<int>));
        }
    }
}
