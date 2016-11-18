namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowAliasesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowAliasesRequestIsNotAbstract()
        {
            typeof(TraktShowAliasesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowAliasesRequestIsSealed()
        {
            typeof(TraktShowAliasesRequest).IsSealed.Should().BeTrue();
        }
    }
}
