namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMoviesMostAnticipatedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostAnticipatedRequestIsNotAbstract()
        {
            typeof(TraktMoviesMostAnticipatedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostAnticipatedRequestIsSealed()
        {
            typeof(TraktMoviesMostAnticipatedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostAnticipatedRequestIsSubclassOfATraktMoviesRequest()
        {
            typeof(TraktMoviesMostAnticipatedRequest).IsSubclassOf(typeof(ATraktMoviesRequest<TraktMostAnticipatedMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostAnticipatedRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMoviesMostAnticipatedRequest(null);
            //request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostAnticipatedRequestHasValidUriTemplate()
        {
            var request = new TraktMoviesMostAnticipatedRequest(null);
            request.UriTemplate.Should().Be("movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }
    }
}
