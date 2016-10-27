namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
