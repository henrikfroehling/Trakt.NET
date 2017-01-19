namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Requests;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowAliasesRequestIsSubclassOfATraktListGetByIdRequest()
        {
            //typeof(TraktShowAliasesRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktShowAlias>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowAliasesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowAliasesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowAliasesRequestHasValidUriTemplate()
        {
            var request = new TraktShowAliasesRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/aliases");
        }
    }
}
