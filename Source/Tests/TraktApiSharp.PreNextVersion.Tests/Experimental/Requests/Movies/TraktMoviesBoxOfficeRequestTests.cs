namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMoviesBoxOfficeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestIsNotAbstract()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestIsSealed()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestIsSubclassOfATraktListGetRequest()
        {
            //typeof(TraktMoviesBoxOfficeRequest).IsSubclassOf(typeof(ATraktListGetRequest<TraktBoxOfficeMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMoviesBoxOfficeRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestHasValidUriTemplate()
        {
            var request = new TraktMoviesBoxOfficeRequest(null);
            request.UriTemplate.Should().Be("movies/boxoffice{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktMoviesBoxOfficeRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }
    }
}
