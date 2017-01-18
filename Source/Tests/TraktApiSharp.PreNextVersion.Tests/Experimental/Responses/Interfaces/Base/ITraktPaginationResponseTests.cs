namespace TraktApiSharp.Tests.Experimental.Responses.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Responses;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;

    [TestClass]
    public class ITraktPaginationResponseTests
    {
        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktPaginationResponseIsInterface()
        {
            typeof(ITraktPaginationResponse<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktPaginationResponseHasGenericTypeParameter()
        {
            typeof(ITraktPaginationResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktPaginationResponseDerivesFromITraktListResponseInterface()
        {
            typeof(ITraktPaginationResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktListResponse<int>));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktPaginationResponseDerivesFromITraktPaginationResponseHeadersInterface()
        {
            typeof(ITraktPaginationResponse<>).GetInterfaces().Should().Contain(typeof(ITraktPaginationResponseHeaders));
        }
    }
}
