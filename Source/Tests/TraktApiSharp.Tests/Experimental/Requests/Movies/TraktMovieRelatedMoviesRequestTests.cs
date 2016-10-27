namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieRelatedMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRelatedMoviesRequestIsNotAbstract()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRelatedMoviesRequestIsSealed()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRelatedMoviesRequestIsSubclassOfATraktPaginationGetByIdRequest()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRelatedMoviesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieRelatedMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }
    }
}
