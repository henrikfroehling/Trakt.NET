namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class TraktPaginationResponseTests
    {
        [TestMethod]
        public void TestTraktPaginationResponseIsNotAbstract()
        {
            typeof(TraktPaginationResponse<>).IsAbstract.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktPaginationResponseIsSubclassOfTraktListResponse()
        {
            typeof(TraktPaginationResponse<int>).IsSubclassOf(typeof(TraktListResponse<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktPaginationResponseHasGenericTypeParameter()
        {
            typeof(TraktPaginationResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktPaginationResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktPaginationResponseImplementsITraktResponseHeadersInterface()
        {
            typeof(TraktPaginationResponse<>).GetInterfaces().Should().Contain(typeof(ITraktPaginationResponseHeaders));
        }
    }
}
