namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class TraktListResponseTests
    {
        [TestMethod]
        public void TestTraktListResponseIsNotAbstract()
        {
            typeof(TraktListResponse<>).IsAbstract.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktListResponseIsSubclassOfATraktResponse()
        {
            typeof(TraktListResponse<int>).IsSubclassOf(typeof(ATraktResponse<List<int>>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktListResponseHasGenericTypeParameter()
        {
            typeof(TraktListResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktListResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktListResponseImplementsITraktResponseHeadersInterface()
        {
            typeof(TraktListResponse<>).GetInterfaces().Should().Contain(typeof(ITraktResponseHeaders));
        }

        [TestMethod]
        public void TestTraktListResponseImplementsIEnumerableInterface()
        {
            typeof(TraktListResponse<int>).GetInterfaces().Should().Contain(typeof(IEnumerable<int>));
        }
    }
}
