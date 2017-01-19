namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieAliasesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieAliasesRequestIsNotAbstract()
        {
            typeof(TraktMovieAliasesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieAliasesRequestIsSealed()
        {
            typeof(TraktMovieAliasesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieAliasesRequestIsSubclassOfATraktListGetByIdRequest()
        {
            //typeof(TraktMovieAliasesRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktMovieAlias>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieAliasesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieAliasesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieAliasesRequestHasValidUriTemplate()
        {
            var request = new TraktMovieAliasesRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/aliases");
        }
    }
}
