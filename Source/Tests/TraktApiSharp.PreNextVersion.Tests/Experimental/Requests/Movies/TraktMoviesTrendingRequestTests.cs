namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMoviesTrendingRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesTrendingRequestIsNotAbstract()
        {
            typeof(TraktMoviesTrendingRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesTrendingRequestIsSealed()
        {
            typeof(TraktMoviesTrendingRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesTrendingRequestIsSubclassOfATraktMoviesRequest()
        {
            typeof(TraktMoviesTrendingRequest).IsSubclassOf(typeof(ATraktMoviesRequest<TraktTrendingMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesTrendingRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMoviesTrendingRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesTrendingRequestHasValidUriTemplate()
        {
            var request = new TraktMoviesTrendingRequest(null);
            request.UriTemplate.Should().Be("movies/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }
    }
}
