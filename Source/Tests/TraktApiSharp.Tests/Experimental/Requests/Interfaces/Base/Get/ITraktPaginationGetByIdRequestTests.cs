namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ITraktPaginationGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetByIdRequestIsInterface()
        {
            typeof(ITraktPaginationGetByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetByIdRequestDerivesFromITraktPaginationGetRequestInterface()
        {
            typeof(ITraktPaginationGetByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationGetRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationGetByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktPaginationGetByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
