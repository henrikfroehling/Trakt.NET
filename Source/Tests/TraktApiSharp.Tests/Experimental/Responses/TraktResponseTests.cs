namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class TraktResponseTests
    {
        [TestMethod, TestCategory("Responses")]
        public void TestTraktResponseIsNotAbstract()
        {
            typeof(TraktResponse<>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktResponseIsSealed()
        {
            typeof(TraktResponse<>).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktResponseIsSubclassOfATraktResponse()
        {
            typeof(TraktResponse<int>).IsSubclassOf(typeof(ATraktResponse<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktResponseHasGenericTypeParameter()
        {
            typeof(TraktResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktResponseImplementsITraktResponseHeadersInterface()
        {
            typeof(TraktResponse<>).GetInterfaces().Should().Contain(typeof(ITraktResponseHeaders));
        }
    }
}
