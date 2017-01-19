namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRatingsRequestIsNotAbstract()
        {
            typeof(TraktMovieRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRatingsRequestIsSealed()
        {
            typeof(TraktMovieRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRatingsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            //typeof(TraktMovieRatingsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktRating>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRatingsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktMovieRatingsRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/ratings");
        }
    }
}
