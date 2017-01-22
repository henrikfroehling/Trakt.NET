namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMoviesMostWatchedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestIsNotAbstract()
        {
            typeof(TraktMoviesMostWatchedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestIsSealed()
        {
            typeof(TraktMoviesMostWatchedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestIsSubclassOfATraktMoviesMostPWCRequest()
        {
            typeof(TraktMoviesMostWatchedRequest).IsSubclassOf(typeof(ATraktMoviesMostPWCRequest<TraktMostWatchedMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMoviesMostWatchedRequest(null);
            //request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestHasValidUriTemplate()
        {
            var request = new TraktMoviesMostWatchedRequest(null);
            request.UriTemplate.Should().Be("movies/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        //[TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        //public void TestTraktMoviesMostWatchedRequestUriParamsWithoutPeriod()
        //{
        //    var request = new TraktMoviesMostWatchedRequest(null);
        //    var uriParams = request.GetUriPathParameters();

        //    uriParams.Should().NotBeNull().And.BeEmpty();
        //}

        //[TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        //public void TestTraktMoviesMostWatchedRequestUriParamsWithUnspecifiedPeriod()
        //{
        //    var period = TraktTimePeriod.Unspecified;

        //    var request = new TraktMoviesMostWatchedRequest(null)
        //    {
        //        Period = period
        //    };

        //    var uriParams = request.GetUriPathParameters();

        //    uriParams.Should().NotBeNull().And.BeEmpty();
        //}

        //[TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        //public void TestTraktMoviesMostWatchedRequestUriParamsWithPeriod()
        //{
        //    var period = TraktTimePeriod.Monthly;

        //    var request = new TraktMoviesMostWatchedRequest(null)
        //    {
        //        Period = period
        //    };

        //    var uriParams = request.GetUriPathParameters();

        //    uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
        //    uriParams.Should().Contain("period", period.UriName);
        //}
    }
}
