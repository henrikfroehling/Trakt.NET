namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMoviesMostCollectedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestIsNotAbstract()
        {
            typeof(TraktMoviesMostCollectedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestIsSealed()
        {
            typeof(TraktMoviesMostCollectedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestIsSubclassOfATraktMoviesMostPWCRequest()
        {
            typeof(TraktMoviesMostCollectedRequest).IsSubclassOf(typeof(ATraktMoviesMostPWCRequest<TraktMostCollectedMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMoviesMostCollectedRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestHasValidUriTemplate()
        {
            var request = new TraktMoviesMostCollectedRequest(null);
            request.UriTemplate.Should().Be("movies/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestUriParamsWithoutPeriod()
        {
            var request = new TraktMoviesMostCollectedRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestUriParamsWithUnspecifiedPeriod()
        {
            var period = TraktTimePeriod.Unspecified;

            var request = new TraktMoviesMostCollectedRequest(null)
            {
                Period = period
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestUriParamsWithPeriod()
        {
            var period = TraktTimePeriod.Monthly;

            var request = new TraktMoviesMostCollectedRequest(null)
            {
                Period = period
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("period", period.UriName);
        }
    }
}
