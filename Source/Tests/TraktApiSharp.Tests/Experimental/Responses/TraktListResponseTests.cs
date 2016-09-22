namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class TraktListResponseTests
    {
        [TestMethod, TestCategory("Responses")]
        public void TestTraktListResponseIsNotAbstract()
        {
            typeof(TraktListResponse<>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktListResponseIsSubclassOfATraktResponse()
        {
            typeof(TraktListResponse<int>).IsSubclassOf(typeof(ATraktResponse<List<int>>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktListResponseHasGenericTypeParameter()
        {
            typeof(TraktListResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktListResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktListResponseImplementsITraktResponseHeadersInterface()
        {
            typeof(TraktListResponse<>).GetInterfaces().Should().Contain(typeof(ITraktResponseHeaders));
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktListResponseImplementsIEnumerableInterface()
        {
            typeof(TraktListResponse<int>).GetInterfaces().Should().Contain(typeof(IEnumerable<int>));
        }
    }
}
