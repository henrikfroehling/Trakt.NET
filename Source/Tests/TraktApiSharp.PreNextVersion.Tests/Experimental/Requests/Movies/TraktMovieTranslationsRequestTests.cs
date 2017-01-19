namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieTranslationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieTranslationsRequestIsNotAbstract()
        {
            typeof(TraktMovieTranslationsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieTranslationsRequestIsSealed()
        {
            typeof(TraktMovieTranslationsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieTranslationsRequestIsSubclassOfATraktListGetByIdRequest()
        {
            //typeof(TraktMovieTranslationsRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktMovieTranslation>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieTranslationsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieTranslationsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieTranslationsRequestHasValidUriTemplate()
        {
            var request = new TraktMovieTranslationsRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/translations");
        }
    }
}
